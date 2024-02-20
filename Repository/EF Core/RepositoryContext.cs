using Entities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EF_Core
{
    public class RepositoryContext : IdentityDbContext<User>
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<AboutUs> AboutUs { get; set; } // sorgu için giriş nokt.
        public DbSet<BestCourses> BestCourses { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<ContactUs> ContactUs { get; set; }
        public DbSet<CourseDetails> CoursesDetails { get; set; }
        public DbSet<Courses> Courses { get; set; }
        public DbSet<CoursesCategories> CoursesCategories { get; set; }
        public DbSet<FAQ> Faq { get; set; }
        public DbSet<Gallery> Gallery { get; set; }
        public DbSet<GetInTouch> GetInTouch { get; set; }
        public DbSet<Instructors> Instructors { get; set; }
        public DbSet<Skills> Skills { get; set; }
        public DbSet<WelcomeInformations> WelcomeInformations { get; set; }
        public DbSet<StudentsSay> StudentsSay { get; set; }
        public DbSet<Header> Header { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.ApplyConfiguration(new RoleConfiguration()); // oluşturduğumuz config dosyalarını okuyoruz
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); //tüm config dosyalarının hepsini okumak için
        }
    }
}
