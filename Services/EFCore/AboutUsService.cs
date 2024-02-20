using AutoMapper;
using Entities.Models;
using Entities.ModelsDto;
using Repositories.Contracts;
using Services.Contracts;

namespace Services.EFCore;

public class AboutUsService : IAboutUsService
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public AboutUsService(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public IEnumerable<AboutUsDto> GetAllAboutUs()
    {
        var aboutUsList = _repository.AboutUs.GenericRead(false);
        var aboutUsDtoList = _mapper.Map<IEnumerable<AboutUsDto>>(aboutUsList);
        return aboutUsDtoList;
    }

    public AboutUsDto GetByIdAboutUs(int id)
    {
        var aboutUs = _repository.AboutUs.GetAboutUs(id, false).SingleOrDefault();
        var aboutUsDto = _mapper.Map<AboutUsDto>(aboutUs);
        return aboutUsDto;
    }

    public AboutUsDto CreateAboutUs(AboutUsDto aboutUsDto)
    {
        var entity = _mapper.Map<AboutUs>(aboutUsDto);
        _repository.AboutUs.GenericCreate(entity);
        _repository.Save();
        var createdDto = _mapper.Map<AboutUsDto>(entity);
        return createdDto;
    }

    public void UpdateAboutUs(AboutUsDto aboutUsDto)
    {
        var entity = _repository.AboutUs.GetAboutUs(aboutUsDto.AboutUsId, false).SingleOrDefault();
        if (entity != null)
        {
            _mapper.Map(aboutUsDto, entity);
            _repository.AboutUs.GenericUpdate(entity);
            _repository.Save();
        }
    }

    public void DeleteAboutUs(int id)
    {
        var delAboutUs = _repository.AboutUs.GetAboutUs(id, false).SingleOrDefault();
        if (delAboutUs != null)
        {
            _repository.AboutUs.GenericDelete(delAboutUs);
            _repository.Save();
        }
    }
}


