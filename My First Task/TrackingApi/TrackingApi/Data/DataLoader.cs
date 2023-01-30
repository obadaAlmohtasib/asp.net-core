using Newtonsoft.Json;
using System.Xml.Serialization;
using TrackingApi.Model;
using static System.Net.Mime.MediaTypeNames;

namespace TrackingApi.Data
{
    public class DataLoader
    {
        private static DataLoader _dataLoader;
        private readonly JSONData _JSONData;
        private readonly XMLData _XMLData;
        // Next time, it's more better to adding these files pointers in a config file.
        private readonly String JSON_FILE_PATH = Path.Combine(Environment.CurrentDirectory, @"Data\", "JSON Hotels Result.json");
        private readonly String XML_FILE_PATH = Path.Combine(Environment.CurrentDirectory, @"Data\", "Xml Hotels Result.xml");

        public static DataLoader getInstance()
        {
            if (_dataLoader == null)
            {
                _dataLoader = new DataLoader();
            }
            return _dataLoader;
        }

        private DataLoader() {
            // Load & Read JSON File
            String jsonFileContent = System.IO.File.ReadAllText(JSON_FILE_PATH);
            _JSONData = JsonConvert.DeserializeObject<JSONData>(jsonFileContent);

            // Load & Read XML File
            String xmlFileContent = System.IO.File.ReadAllText(XML_FILE_PATH);
            XmlSerializer serializer = new XmlSerializer(typeof(XMLData));
            using (StringReader reader = new StringReader(xmlFileContent))
            {
                _XMLData = (XMLData) serializer.Deserialize(reader);
            }
        }

        public XMLData ReadXML()
        {
            return _XMLData;
        }
        public JSONData ReadJSON()
        {
            return _JSONData;
        }

        // Just an Idea: I may divide the dataset up to 5 lists
        // And caching 5 List depends on Rating [1, 5] 
        // And at the same time Sorting these lists by hotel name alphabetically.
        // So that give a better filtration performance, i guess so.
        public List<ResponseHotel> SearchForHotels(string query) 
        {
            List<ResponseHotel> response = new List<ResponseHotel>();
            // Loop over in JSON Data
            List<Hotel> hotels = _JSONData.avaliabilitiesResponse.Hotels.Hotel;
            foreach (var hotel in hotels)
            {
                if (Convert.ToString(hotel.IsReady).ToLower() == query || hotel.HotelsName.ToLower() == query ||
                    Convert.ToString(hotel.Rating).ToLower() == query)
                {
                    response.Add(new ResponseHotel(hotel.HotelCode, hotel.HotelsName, hotel.Location, hotel.Rating, hotel.Currency, hotel.LowestPrice, hotel.IsReady, hotel.GetRooms()));
                }
            }
            // Loop over XML Data
            List<HOTEL> HOTELS = _XMLData.HOTELS.HOTEL;
            foreach (var hotel in HOTELS)
            {
                if (Convert.ToString(hotel.IsReady()).ToLower() == query || hotel.HOTELNAME.ToLower() == query || Convert.ToString(hotel.GetRating()) == query)
                {
                    response.Add(new ResponseHotel(hotel.HOTELID + "", hotel.HOTELNAME, hotel.LOCATION, hotel.GetRating(), hotel.CURRENCY, hotel.STARTINGPRICE, hotel.IsReady(), hotel.GetRooms()));
                }
            }
            return response;
        }
    }
}