namespace API.Errors
{
    public class ExceptionResponse : ErrorResponse
    {
        public ExceptionResponse(int statuscode, string message = null, string details = null) : base(statuscode, message)
        {
            Details = details;
        }
        public string Details { get; set; }
    } 
}