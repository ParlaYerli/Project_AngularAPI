using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.API.Errors
{
    public class ApiResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public ApiResponse(int statusCode, string message=null)
        {
            this.StatusCode = statusCode;
            this.Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }

        private string GetDefaultMessageForStatusCode(int statusCode)
        {
            string errorMessage = string.Empty;
            switch (statusCode)
            {
                case 400:
                    errorMessage = "A bad request!";
                    break;
                case 401:
                    errorMessage = "Authorized error";
                    break;
                case 404:
                    errorMessage = "Resource not found";
                    break;
                case 500:
                    errorMessage = "Server error";
                    break;
            }
            return errorMessage;
        }
    }
}
