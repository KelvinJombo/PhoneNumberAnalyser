using PhoneNumberAnalyser.Application.DTOs;
using PhoneNumberAnalyser.Commons.Utilities;

namespace PhoneNumberAnalyser.Application.Interfaces.IServices
{
    public interface IDecoderService
    {
        Response<PhoneNumberResponseDto> DecodeCountry(string phoneNumber);
    }
}
