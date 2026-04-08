using PhoneNumberAnalyser.Domain.Models;

namespace PhoneNumberAnalyser.Application.Interfaces.IRepository
{
    public interface IDataSource
    {
        Country? FindCountryByCode(string prefix);
        List<CountryDetails> FindDetailsByCountryId(int id);
    }
}
