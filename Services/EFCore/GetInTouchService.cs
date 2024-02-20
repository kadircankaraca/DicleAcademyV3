using AutoMapper;
using Entities.Models;
using Entities.ModelsDto;
using Repositories.Contracts;
using Services.Contracts;

namespace Services.EFCore
{
	public class GetInTouchService : IGetInTouchService
	{
		private readonly IRepositoryManager _repository;
		private readonly IMapper _mapper;

		public GetInTouchService(IRepositoryManager repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		public IEnumerable<GetInTouchDto> GetAllGetInTouch()
		{
			var getInTouchEntities = _repository.GetInTouch.GenericRead(false);
			var getInTouchDtos = _mapper.Map<IEnumerable<GetInTouchDto>>(getInTouchEntities);
			return getInTouchDtos;
		}

		public GetInTouchDto GetByIdGetInTouch(int id)
		{
			var getInTouchEntity = _repository.GetInTouch.GetGetInTouch(id, false);
			var getInTouchDto = _mapper.Map<GetInTouchDto>(getInTouchEntity);
			return getInTouchDto;
		}

		public GetInTouchDto CreateGetInTouch(GetInTouchDto getInTouchDto)
		{
			var getInTouchEntity = _mapper.Map<GetInTouch>(getInTouchDto);
			_repository.GetInTouch.GenericCreate(getInTouchEntity);
			_repository.Save();
			var createdDto = _mapper.Map<GetInTouchDto>(getInTouchEntity);
			return createdDto;
		}

		public void UpdateGetInTouch(GetInTouchDto getInTouchDto)
		{
			var updateGetInTouch = _repository.GetInTouch
				.GetGetInTouch(getInTouchDto.GetInTouchId, false).SingleOrDefault();
			if (updateGetInTouch!= null)
			{
				var updatedGetInTouch = _mapper.Map<GetInTouch>(updateGetInTouch);
				_repository.GetInTouch.GenericUpdate(updatedGetInTouch);
				_repository.Save();
			}
		}

		public void DeleteGetInTouch(int id)
		{
			var delGetInTouch = _repository.GetInTouch
				.GetGetInTouch(id, false).SingleOrDefault();
			if (delGetInTouch != null)
			{
				_repository.GetInTouch.GenericDelete(delGetInTouch);
				_repository.Save();
			}
		}

	}

}
