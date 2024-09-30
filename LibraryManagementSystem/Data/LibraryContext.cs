using LibraryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Data
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {
        }

        // Define DbSets for your entities
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<BookIssue> BookIssues { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Explicitly set IssueId as the primary key
            modelBuilder.Entity<BookIssue>()
                .HasKey(bi => bi.IssueId);

            // Define relationships between BookIssue, Book, and User
            modelBuilder.Entity<BookIssue>()
                .HasOne(bi => bi.Book)
                .WithMany(b => b.BookIssues)
                .HasForeignKey(bi => bi.BookId);

            modelBuilder.Entity<BookIssue>()
                .HasOne(bi => bi.User)
                .WithMany(u => u.BookIssues)
                .HasForeignKey(bi => bi.UserId);
        }


    }
}
