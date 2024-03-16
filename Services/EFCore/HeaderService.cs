using AutoMapper;
using Entities.Models;
using Entities.ModelsDto;
using Repositories.Contracts;
using Services.Contracts;

namespace Services.EFCore;

public class HeaderService : IHeaderService
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public HeaderService(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public List<HeaderDto> GetAllHeader()
    {
        var headers = _repository.Header.GenericRead(false);
            return _mapper.Map<List<HeaderDto>>(headers);
    }

    public HeaderDto GetByIdHeader(int id)
    {
        var header = _repository.Header.GetHeader(id, false).SingleOrDefault();
        return _mapper.Map<HeaderDto>(header);
    }

    public HeaderDto CreateHeader(HeaderDto headerDto)
    {
        var header = _mapper.Map<Header>(headerDto);
        _repository.Header.GenericCreate(header);
        _repository.Save();
        return _mapper.Map<HeaderDto>(header);
    }

    public void UpdateHeader(HeaderDto headerDto)
    {
        var header = _repository.Header.GetHeader(headerDto.HeaderId, false).SingleOrDefault();
        if (header != null)
        {
            _mapper.Map(headerDto, header);
            _repository.Header.GenericUpdate(header);
            _repository.Save();
        }
    }

    public void DeleteHeader(int id)
    {
        var header = _repository.Header.GetHeader(id, false).SingleOrDefault();
        if (header != null)
        {
            _repository.Header.GenericDelete(header);
            _repository.Save();
        }
    }
}
