namespace Market.Application.UdomiMe_DTO
{
    public class AnimalHealthRecordDTO
    {
        public int Id { get; set; }
        public int AnimalId { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string VetName { get; set; }
    }

    public class AnimalHealthRecordCreateDTO
    {
        public int AnimalId { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string VetName { get; set; }
    }
}
