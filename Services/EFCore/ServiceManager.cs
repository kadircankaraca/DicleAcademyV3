using System;
using System.Data;
using AutoMapper;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Repositories.Contracts;
using Services.Abstract;
using Services.Contracts;
using Services.EFCore;

namespace Services.Contracts
{
    public class ServiceManager : IServiceManager
    {
        // Lazy bir nesnenin yaratılmasını ve başlaması gerektiği zamanı belirler.
        // Oluşturulan nesneyi ihtiyaç duyduğunda çalıştırır.
        private readonly Lazy<IAboutUsService> _about;
        private readonly Lazy<IBestCoursesService> _bestCourses;
        private readonly Lazy<IContactService> _contact;
        private readonly Lazy<ICourseDetailsService> _courseDetails;
        private readonly Lazy<ICoursesCategoriesService> _coursesCategories;
        private readonly Lazy<ICoursesService> _courses;
        private readonly Lazy<IFAQService> _fAQ;
        private readonly Lazy<IGalleryService> _gallery;
        private readonly Lazy<IGetInTouchService> _getInTouch;
        private readonly Lazy<IInstructorsService> _instructors;
        private readonly Lazy<ISkillsService> _skills;
        private readonly Lazy<IHeaderService> _header;
        private readonly Lazy<IWelcomeInformationsService> _welcomeInformations;
        private readonly Lazy<IAuthenticationService> _authentication;
        private readonly Lazy<IUserService> _user;
        private readonly IConfiguration _configuration;
        private readonly IUserService _userManager;

        public ServiceManager(IRepositoryManager repository, IMapper mapper, Microsoft.AspNetCore.Identity.UserManager<User> userManager, IConfiguration configuration)
        {
            // Servislerin tembel yükleme nesnelerinin oluşturulması
            _about = new Lazy<IAboutUsService>(() => new AboutUsService(repository, mapper));
            _bestCourses = new Lazy<IBestCoursesService>(() => new BestCoursesService(repository, mapper));
            _contact = new Lazy<IContactService>(() => new ContactService(repository, mapper));
            _courseDetails = new Lazy<ICourseDetailsService>(() => new CourseDetailsService(repository, mapper));
            _coursesCategories = new Lazy<ICoursesCategoriesService>(() => new CoursesCategoriesService(repository, mapper));
            _courses = new Lazy<ICoursesService>(() => new CoursesService(repository, mapper));
            _fAQ = new Lazy<IFAQService>(() => new FAQService(repository, mapper));
            _gallery = new Lazy<IGalleryService>(() => new GalleryService(repository, mapper));
            _getInTouch = new Lazy<IGetInTouchService>(() => new GetInTouchService(repository, mapper));
            _instructors = new Lazy<IInstructorsService>(() => new InstructorsService(repository, mapper));
            _skills = new Lazy<ISkillsService>(() => new SkillsService(repository, mapper));
            _welcomeInformations = new Lazy<IWelcomeInformationsService>(() => new WelcomeInformationsService(repository, mapper));
            _authentication = new Lazy<IAuthenticationService>(() => new AuthenticationService(mapper, userManager, configuration));
            _user = new Lazy<IUserService>(() => new UserService(repository, mapper));
            _header = new Lazy<IHeaderService>(() => new HeaderService(repository, mapper));
        }

        // AboutUsService servisini döndürür
        public IAboutUsService AboutUsService => _about.Value;

        // BestCoursesService servisini döndürür
        public IBestCoursesService BestCoursesService => _bestCourses.Value;

        // ContactService servisini döndürür
        public IContactService ContactService => _contact.Value;

        // CourseDetailsService servisini döndürür
        public ICourseDetailsService CourseDetailsService => _courseDetails.Value;

        // CoursesCategoriesService servisini döndürür
        public ICoursesCategoriesService CoursesCategoriesService => _coursesCategories.Value;

        // CoursesService servisini döndürür
        public ICoursesService CoursesService => _courses.Value;

        // FAQService servisini döndürür
        public IFAQService FAQService => _fAQ.Value;

        // GalleryService servisini döndürür
        public IGalleryService GalleryService => _gallery.Value;

        // GetInTouchService servisini döndürür
        public IGetInTouchService GetInTouchService => _getInTouch.Value;

        // InstructorsService servisini döndürür
        public IInstructorsService InstructorsService => _instructors.Value;

        // SkillsService servisini döndürür
        public ISkillsService SkillsService => _skills.Value;

        // WelcomeInformationsService servisini döndürür
        public IWelcomeInformationsService WelcomeInformationsService => _welcomeInformations.Value;

        // AuthenticationService servisini döndürür
        public IAuthenticationService AuthenticationService => _authentication.Value;

        // UserService servisini döndürür
        public IUserService UserService => _user.Value;

        public IHeaderService HeaderService => _header.Value;
    }

}

