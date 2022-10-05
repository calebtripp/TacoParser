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
            // TODO:  Find the two Taco Bells that are the furthest from one another.
            // HINT:  You'll need two nested forloops ---------------------------

            logger.LogInfo("Log initialized");           
          
            var lines = File.ReadAllLines(csvPath);

            logger.LogInfo($"Lines: {lines[0]}");
            logger.LogInfo($"Warning: {lines[1]}");
                      
            var parser = new TacoParser();
                       
            var locations = lines.Select(parser.Parse).ToArray();

            logger.LogInfo($"locations Parsed");

            ITrackable location1 = null;
            ITrackable location2 = null;
            double distance;
            GeoPosition(location1, location2);
        }
    }
}
