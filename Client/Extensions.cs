using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Wsdot.Traffic.Client
{
	internal static class Extensions
	{
		/// <summary>
		/// Converts a state route name into one that is valid for the ELC.
		/// <example>E.g., Converts SR 5 to 005.</example>
		/// </summary>
		/// <param name="inputId"></param>
		/// <returns></returns>
		public static string CreateValidRouteId(this string inputId)
		{
			if (inputId == null)
			{
				throw new ArgumentNullException("inputId");
			}
			Regex validId = new Regex(@"^\d{3}");
			Regex digits = new Regex(@"\d+$");
			if (validId.IsMatch(inputId))
			{
				return inputId;
			}
			else
			{
				var match = digits.Match(inputId);
				if (match.Success)
				{
					return int.Parse(match.Value).ToString("000");
				}
			}
			throw new ArgumentException(string.Format("Could not convert {0} into a valid state route.", inputId), "inputId");
		}
	}
}
