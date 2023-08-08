using System;

namespace API
{
    public class ErrorResponse
    {
        public ErrorResponse(int statuscode, string message = null)
        {
            Statuscode = statuscode;
            this.message = message ?? GitMessageForStatusCode(statuscode);
        }

        public int Statuscode { get; set; }
        public string message { get; set; }

        private string GitMessageForStatusCode(int statuscode)
        {
            return Statuscode switch
            {
                400 => "Bad Request",
                401 => "Authoraization Error",
                404 => "Resource Not Found",
                500 => "ServerError",
                _ => null
            };
        }
    }
}