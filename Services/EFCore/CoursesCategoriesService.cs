using AutoMapper;
using Entities.Models;
using Entities.ModelsDto;
using Repositories.Contracts;
using Services.Contracts;

namespace Services.EFCore
{

	public class CoursesCategoriesService : ICoursesCategoriesService
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public CoursesCategoriesService(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    
    public IEnumerable<CoursesCategoriesDto> GetAllCoursesCategories()
    {
        var categories = _repository.CoursesCategories.GenericRead(false);
        var categoriesDto = _mapper.Map<IEnumerable<CoursesCategoriesDto>>(categories);
        return categoriesDto;
    }

    public CoursesCategoriesDto GetByIdCoursesCategories(int id)
    {
        var category = _repository.CoursesCategories.GetCoursesCategories(id, false);
        var categoryDto = _mapper.Map<CoursesCategoriesDto>(category);
        return categoryDto;
    }

    public CoursesCategoriesDto CreateCoursesCategories(CoursesCategoriesDto coursesCategoriesDto)
    {
        var category = _mapper.Map<CoursesCategories>(coursesCategoriesDto);
        _repository.CoursesCategories.GenericCreate(category);
        _repository.Save();
        var createdCategoryDto = _mapper.Map<CoursesCategoriesDto>(category);
        return createdCategoryDto;
    }

    public void UpdateCoursesCategories(CoursesCategoriesDto coursesCategoriesDto)
    {
        var updateCategory = _repository.CoursesCategories
            .GetCoursesCategories(coursesCategoriesDto.CategoryId, false).SingleOrDefault();
        if (updateCategory != null)
        {
            var updatedCategory = _mapper.Map<CoursesCategories>(coursesCategoriesDto);
            _repository.CoursesCategories.GenericUpdate(updatedCategory);
            _repository.Save();
        }
    }

    public void DeleteCoursesCategories(int id)
    {
        var delCategory = _repository.CoursesCategories
            .GetCoursesCategories(id, false).SingleOrDefault();
        if (delCategory != null)
        {
            _repository.CoursesCategories.GenericDelete(delCategory);
            _repository.Save();
        }
    }
}

}
