using Entities.ModelsDto;

namespace Services.Contracts;

public interface IStudentsSayService
{
    IEnumerable<StudentsSayDto> GetAllStudentsSay();
    StudentsSayDto GetByIdStudentsSay(int id);
    StudentsSayDto CreateStudentsSay(StudentsSayDto studentsSayDto);
    void UpdateStudentsSay(StudentsSayDto studentsSayDto);
    void DeleteStudentsSay(int id);
}