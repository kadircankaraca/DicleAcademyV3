using AutoMapper;
using Entities.Models;
using Entities.ModelsDto;
using Repositories.Contracts;
using Services.Contracts;

namespace Services.EFCore;

public class StudentsSayService : IStudentsSayService
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public StudentsSayService(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public IEnumerable<StudentsSayDto> GetAllStudentsSay()
    {
        var studentsSays = _repository.StudentsSay.GenericRead(false);
        return _mapper.Map<IEnumerable<StudentsSayDto>>(studentsSays);
    }

    public StudentsSayDto GetByIdStudentsSay(int id)
    {
        var studentsSay = _repository.StudentsSay.GetStudentsSay(id, false);
        return _mapper.Map<StudentsSayDto>(studentsSay);
    }

    public StudentsSayDto CreateStudentsSay(StudentsSayDto studentsSayDto)
    {
        var studentsSay = _mapper.Map<StudentsSay>(studentsSayDto);
        _repository.StudentsSay.GenericCreate(studentsSay);
        _repository.Save();
        return _mapper.Map<StudentsSayDto>(studentsSay);
    }

    public void UpdateStudentsSay(StudentsSayDto studentsSayDto)
    {
        var studentsSay = _repository.StudentsSay.GetStudentsSay(studentsSayDto.StudentsSayId, false).SingleOrDefault();
        if (studentsSay != null)
        {
            var updatedStudentsSay = _mapper.Map<StudentsSay>(studentsSay);
            _repository.StudentsSay.GenericUpdate(updatedStudentsSay);
            _repository.Save();
        }
    }

    public void DeleteStudentsSay(int id)
    {
        var studentsSay = _repository.StudentsSay.GetStudentsSay(id, false).SingleOrDefault();
        if (studentsSay != null)
        {
            _repository.StudentsSay.GenericDelete(studentsSay);
            _repository.Save();
        }
    }
}
