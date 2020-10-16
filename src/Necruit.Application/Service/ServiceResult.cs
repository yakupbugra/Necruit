using System;
using System.Collections.Generic;

namespace Necruit.Application.Service
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

    public class PagedResult<T>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int TotalRecords { get; set; }
        public List<T> Data { get; set; }
        public string NextPage { get; set; }

        public PagedResult(List<T> data, int pageNumber, int pageSize, int count)
        {
            this.PageNumber = pageNumber;
            this.PageSize = pageSize;
            this.Data = data;
            this.TotalRecords = count;
            this.TotalPages = Convert.ToInt32(Math.Ceiling((double)count / (double)pageSize));
        }
    }
}