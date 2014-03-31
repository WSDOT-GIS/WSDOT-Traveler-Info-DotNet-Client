using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using WsdotTravelerInfoContracts.Ferries.Terminals;

namespace Wsdot.Traffic.Client
{
	/// <summary>
	/// This type is used to specify a type of WSF Terminal query.
	/// </summary>
	public enum TerminalQueryType
	{
		/// <summary>Basics</summary>
		Basics,
		/// <summary>Bulletins</summary>
		Bulletins,
		/// <summary>Locations</summary>
		Locations,
		/// <summary>Sailing Space</summary>
		SailingSpace,
		/// <summary>Transports</summary>
		Transports,
		/// <summary>Wait Times</summary>
		WaitTimes,
		/// <summary>Verbose</summary>
		Verbose
	}

	/// <summary>
	/// Client for calling WA State Ferries REST endpoints. <see href="http://www.wsdot.wa.gov/ferries/api/terminals/documentation/rest.html"/>
	/// </summary>
	public class WsfClient
	{
		/// <summary>Creates a new instance of this class.</summary>
		public WsfClient() { }

		/// <summary>
		/// Creates a new instance of this class.
		/// </summary>
		/// <param name="accessCode">The <see href="http://www.wsdot.wa.gov/Traffic/api/">Traffic API Access Code</see>.</param>
		public WsfClient(string accessCode)
			: this()
		{
			this.AccessCode = accessCode;
		}

		const string _defaultFerriesApiRoot = "http://www.wsdot.wa.gov/ferries/api/terminals/rest";

		private string _wsfApiRoot = _defaultFerriesApiRoot;

		/// <summary>
		/// The <see href="http://www.wsdot.wa.gov/Traffic/api/">Traffic API Access Code</see> that will be used for querying the API.
		/// </summary>
		public string AccessCode { get; set; }

		/// <summary>
		/// Gets or sets the API root URL. You would only need to change this if the API is moved.
		/// </summary>
		public string WsfApiRoot
		{
			get { return _wsfApiRoot; }
			set { _wsfApiRoot = value; }
		}

		Dictionary<string, object> _cache = new Dictionary<string, object>();
		DateTimeOffset _lastCacheFlushDate;

		/// <summary>
		/// Gets the Cache Flush date. <see href="http://www.wsdot.wa.gov/ferries/api/terminals/documentation/rest.html#tabcacheflushdate"/>
		/// </summary>
		/// <returns>Returns the cache flush date.</returns>
		public async Task<DateTimeOffset> GetCacheFlushDate()
		{
			DateTimeOffset result;
			using (var client = new HttpClient())
			{
				var dateString = await client.GetStringAsync(string.Join("/", WsfApiRoot, "cacheflushdate"));
				result = JsonConvert.DeserializeObject<DateTimeOffset>(dateString);
			}
			// Clear the cached results if the content has been updated since then.
			if (result > _lastCacheFlushDate)
			{
				_cache.Clear();
				_lastCacheFlushDate = result;
			}
			return result;
		}

		/// <summary>
		/// Queries one of the <see href="http://www.wsdot.wa.gov/ferries/api/terminals/documentation/rest.html">WSF Terminals API</see> endpoints.
		/// </summary>
		/// <typeparam name="T">The type of response object. Either <see cref="Terminal"/> or an array of <see cref="Terminal"/>.</typeparam>
		/// <param name="endpointName"></param>
		/// <param name="terminalId"></param>
		/// <param name="checkForCache"></param>
		/// <returns></returns>
		protected async Task<T> QueryEndpoint<T>(string endpointName, int? terminalId = null, bool? checkForCache = null) where T : class
		{
			const string
				allFmt = "{0}/{1}?apiaccesscode={2}",
				oneFmt = "{0}/{1}/{2}?apiaccesscode={3}";
			// Create the URL. It will differ depending of whether or not there is a terminal ID provided.
			string url = terminalId.HasValue ?
				string.Format(oneFmt, WsfApiRoot, endpointName, terminalId.Value, AccessCode)
				: string.Format(allFmt, WsfApiRoot, endpointName, AccessCode);

			T output = null;

			if (!checkForCache.HasValue)
			{
				checkForCache = string.Compare(endpointName, "terminalsailingspace", true) != 0;  //endpointName != "terminalsailingspace";
			}

			// Check for a newer cache flush date and clear the cache if a newer date is found.
			// Get the output value from the cache dictionary if possible.
			if (checkForCache.Value)
			{
				await GetCacheFlushDate();
				if (_cache.ContainsKey(endpointName))
				{
					output = _cache[endpointName] as T;
				}
			}

			// If there is no cached value available, query the API and return the results.
			if (output == null)
			{
				using (var client = new HttpClient())
				using (var stream = await client.GetStreamAsync(url))
				using (var reader = new StreamReader(stream))
				using (var jsonReader = new JsonTextReader(reader))
				{
					var serializer = new JsonSerializer();
					output = serializer.Deserialize<T>(jsonReader);

				}
			}

			return output;
		}

		/// <summary>
		/// Queries the <see href="http://www.wsdot.wa.gov/ferries/api/terminals/documentation/rest.html">WSF Terminals API</see>
		/// for a list of terminals.
		/// </summary>
		/// <typeparam name="T">An type that implements <see cref="IEnumerable&lt;T&gt;"/> of <see cref="Terminal"/>.</typeparam>
		/// <param name="queryType">The <see cref="TerminalQueryType"/></param>
		/// <returns>Returns a list of <see cref="Terminal"/> objects.</returns>
		public async Task<T> Query<T>(TerminalQueryType queryType) where T : class, IEnumerable<Terminal>
		{
			string endpoint = string.Format("terminal{0}", Enum.GetName(typeof(TerminalQueryType), queryType).ToLowerInvariant());
			return await QueryEndpoint<T>(endpoint);
		}

		/// <summary>
		/// Queries the <see href="http://www.wsdot.wa.gov/ferries/api/terminals/documentation/rest.html">WSF Terminals API</see>
		/// for a single terminal specified by its Terminal ID.
		/// </summary>
		/// <param name="queryType">The <see cref="TerminalQueryType"/></param>
		/// <param name="terminalId">The unique identifier for a ferry terminal.</param>
		/// <returns>Returns the terminal specified by the <paramref name="terminalId"/>.</returns>
		public async Task<Terminal> Query(TerminalQueryType queryType, int terminalId)
		{
			string endpoint = string.Format("terminal{0}", Enum.GetName(typeof(TerminalQueryType), queryType).ToLowerInvariant());
			return await QueryEndpoint<Terminal>(endpoint, terminalId);
		}

	}
}
