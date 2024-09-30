namespace LibraryManagementSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        [StringLength(13)] // ISBN usually has a length of 13 characters
        public string ISBN { get; set; }

        [Required]
        public DateTime PublishedDate { get; set; }

        [Range(1, int.MaxValue)] // Ensure copies are at least 1
        public int AvailableCopies { get; set; }

        public ICollection<BookIssue> BookIssues { get; set; }
    }
}
