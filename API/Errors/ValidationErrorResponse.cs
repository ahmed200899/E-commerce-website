using System.Collections;

namespace API.Errors
{
    public class ValidationErrorResponse : ErrorResponse
    {
        public ValidationErrorResponse() : base(400)
        {
        }
        public IEnumerable Errors { get; set; }
    }
}