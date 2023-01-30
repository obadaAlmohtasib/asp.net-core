using Newtonsoft.Json;

namespace TrackingApi.Model
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class JSONData
    {
        public AvaliabilitiesResponse avaliabilitiesResponse { get; set; }
    }

    public class AvaliabilitiesResponse
    {
        public Hotels Hotels { get; set; }
    }

    public class Hotels
    {
        public List<Hotel> Hotel { get; set; }
    }

    public class Hotel : BaseEntity<Hotel>
    {
        string hotelCode;
        string hotelsName;
        string location;
        int rating;
        int lowestPrice;
        string currency;
        bool isReady;

        public string HotelCode { get => hotelCode; set => hotelCode = value; }
        public string HotelsName { get => hotelsName; set => hotelsName = value; }
        public string Location { get => location; set => location = value; }
        public int Rating { get => rating; set => rating = value; }
        public int LowestPrice { get => lowestPrice; set => lowestPrice = value; }
        public string Currency { get => currency; set => currency = value; }
        public bool IsReady { get => isReady; set => isReady = value; }

        public AvailableRooms AvailableRooms { get; set; }

        public override void Copy(Hotel obj)
        {
            this.HotelCode = obj.HotelCode;
            this.HotelsName = obj.HotelsName;
            this.Location = obj.Location;
            this.Rating = obj.Rating;
            this.LowestPrice = obj.LowestPrice;
            this.Currency = obj.Currency;
            this.IsReady = obj.IsReady;
            this.AvailableRooms = obj.AvailableRooms;
        }

        public List<ResponseRoom> GetRooms()
        {
            List<ResponseRoom> returnedList = new List<ResponseRoom>();
            foreach (var obj in this.AvailableRooms.AvailableRoom)
            {
                returnedList.Add(new ResponseRoom(obj.RoomCode, obj.RoomName, obj.Occupancy, obj.Status));
            }
            return returnedList;
        }

        public override bool Equal(Hotel obj)
        {
            return this.HotelCode == obj.HotelCode;
        }

        public override string ToString()
        {
            return $"HotelCode: {HotelCode}, HotelsName: {HotelsName}, Location: {Location}, Rating: {Rating}, " +
                $"LowestPrice: {LowestPrice}, Currency: {Currency}, IsReady: {IsReady}, " +
                $"AvailableRooms: {AvailableRooms.AvailableRoom.Count}";
        }
    }

    public class AvailableRooms
    {
        [JsonProperty("AvailableRoom")]
        public List<JSONRoom> AvailableRoom { get; set; }
    }

    public class JSONRoom : BaseEntity<JSONRoom>
    {
        string roomCode;
        string roomName;
        int occupancy;
        bool status;

        public string RoomCode { get => roomCode; set => roomCode = value; }
        public string RoomName { get => roomName; set => roomName = value; }
        public int Occupancy { get => occupancy; set => occupancy = value; }
        public bool Status { get => status; set => status = value; }

        public override void Copy(JSONRoom obj)
        {
            this.RoomCode = obj.RoomCode;
            this.RoomName = obj.RoomName;
            this.Occupancy = obj.Occupancy;
            this.Status = obj.Status;
        }

        public override bool Equal(JSONRoom obj)
        {
            return this.RoomCode == obj.RoomCode;
        }

        public override string ToString()
        {
            return $"RoomCode: {RoomCode}, RoomName: {RoomName}, Occupancy: {Occupancy}, Status: {Status}.";
        }
    }

}
