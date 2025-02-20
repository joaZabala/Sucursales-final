using System.Net;

namespace repasoFinal2daMesa.response
{
    public class ApiResponse<T>
    {
        public T Data { get; set; }
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
        public HttpStatusCode StatusCode { get; set; }

        public ApiResponse()
        {
            Success = true;
            ErrorMessage =  "";
            StatusCode = HttpStatusCode.OK;
        }

        public void SetError(string errorMessage, HttpStatusCode statusCode)
        {
            Success = false;
            ErrorMessage = errorMessage;
            StatusCode = statusCode;
        }
    }
}
