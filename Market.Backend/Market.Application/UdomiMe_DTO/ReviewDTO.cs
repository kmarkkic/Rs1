namespace Market.Application.UdomiMe_DTO
{
    public class ReviewDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ShelterId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
    }

    public class ReviewCreateDTO
    {
        public int UserId { get; set; }
        public int ShelterId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
    }
}
