namespace DicleAcademyV2.Areas.Admin.Controllers
{
    public class FileDelete
    {
        public void DeleteFile(IWebHostEnvironment webHostEnvironment, string image)
        {
            var url = webHostEnvironment.WebRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Images\\");
            string path = Path.Combine(url, image);
            System.IO.File.Delete(path);
        }

    }
}
