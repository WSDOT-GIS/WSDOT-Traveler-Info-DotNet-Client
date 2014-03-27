using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WsdotTravelerInfoContracts.Ferries.Terminals;

namespace Wsdot.Traffic.Client
{
	public enum TerminalQueryType
	{
		Basics,
		Bulletins,
		Locations,
		SailingSpace,
		Transports,
		WaitTimes,
		Verbose
	}

	public class WsfClient
	{
		const string _defaultFerriesApiRoot = "http://www.wsdot.wa.gov/ferries/api/terminals/rest";

		private string _wsfApiRoot = _defaultFerriesApiRoot;

		public string AccessCode { get; set; }

		public string WsfApiRoot
		{
			get { return _wsfApiRoot; }
			set { _wsfApiRoot = value; }
		}

		Dictionary<string, object> _cache = new Dictionary<string, object>();
		DateTimeOffset _lastCacheFlushDate;

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

		protected async Task<T> QueryEndpoint<T>(string endpointName, int? terminalId=null, bool? checkForCache=null) where T : class
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

		public async Task<Terminal[]> Query(TerminalQueryType queryType)
		{
			string endpoint = string.Format("terminal{0}", Enum.GetName(typeof(TerminalQueryType), queryType).ToLowerInvariant());
			return await QueryEndpoint<Terminal[]>(endpoint);
		}

		public async Task<Terminal> Query(TerminalQueryType queryType, int terminalId)
		{
			string endpoint = string.Format("terminal{0}", Enum.GetName(typeof(TerminalQueryType), queryType).ToLowerInvariant());
			return await QueryEndpoint<Terminal>(endpoint, terminalId);
		}
		
	}
}
