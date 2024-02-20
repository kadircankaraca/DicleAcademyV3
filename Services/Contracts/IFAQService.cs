using System.Collections;
using Entities.ModelsDto;

namespace Services.Contracts
{
	public interface IFAQService
	{
		IEnumerable<FAQDto> GetAllFAQ();
		FAQDto GetByIdFAQ(int id);
		FAQDto CreateFAQ(FAQDto faqDto);
		void UpdateFAQ(FAQDto faqDto);
		void DeleteFAQ(int id);
	}
}
