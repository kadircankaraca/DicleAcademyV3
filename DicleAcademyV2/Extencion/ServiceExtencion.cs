using Entities.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Repositories;
using Repositories.Contracts;
using Repositories.EF_Core;
using Services.Abstract;
using Services.Contracts;
using Services.EFCore;
using System.ComponentModel.Design;
using System.Reflection;
using System.Text;

namespace DicleAcademyV2.Extencion
{
    public static class ServiceExtencion
    {
        public static void ConfiguratioSQLContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RepositoryContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("Repositories")));
        }
        public static void ConfiguerRepostoryManager(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryAboutUs, RepositoryAboutUs>();
            services.AddScoped<IRepositoryBestCourses, RepositoryBestCourses>();
            services.AddScoped<IRepositoryContact, RepositoryContact>();
            services.AddScoped<IContactUsService, ContactUsService>();
            services.AddScoped<IRepositoryCourseDetails, RepositoryCourseDetails>();
            services.AddScoped<IRepositoryCourses, RepositoryCourses>();
            services.AddScoped<IRepositoryCoursesCategories, RepositoryCoursesCategories>();
            services.AddScoped<IRepositoryFAQ, RepositoryFAQ>();
            services.AddScoped<IRepositoryGallery, RepositoryGallery>();
            services.AddScoped<IRepositoryGetInTouch, RepositoryGetInTouch>();
            services.AddScoped<IRepositoryHeader, RepositoryHeader>();
            services.AddScoped<IRepositoryInstructors, RepositoryInstructors>();
            services.AddScoped<IRepositorySkills, RepositorySkills>();
            services.AddScoped<IRepositoryStudentsSay, RepositoryStudentsSay>();
            services.AddScoped<IRepositoryUser, RepositoryUser>();
            services.AddScoped<IRepositoryWelcomeInformations, RepositoryWelcomeInformations>();
            services.AddScoped<IRepositoryManager, RepositoryManager>();
            //Repo base entitlere göre düzenlenecek hepsi eklenecek 
            services.AddScoped<IRepositoryBase<User>, RepositoryBase<User>>();
            services.AddScoped<IRepositoryBase<BestCourses>, RepositoryBase<BestCourses>>();
            services.AddScoped<IRepositoryBase<Contact>, RepositoryBase<Contact>>();
            services.AddScoped<IRepositoryBase<CourseDetails>, RepositoryBase<CourseDetails>>();
            services.AddScoped<IRepositoryBase<Courses>, RepositoryBase<Courses>>();
            services.AddScoped<IRepositoryBase<CoursesCategories>, RepositoryBase<CoursesCategories>>();
            services.AddScoped<IRepositoryBase<FAQ>, RepositoryBase<FAQ>>();
            services.AddScoped<IRepositoryBase<Gallery>, RepositoryBase<Gallery>>();
            services.AddScoped<IRepositoryBase<GetInTouch>, RepositoryBase<GetInTouch>>();
            services.AddScoped<IRepositoryBase<Header>, RepositoryBase<Header>>();
            services.AddScoped<IRepositoryBase<Instructors>, RepositoryBase<Instructors>>();
            services.AddScoped<IRepositoryBase<Skills>, RepositoryBase<Skills>>();
            services.AddScoped<IRepositoryBase<StudentsSay>, RepositoryBase<StudentsSay>>();
            services.AddScoped<IRepositoryBase<WelcomeInformations>, RepositoryBase<WelcomeInformations>>();
            //repostory Referanslar
        }
        public static void ConfiguerServiceManager(this IServiceCollection services)
        { // service referanslar

            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();


            services.AddScoped<IAboutUsService, AboutUsService>();
            services.AddScoped<Services.Contracts.IAuthenticationService, Services.EFCore.AuthenticationService>();
            services.AddScoped<IBestCoursesService, BestCoursesService>();
            services.AddScoped<IContactService, ContactService>();
            services.AddScoped<ICourseDetailsService, CourseDetailsService>();
            services.AddScoped<ICoursesCategoriesService, CoursesCategoriesService>();
            services.AddScoped<ICoursesService, CoursesService>();
            services.AddScoped<IFAQService, FAQService>();
            services.AddScoped<IGalleryService, GalleryService>();
            services.AddScoped<IGetInTouchService, GetInTouchService>();
            services.AddScoped<IHeaderService, HeaderService>();
            services.AddScoped<IInstructorsService, InstructorsService>();
            services.AddScoped<IServiceManager, ServiceManager>();
            services.AddScoped<ISkillsService, SkillsService>();
            services.AddScoped<IStudentsSayService, StudentsSayService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IWelcomeInformationsService, WelcomeInformationsService>();

        }
        public static void ConfigureIdentity(this IServiceCollection services)
        {
            var builder = services.AddIdentity<User, IdentityRole>
                (
                    opts =>
                    {
                        opts.Password.RequireDigit = true;
                        opts.Password.RequireLowercase = true;
                        opts.Password.RequireUppercase = true;
                        opts.Password.RequireNonAlphanumeric = true;
                        opts.Password.RequiredLength = 8;

                        opts.User.RequireUniqueEmail = true;

                    }
                ).AddEntityFrameworkStores<RepositoryContext>()
                .AddDefaultTokenProviders();
        }
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }

        public static void ConfigureJWT(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtSettings = configuration.GetSection("JwtSettings"); //appsettingsteki istenilen tagı okumaya yarar
            var secretKey = jwtSettings["SecretKey"];
            //Tokenlarda hassas veriler hiçbir şekilde yer almamalıdır //userName, password, eMail, phoneNumber etc
            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings["ValidateIssue"],
                    ValidAudience = jwtSettings["ValidateAudience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
                }
            );
        }


    }
}
