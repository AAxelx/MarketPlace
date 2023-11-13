namespace MarketPlace.SAL.Common
{
    public class ServiceResponse<T>
    {
        public T Data { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }

        public ServiceResponse(T data, bool success, string message)
        {
            Data = data;
            Success = success;
            Message = message;
        }

        public ServiceResponse(T data, bool success) : this(data, success, null)
        {
        }

        public ServiceResponse(bool success, string message) : this(default, success, message)
        {
        }

        public ServiceResponse(bool success) : this(default, success, null)
        {
        }
    }

}

