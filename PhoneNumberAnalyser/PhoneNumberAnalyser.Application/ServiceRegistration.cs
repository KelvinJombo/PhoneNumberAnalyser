using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using PhoneNumberAnalyser.Application.Interfaces.IServices;
using PhoneNumberAnalyser.Application.Services;
using PhoneNumberAnalyser.Application.Validation;
using PhoneNumberAnalyser.Commons.Utilities;

namespace PhoneNumberAnalyser.Application
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddFluentValidation();
            services.AddValidatorsFromAssemblyContaining<PhoneNumberRequestValidator>();
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = context =>
                {
                    var errors = context.ModelState
                        .Where(x => x.Value.Errors.Any())
                        .SelectMany(x => x.Value.Errors)
                        .Select(e => string.IsNullOrWhiteSpace(e.ErrorMessage)
                            ? "Invalid input"
                            : e.ErrorMessage)
                        .ToList();

                    var response = Response<object>.Failure(
                        message: ResponseMessages.ValidationFailed,
                        statusCode: PhoneNumberAnalyser.Commons.Utilities.StatusCodes.BadRequest,
                        errors: errors
                    );

                    return new BadRequestObjectResult(response);
                };
            });
            services.AddScoped<IDecoderService, DecoderService>();
            return services;
        }
    }
}
