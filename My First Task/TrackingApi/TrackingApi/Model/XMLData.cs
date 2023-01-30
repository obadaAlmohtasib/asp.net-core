using System.Xml.Serialization;

namespace TrackingApi.Model
{    
    // using System.Xml.Serialization;
    // XmlSerializer serializer = new XmlSerializer(typeof(HOTELSEARCHRESPONSE));
    // using (StringReader reader = new StringReader(xml))
    // {
    //    var test = (HOTELSEARCHRESPONSE)serializer.Deserialize(reader);
    // }
    [XmlRoot(ElementName = "HOTEL_SEARCH_RESPONSE")]
    public class XMLData
    {

        [XmlElement(ElementName = "HOTELS")]
        public HOTELS HOTELS { get; set; }
    }

    [XmlRoot(ElementName = "HOTELS")]
    public class HOTELS
    {

        [XmlElement(ElementName = "HOTEL")]
        public List<HOTEL> HOTEL { get; set; }
    }

    [XmlRoot(ElementName = "HOTEL")]
    public class HOTEL : BaseEntity<HOTEL>
    {

        [XmlAttribute(AttributeName = "HOTEL_ID")]
        public int HOTELID { get; set; }

        [XmlAttribute(AttributeName = "HOTEL_NAME")]
        public string HOTELNAME { get; set; }

        [XmlAttribute(AttributeName = "LOCATION")]
        public string LOCATION { get; set; }

        [XmlAttribute(AttributeName = "RATING")]
        public string RATING { get; set; }

        [XmlAttribute(AttributeName = "AVAILABLE")]
        public string AVAILABLE { get; set; } 
    
        [XmlAttribute(AttributeName = "ISRECOMMENDEDPRODUCT")]
        public int ISRECOMMENDEDPRODUCT { get; set; }

        [XmlAttribute(AttributeName = "STARTING_PRICE")]
        public double STARTINGPRICE { get; set; }

        [XmlAttribute(AttributeName = "CURRENCY")]
        public string CURRENCY { get; set; }

        [XmlText]
        public string Text { get; set; }

        [XmlElement(ElementName = "ROOMS")]
        public ROOMS ROOMS { get; set; }

        public override void Copy(HOTEL obj)
        {
            throw new NotImplementedException();
        }

        public override bool Equal(HOTEL obj)
        {
            throw new NotImplementedException();
        }

        public int GetRating() 
        {
            int _rating = 0;
            for (int i=0; i<RATING.Length; i++) {
                char ch = RATING.ElementAt(i);
                if (Char.IsDigit(ch)) {
                    _rating = (int)Char.GetNumericValue(ch);
                }
            }
            return _rating;
        }

        public bool IsReady() {
            return AVAILABLE.ToLower() == "yes";
        }

        public List<ResponseRoom> GetRooms() {
            List<ResponseRoom> returnedList = new List<ResponseRoom>();
            foreach (var obj in this.ROOMS.ROOM)
            {
                returnedList.Add(new ResponseRoom(obj.ROOMID+"", obj.ROOMNAME, obj.OCCUPANCY, obj.GetStatus()));
            }
            return returnedList;
        }

        public override string ToString()
        {
            return $"HOTELID: {HOTELID}, HOTELNAME: {HOTELNAME}, LOCATION: {LOCATION}, RATING: {RATING}, AVAILABLE: {AVAILABLE}, " + 
                $"ISRECOMMENDEDPRODUCT: {ISRECOMMENDEDPRODUCT}, STARTINGPRICE: {STARTINGPRICE}, CURRENCY: {CURRENCY}, " +
                $"ROOMS: {ROOMS.ROOM.Count}";
        }

    }

    [XmlRoot(ElementName = "ROOMS")]
    public class ROOMS
    {

        [XmlElement(ElementName = "ROOM")]
        public List<XMLROOM> ROOM { get; set; }
    }

    [XmlRoot(ElementName = "ROOM")]
    public class XMLROOM : BaseEntity<XMLROOM>
    {

        [XmlElement(ElementName = "ROOMID")]
        public int ROOMID { get; set; }

        [XmlElement(ElementName = "ROOM_NAME")]
        public string ROOMNAME { get; set; }

        [XmlElement(ElementName = "OCCUPANCY")]
        public int OCCUPANCY { get; set; }

        [XmlElement(ElementName = "ROOM_STATUS")]
        public string ROOMSTATUS { get; set; }

        [XmlElement(ElementName = "RULE_TEXT")]
        public string RULETEXT { get; set; }

        public bool GetStatus() {
            return this.ROOMSTATUS == "AVAILABLE";
        }

        public override void Copy(XMLROOM obj)
        {
            throw new NotImplementedException();
        }

        public override bool Equal(XMLROOM obj)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"ROOMID: {ROOMID}, ROOMNAME: {ROOMNAME}, OCCUPANCY: {OCCUPANCY}, ROOMSTATUS: {ROOMSTATUS}, RULETEXT: {RULETEXT}.";
        }
    }

}
