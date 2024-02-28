using AutoMapper;
using Entities.Models;
using Entities.ModelsDto;
using Repositories.Contracts;
using Services.Contracts;

namespace Services.EFCore;
public class WelcomeInformationsService : IWelcomeInformationsService
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public WelcomeInformationsService(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public IEnumerable<WelcomeInformationsDto> GetAllWelcomeInformations()
    {
        var welcomeInformations = _repository.WelcomeInformations.GenericRead(false);
        return _mapper.Map<IEnumerable<WelcomeInformationsDto>>(welcomeInformations);
    }

    public WelcomeInformationsDto GetByIdWelcomeInformations(int id)
    {
        var welcomeInformations = _repository.WelcomeInformations.GetWelcomeInformations(id, false).SingleOrDefault();
        return _mapper.Map<WelcomeInformationsDto>(welcomeInformations);
    }

    public WelcomeInformationsDto CreateWelcomeInformations(WelcomeInformationsDto welcomeInformationsDto)
    {
        var welcomeInformations = _mapper.Map<WelcomeInformations>(welcomeInformationsDto);
        _repository.WelcomeInformations.GenericCreate(welcomeInformations);
        _repository.Save();
        return _mapper.Map<WelcomeInformationsDto>(welcomeInformations);
    }

    public void UpdateWelcomeInformations(WelcomeInformationsDto welcomeInformationsDto)
    {
        var welcomeInformations = _repository.WelcomeInformations
            .GetWelcomeInformations(welcomeInformationsDto.WelcomeInformationId, false).SingleOrDefault();
        if (welcomeInformations != null)
        {
            _mapper.Map(welcomeInformationsDto, welcomeInformations);
            _repository.WelcomeInformations.GenericUpdate(welcomeInformations);
            _repository.Save();
        }
    }

    public void DeleteWelcomeInformations(int id)
    {
        var welcomeInformations = _repository.WelcomeInformations
            .GetWelcomeInformations(id, false).SingleOrDefault();
        if (welcomeInformations != null)
        {
            _repository.WelcomeInformations.GenericDelete(welcomeInformations);
            _repository.Save();
        }
    }
}