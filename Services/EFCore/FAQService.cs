using AutoMapper;
using Entities.Models;
using Entities.ModelsDto;
using Repositories.Contracts;
using Services.Contracts;

namespace Services.EFCore
{
	public class FAQService : IFAQService
	{
		private readonly IRepositoryManager _repository;
		private readonly IMapper _mapper;

		public FAQService(IRepositoryManager repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		public IEnumerable<FAQDto> GetAllFAQ()
		{
			var faqs = _repository.Faq.GenericRead(false);
			var faqDtos = _mapper.Map<IEnumerable<FAQDto>>(faqs);
			return faqDtos;
		}

		public FAQDto GetByIdFAQ(int id)
		{
			var faq = _repository.Faq.GetFAQ(id, false).SingleOrDefault();
			var faqDto = _mapper.Map<FAQDto>(faq);
			return faqDto;
		}

		public FAQDto CreateFAQ(FAQDto faqDto)
		{
			var faq = _mapper.Map<FAQ>(faqDto);
			_repository.Faq.GenericCreate(faq);
			_repository.Save();
			var createdFaqDto = _mapper.Map<FAQDto>(faq);
			return createdFaqDto;
		}

		public void UpdateFAQ(FAQDto faqDto)
		{
			var updateFaq = _repository.Faq.GetFAQ(faqDto.FAQId, false);
        
			if (updateFaq != null)
			{
				var updatedFaq = _mapper.Map<FAQ>(faqDto);
				_repository.Faq.GenericUpdate(updatedFaq);
				_repository.Save();
			}
		}

		public void DeleteFAQ(int id)
		{
			var delFaq = _repository.Faq.GetFAQ(id, false).SingleOrDefault();
        
			if (delFaq != null)
			{
				_repository.Faq.GenericDelete(delFaq);
				_repository.Save();
			}
		}
	}

}