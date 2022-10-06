using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;

namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines(csvPath);

            logger.LogInfo("Log initialized");       

            var parser = new TacoParser();
            var allLocations = lines.Select(parser.Parse).ToArray();

            logger.LogInfo($"locations Parsed");

            ITrackable location1 = null;
            ITrackable location2 = null;
            double distance = 0;

            for (int i = 0; i < allLocations.Length; i++)
            {
                var locA = allLocations[i];
                var corA = new GeoCoordinate(locA.Location.Latitude, locA.Location.Longitude);

                for (int j = 0; j < allLocations.Length; j++)
                {
                    var locB = allLocations[j];
                    var corB = new GeoCoordinate(locB.Location.Latitude, locB.Location.Longitude);
                    var getDistance = corA.GetDistanceTo(corB);

                    if (getDistance > distance)
                    {
                        distance = getDistance;
                        location1 = locA;
                        location2 = locB;
                    }
                }
            }
            var distanceInMiles = Math.Round((distance / 1609), 1);

            Console.WriteLine();
            Console.WriteLine($"{location1.Name} and {location2.Name} are the TacoBells that are the furthest apart in AL.\n" +
            $" They are about {distanceInMiles} miles apart");
        }
    }
}
