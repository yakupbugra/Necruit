using System;

namespace Necurit.Application
{
    public class ServiceResult
    {
        public ServiceResult()
        {
            this.Success = true;
        }

        public bool Success { get; set; }
        public string Message { get; set; }

        public void Fail(Exception ex, string Message)
        {
            this.Success = false;
            this.Message = Message;
        }

        public void Fail(Exception ex)
        {
            this.Success = false;
            this.Message = ex.Message;
        }
    }

    public class ServiceResult<T> : ServiceResult
    {
        public ServiceResult(T Data)
        {
            this.Success = true;
            this.Data = Data;
        }

        public ServiceResult()
        {
            this.Success = true;
        }

        public T Data { get; set; }
    }
}