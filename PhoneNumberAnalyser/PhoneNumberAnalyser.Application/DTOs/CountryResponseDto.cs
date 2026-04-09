namespace PhoneNumberAnalyser.Application.DTOs
{
    public class CountryResponseDto
    {
        public string CountryCode { get; set; }
        public string Name { get; set; }
        public string CountryIso { get; set; }
        public List<CountryDetailsDto> CountryDetails { get; set; } = new List<CountryDetailsDto>();
    }
}
