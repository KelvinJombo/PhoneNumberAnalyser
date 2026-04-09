namespace PhoneNumberAnalyser.Commons.Utilities
{
    public static class ResponseMessages
    {
        //General
        public const string Success = "Operation completed successfully";
        public const string Failed = "Operation failed";

        //Controller
        public const string CountryCodeNotFound = "The given CountryCode was not found in our record";
        public const string PhoneDecoded = "Phone number decoded successfully";

        //Validation
        public const string ValidationFailed = "One or more validation errors occurred";       

        //Generic Errors
        public const string ServerError = "An unexpected error occurred";
        public const string BadRequest = "Invalid request";

        
    }
}
