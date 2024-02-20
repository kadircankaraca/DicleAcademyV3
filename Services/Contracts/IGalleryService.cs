using System.Collections;
using Entities.ModelsDto;

namespace Services.Contracts
{
	public interface IGalleryService
	{
		IEnumerable<GalleryDto> GetAllGallery();
		GalleryDto GetByIdGallery(int id);
		GalleryDto CreateGallery(GalleryDto galleryDto);
		void UpdateGallery(GalleryDto galleryDto);
		void DeleteGallery(int id);
	}
}
