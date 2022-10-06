using Microsoft.VisualBasic;
using System.Reflection.PortableExecutable;

namespace LoggingKata
{
       public class TacoParser
    {
        readonly ILog logger = new TacoLogger();
        
        public ITrackable Parse(string line)
        {
            logger.LogInfo("Begin parsing");
           
            var cells = line.Split(',');
                       
            if (cells.Length < 3)
            {              
                logger.LogInfo($"{cells} is less than 3, something went wrong");              
                return null;
            }
            var latitude = double.Parse(cells[0]);
            var longitude = double.Parse(cells[1]);   
            var name = cells[2];

            var tBClass = new TacoBell();
            var pointsomething = new Point();
            
            pointsomething.Latitude = latitude;
            pointsomething.Longitude = longitude;            
           
            tBClass.Name = name;
            tBClass.Location = pointsomething;

            return tBClass;
        }
    }
}