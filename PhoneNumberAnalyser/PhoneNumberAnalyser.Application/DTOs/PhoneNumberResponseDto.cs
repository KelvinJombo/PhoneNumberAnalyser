namespace PhoneNumberAnalyser.Application.DTOs
{
    public class PhoneNumberResponseDto
    {
        public string Number { get; set; }
        public CountryResponseDto Country { get; set; }
    }
}
