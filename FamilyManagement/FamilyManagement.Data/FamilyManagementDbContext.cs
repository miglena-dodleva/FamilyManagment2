using FamilyManagement.Data.Entities;
using FamilyManagement.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace FamilyManagement.Data
{
    public class FamilyManagementDbContext : DbContext
    {
        public FamilyManagementDbContext(DbContextOptions<FamilyManagementDbContext> options)
           : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Entities.Task>()
                .HasOne(t => t.Owner)
                .WithMany()
                .HasForeignKey(t => t.OwnerId)
                .OnDelete(DeleteBehavior.ClientNoAction);

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Family> Families { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Calendar> Calendars { get; set; }
        public DbSet<ToDoList> ToDoLists { get; set; }
        public DbSet<Entities.Task> Tasks { get; set; }
        public DbSet<CalendarToUser> CalendarToUsers { get; set; }
        public DbSet<CalendarToFamily> CalendarToFamilies { get; set; }
        public DbSet<UserToToDoList> UserToToDoLists { get; set; }
        public DbSet<UserToFamily> UserToFamilies { get; set; }
        public DbSet<JwtToken> JwtTokens { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
    }
}
