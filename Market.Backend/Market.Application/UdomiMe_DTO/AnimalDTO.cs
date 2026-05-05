namespace Market.Application.UdomiMe_DTO
{
    public class AnimalDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }

        // Fizički ID-ovi (bitni za Command/Update)
        public int BreedId { get; set; }
        public int AnimalTypeId { get; set; }
        public int ShelterId { get; set; }
        public int? OwnerId { get; set; }
        public int AnimalStatusId { get; set; } // Dodano prema dijagramu

        // Objekti (bitni za prikaz na frontendu)
        public BreedsDTO Breed { get; set; }
        public AnimalTypesDTO AnimalType { get; set; }
        public ShelterDTO Shelter { get; set; }
        public AnimalStatusDTO AnimalStatus { get; set; } // Dodano za status (npr. "Available")

        // Slike (Obavezno za Angular galeriju)
        public List<AnimalImagesDTO> Images { get; set; } = new List<AnimalImagesDTO>();

        // Logička polja
        public bool IsVaccinated { get; set; }
        public bool IsSterilized { get; set; }
        public bool IsAdopted { get; set; }
    }
}