namespace Necruit.Application
{
    public class PageRequest
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public PageRequest()
        {
            this.PageNumber = 1;
            this.PageSize = 10;
        }

        public PageRequest(int pageNumber, int pageSize)
        {
            this.PageNumber = pageNumber < 1 ? 1 : pageNumber;
            this.PageSize = pageSize > 10 ? 10 : (pageSize == 0 ? 10 : pageSize);
        }
    }
}