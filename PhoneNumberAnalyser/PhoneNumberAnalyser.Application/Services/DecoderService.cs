using PhoneNumberAnalyser.Application.DTOs;
using PhoneNumberAnalyser.Application.Interfaces.IRepository;
using PhoneNumberAnalyser.Application.Interfaces.IServices;
using PhoneNumberAnalyser.Commons.Utilities;

namespace PhoneNumberAnalyser.Application.Services
{
    public class DecoderService : IDecoderService
    {
        private readonly IDataSource _dataSource;

        public DecoderService(IDataSource dataSource)
        {
            _dataSource = dataSource;
        }

        public Response<PhoneNumberResponseDto> DecodeCountry(string phoneNumber)
        {
            
            // Extracting prefix safely
            string prefix = phoneNumber.Substring(0, 3);

            //Lookup country in data source
            var country = _dataSource.FindCountryByCode(prefix);

            if (country == null)
            {
                return Response<PhoneNumberResponseDto>.Failure(
                    ResponseMessages.CountryCodeNotFound,
                    StatusCodes.NotFound
                );
            }

            //Build country details
            var details = _dataSource.FindDetailsByCountryId(country.Id)
                .Select(d => new CountryDetailsDto
                {
                    Operator = d.Operator,
                    OperatorCode = d.OperatorCode
                })
                .ToList();

            //Build response DTO
            var responseDto = new PhoneNumberResponseDto
            {
                Number = phoneNumber,
                Country = new CountryResponseDto
                {
                    CountryCode = country.CountryCode,
                    Name = country.Name,
                    CountryIso = country.CountryIso,
                    CountryDetails = details
                }
            };

            //Return success response
            return Response<PhoneNumberResponseDto>.Success(
                responseDto,
                ResponseMessages.Success
            );
        }
    }
}