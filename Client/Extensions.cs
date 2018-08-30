using System;
using System.Linq;
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
        /// <param name="throwOnInvalid">
        /// Set to <see langword="true"/> to throw an exception if the input cannot be parsed, 
        /// <see langword="false"/> to return <see langword="null"/> in that case.
        /// </param>
        /// <returns>Returns a state route ID (or possibly <see langword="null"/> if <paramref name="throwOnInvalid"/> is <see langword="false"/>.)</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="inputId"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException">Thrown if a route number could not be detected in <paramref name="inputId"/>.</exception>
        public static string CreateValidRouteId(this string inputId, bool throwOnInvalid = true)
        {
            if (inputId == null)
            {
                if (throwOnInvalid)
                {
                    throw new ArgumentNullException(nameof(inputId));
                }
                else
                {
                    return null;
                }
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
            if (throwOnInvalid)
            {
                throw new ArgumentException(string.Format("Could not convert {0} into a valid state route.", inputId), nameof(inputId));
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Gets a valid Route ID to use with the ELC, if possible.
        /// Normally it will be the <see cref="RoadwayLocation.RoadName"/> of <see cref="ILineSegment.StartRoadwayLocation"/>,
        /// and if that's not valid, that of <see cref="ILineSegment.EndRoadwayLocation"/>.
        /// </summary>
        /// <param name="lineSegment">A traffic API object that implements <see cref="ILineSegment"/></param>
        /// <returns>Normally it will be the <see cref="RoadwayLocation.RoadName"/> of <see cref="ILineSegment.StartRoadwayLocation"/>,
        /// and if that's not valid, that of <see cref="ILineSegment.EndRoadwayLocation"/>.</returns>
        public static string GetRouteId(this ILineSegment lineSegment)
        {
            var segments = new[] { lineSegment.StartRoadwayLocation, lineSegment.EndRoadwayLocation };
            return segments.Select(s => s.RoadName.CreateValidRouteId(false)).FirstOrDefault();
        }

    }
}
