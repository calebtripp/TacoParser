namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the Taco Bells
    /// </summary>
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
                // Do not fail if one record parsing fails, return null??
                return null; // TODO Implement
            }

            var latitude = double.Parse(cells[0]);
            var longitude = double.Parse(cells[1]);   
            var name = cells[2];    
           

            
            // You'll need to create a TacoBell class
            // that conforms to ITrackable

            // Then, you'll need an instance of the TacoBell class
            // With the name and point set correctly

            // Then, return the instance of your TacoBell class
            // Since it conforms to ITrackable

            return null;
        }
    }
}