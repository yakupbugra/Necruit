namespace Necurit.Application.Data.Request
{
    public class CreateJobRequest
    {
        public string Title { get; set; }
        public string Definition { get; set; }
        public int Quantity { get; set; }
        public int UserId { get; set; }
    }
}