namespace TrackingApi.Model
{
    public class ResponseObject 
    {
        public static Object Create(List<ResponseHotel> hotels, string message = "") {
            return new { hotels, message };
        }
    }

    public class ResponseHotel
    {
        public string HotelId { get; set; }
        public string HotelName { get; set; }
        public string Location { get; set; }
        public int Rating { get; set; }
        public string Currency { get; set; }
        public double LowestPrice { get; set; }
        public bool IsReady { get; set; }

        public List<ResponseRoom> Rooms { get; set; }

        public ResponseHotel(string HotelId, string HotelName, string Location, int Rating, string Currency, double LowestPrice, bool IsReady, List<ResponseRoom> Rooms)
        {
            this.HotelId = HotelId;
            this.HotelName = HotelName;
            this.Location = Location;
            this.Rating = Rating;
            this.Currency = Currency;
            this.LowestPrice = LowestPrice;
            this.IsReady = IsReady;
            this.Rooms = Rooms;
        }

        public override string ToString()
        {
            return $"HotelCode: {HotelId}, HotelsName: {HotelName}, Location: {Location}, Rating: {Rating}, " +
                $"LowestPrice: {LowestPrice}, Currency: {Currency}, IsReady: {IsReady}, " +
                $"Rooms: {Rooms.Count}"; 
        }

    }

    public class ResponseRoom {
        public string RoomId { get; set; }
        public string RoomName { get; set; }
        public int Occupancy { get; set; }
        public bool Status { get; set; }
        public ResponseRoom(string RoomId, string RoomName, int Occupancy, bool Status)
        {
            this.RoomId = RoomId;
            this.RoomName = RoomName;
            this.Occupancy = Occupancy;
            this.Status = Status;
        }
        public override string ToString()
        {
            return $"RoomCode: {RoomId}, RoomName: {RoomName}, Occupancy: {Occupancy}, Status: {Status}.";
        }
    }
}
