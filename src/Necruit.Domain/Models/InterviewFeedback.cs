namespace Necruit.Domain.Models
{
    public class InterviewFeedback : Entity
    {
        public User User { get; set; }
        public string Comment { get; set; }
        public InterviewRating Rating { get; set; }
        public Interview Interview { get; set; }
    }
}
