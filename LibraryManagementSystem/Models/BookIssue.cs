namespace LibraryManagementSystem.Models
{
    public class BookIssue
    {
        public int IssueId { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime? ReturnDate { get; set; }

        public User User { get; set; }
        public Book Book { get; set; }
    }

}
