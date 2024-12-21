namespace car_agency.Repository
{
	public interface IFileService
	{
		Task<string> SaveFileAsync(IFormFile file, string folderPath);
	}
}
