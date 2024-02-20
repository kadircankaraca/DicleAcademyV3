using AutoMapper;
using Entities.Models;
using Entities.ModelsDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<AboutUsDto, AboutUs>();
            CreateMap<AboutUs, AboutUsDto>();
            CreateMap<BestCoursesDto, BestCourses>();
            CreateMap<BestCourses, BestCoursesDto>();
            CreateMap<ContactDto, Contact>();
            CreateMap<Contact, ContactDto>();
            CreateMap<CourseDetailsDto, CourseDetails>();
            CreateMap<CourseDetails, CourseDetailsDto>();
            CreateMap<CoursesDto, Courses>().ForMember(des => des.CoursesCategories, opt => opt.Ignore());
            CreateMap<Courses, CoursesDto>();
            CreateMap<CoursesCategoriesDto, CoursesCategories>();
            CreateMap<CoursesCategories, CoursesCategoriesDto>();
            CreateMap<FAQDto, FAQ>();
            CreateMap<FAQ, FAQDto>();
            CreateMap<GalleryDto, Gallery>();
            CreateMap<Gallery, GalleryDto>();
            CreateMap<GetInTouchDto, GetInTouch>();
            CreateMap<GetInTouch, GetInTouchDto>();
            CreateMap<HeaderDto, Header>();
            CreateMap<Header, HeaderDto>();
            CreateMap<InstructorsDto, Instructors>();
            CreateMap<Instructors, InstructorsDto>();
            CreateMap<SkillsDto, Skills>();
            CreateMap<Skills, SkillsDto>();
            CreateMap<StudentsSayDto, StudentsSay>();
            CreateMap<StudentsSay, StudentsSayDto>();
            CreateMap<WelcomeInformationsDto, WelcomeInformations>();
            CreateMap<WelcomeInformations, WelcomeInformationsDto>();
            CreateMap<UserForAuthenticationDto, User>();
            CreateMap<User, UserForAuthenticationDto>();


        }
    }
}
