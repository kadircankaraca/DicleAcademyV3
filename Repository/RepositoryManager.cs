using Repositories.Contracts;
using Repositories.EF_Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _context;
        private readonly Lazy<IRepositoryAboutUs> _repositoryAboutUs;
        private readonly Lazy<IRepositoryUser> _repositoryUser;
        private readonly Lazy<IRepositoryBestCourses> _repositoryBestCourses;
        private readonly Lazy<IRepositoryContact> _repositoryContact;
        private readonly Lazy<IRepositoryCourseDetails> _repositoryCourseDetails;
        private readonly Lazy<IRepositoryCourses> _repositoryCourses;
        private readonly Lazy<IRepositoryCoursesCategories> _repositoryCoursesCategories;
        private readonly Lazy<IRepositoryFAQ> _repositoryFAQ;
        private readonly Lazy<IRepositoryGallery> _repositoryGallery;
        private readonly Lazy<IRepositoryGetInTouch> _repositoryGetInTouch;
        private readonly Lazy<IRepositoryHeader> _repositoryHeader;
        private readonly Lazy<IRepositoryInstructors> _repositoryInstructors;
        private readonly Lazy<IRepositorySkills> _repositorySkills;
        private readonly Lazy<IRepositoryStudentsSay> _repositoryStudentsSay;
        private readonly Lazy<IRepositoryWelcomeInformations> _repositoryWelcomeInformations;

        public RepositoryManager(RepositoryContext context)
        {
            _context = context;
            _repositoryAboutUs = new Lazy<IRepositoryAboutUs>(() => new RepositoryAboutUs(_context));
            _repositoryUser = new Lazy<IRepositoryUser>(() => new RepositoryUser(_context));
            _repositoryBestCourses = new Lazy<IRepositoryBestCourses>(() => new RepositoryBestCourses(_context));
            _repositoryContact = new Lazy<IRepositoryContact>(() => new RepositoryContact(_context));
            _repositoryCourseDetails = new Lazy<IRepositoryCourseDetails>(() => new RepositoryCourseDetails(_context));
            _repositoryCourses = new Lazy<IRepositoryCourses>(() => new RepositoryCourses(_context));
            _repositoryCoursesCategories = new Lazy<IRepositoryCoursesCategories>(() => new RepositoryCoursesCategories(_context));
            _repositoryFAQ = new Lazy<IRepositoryFAQ>(() => new RepositoryFAQ(_context));
            _repositoryGallery = new Lazy<IRepositoryGallery>(() => new RepositoryGallery(_context));
            _repositoryGetInTouch = new Lazy<IRepositoryGetInTouch>(() => new RepositoryGetInTouch(_context));
            _repositoryHeader = new Lazy<IRepositoryHeader>(() => new RepositoryHeader(_context));
            _repositoryInstructors = new Lazy<IRepositoryInstructors>(() => new RepositoryInstructors(_context));
            _repositorySkills = new Lazy<IRepositorySkills>(() => new RepositorySkills(_context));
            _repositoryStudentsSay = new Lazy<IRepositoryStudentsSay>(() => new RepositoryStudentsSay(_context));
            _repositoryWelcomeInformations = new Lazy<IRepositoryWelcomeInformations>(() => new RepositoryWelcomeInformations(_context));
        }

        public IRepositoryAboutUs AboutUs => _repositoryAboutUs.Value;
        public IRepositoryBestCourses BestCourses => _repositoryBestCourses.Value;
        public IRepositoryContact Contact => _repositoryContact.Value;
        public IRepositoryCourseDetails CourseDetails => _repositoryCourseDetails.Value;
        public IRepositoryCourses Courses => _repositoryCourses.Value;
        public IRepositoryCoursesCategories CoursesCategories => _repositoryCoursesCategories.Value;
        public IRepositoryFAQ Faq => _repositoryFAQ.Value;
        public IRepositoryGallery Gallery => _repositoryGallery.Value;
        public IRepositoryGetInTouch GetInTouch => _repositoryGetInTouch.Value;
        public IRepositoryHeader Header => _repositoryHeader.Value;
        public IRepositoryInstructors Instructors => _repositoryInstructors.Value;
        public IRepositorySkills Skills => _repositorySkills.Value;
        public IRepositoryStudentsSay repositoryStudentsSay => _repositoryStudentsSay.Value;
        public IRepositoryWelcomeInformations WelcomeInformations => _repositoryWelcomeInformations.Value;

        public IRepositoryStudentsSay StudentsSay => _repositoryStudentsSay.Value;

        public IRepositoryUser User => _repositoryUser.Value;

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
