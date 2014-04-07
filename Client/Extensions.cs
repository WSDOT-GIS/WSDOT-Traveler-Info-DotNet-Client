using System;
using System.Text.RegularExpressions;

namespace Wsdot.Traffic.Client
{
	internal static class Extensions
	{
		/// <summary>
		/// Converts a state route name into one that is valid for the ELC.
		/// <example>E.g., Converts SR 5 to 005.</example>
		/// </summary>
		/// <param name="inputId">A string containing a route name.</param>
		/// <returns></returns>
		/// <exception cref="ArgumentNullException">Thrown if <paramref name="inputId"/> is <see langword="null"/>.</exception>
		/// <exception cref="ArgumentException">Thrown if a route number could not be detected in <paramref name="inputId"/>.</exception>
		public static string CreateValidRouteId(this string inputId)
		{
			if (inputId == null)
			{
				throw new ArgumentNullException("inputId");
			}
			Regex validId = new Regex(@"^\d{3}"); // The string starts with three digits.
			Regex digits = new Regex(@"\d+$"); // Matches three digits.
			if (validId.IsMatch(inputId)) // If the string is already valid, return it.
			{
				return inputId;
			}
			else // Extract the route number and convert it to three-digit format.
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
