using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineCourses.Models;
using System.Reflection.Emit;

namespace OnlineCourses.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Videos> Videos { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<UserCourse> UserCourses { get; set; }
        public DbSet<VideoProgress> VideoProgress { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<TeacherProfile> TeacherProfiles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = "admin-role-id",
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Id = "teacher-role-id",
                    Name = "Teacher",
                    NormalizedName = "TEACHER"
                },
                new IdentityRole
                {
                    Id = "user-role-id",
                    Name = "User",
                    NormalizedName = "USER"
                },
            };
            builder.Entity<IdentityRole>().HasData(roles);

            builder.Entity<AppUser>()
                .HasOne(u => u.Teacher)
                .WithOne(t => t.AppUser)
                .HasForeignKey<TeacherProfile>(t => t.AppUserId)
                .IsRequired(false);

            builder.Entity<AppUser>()
                .HasOne(u => u.UserProfile)
                .WithOne(p => p.AppUser)
                .HasForeignKey<UserProfile>(p => p.AppUserId)
                .IsRequired(false);

            builder.Entity<UserCourse>()
                .HasKey(uc => new { uc.UserProfileId, uc.CourseId });
            builder.Entity<VideoProgress>()
            .HasKey(uc => new { uc.UserProfileId, uc.VideosId });
            builder.Entity<Course>()
                .Property(c => c.Price)
                .HasPrecision(18, 2);
        }

    }
}
