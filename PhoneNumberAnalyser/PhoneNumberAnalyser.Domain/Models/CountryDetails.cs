namespace PhoneNumberAnalyser.Domain.Models
{
    public class CountryDetails
    {
        public int Id { get; set; }
        public string Operator { get; set; } = string.Empty;
        public string OperatorCode { get; set; } = string.Empty;
        public int CountryId { get; set; } 
        public Country Country { get; set; } = new Country();
    }
}
