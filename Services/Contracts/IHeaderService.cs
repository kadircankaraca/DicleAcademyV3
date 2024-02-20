using System.Collections;
using Entities.Models;
using Entities.ModelsDto;

namespace Services.Contracts;

public interface IHeaderService
{
    List<HeaderDto> GetAllHeader();
    HeaderDto GetByIdHeader(int id);
    HeaderDto CreateHeader(HeaderDto headerDto);
    void UpdateHeader(HeaderDto headerDto);
    void DeleteHeader(int id);
}