using AutoMapper;
using Entities.Models;
using Entities.ModelsDto;
using Repositories.Contracts;
using Services.Contracts;

namespace Services.EFCore
{
	public class GalleryService : IGalleryService
	{
		private readonly IRepositoryManager _repository;
		private readonly IMapper _mapper;

		public GalleryService(IRepositoryManager repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		public IEnumerable<GalleryDto> GetAllGallery()
		{
			var galleries = _repository.Gallery.GenericRead(false);
			var galleryDtos = _mapper.Map<IEnumerable<GalleryDto>>(galleries);
			return galleryDtos;
		}

		public GalleryDto GetByIdGallery(int id)
		{
			var gallery = _repository.Gallery.GetGallery(id, false);
			var galleryDto = _mapper.Map<GalleryDto>(gallery);
			return galleryDto;
		}

		public GalleryDto CreateGallery(GalleryDto galleryDto)
		{
			var gallery = _mapper.Map<Gallery>(galleryDto);
			_repository.Gallery.GenericCreate(gallery);
			_repository.Save();
			var createdGalleryDto = _mapper.Map<GalleryDto>(gallery);
			return createdGalleryDto;
		}

		public void UpdateGallery(GalleryDto galleryDto)
		{
			var updateGallery = _repository.Gallery
				.GetGallery(galleryDto.GalleryId, false).SingleOrDefault();
			if (updateGallery != null)
			{
				var updatedGallery = _mapper.Map<Gallery>(galleryDto);
				_repository.Gallery.GenericUpdate(updatedGallery);
				_repository.Save();
			}
		}

		public void DeleteGallery(int id)
		{
			var delGallery = _repository.Gallery.GetGallery(id, false).SingleOrDefault();
        
			if (delGallery != null)
			{
				_repository.Gallery.GenericDelete(delGallery);
				_repository.Save();
			}
		}
	}

}
