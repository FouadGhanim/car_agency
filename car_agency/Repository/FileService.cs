namespace car_agency.Repository
{
	public class FileService : IFileService
	{
		public async Task<string> SaveFileAsync(IFormFile file, string folderPath)
		{
			if (file == null || file.Length == 0)
			{
				throw new ArgumentException("Invalid file");
			}

			// Generate a unique file name
			var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

			// Combine folder path and file name
			var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", folderPath, fileName);

			// Ensure directory exists
			Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", folderPath));

			// Save the file
			using (var stream = new FileStream(filePath, FileMode.Create))
			{
				await file.CopyToAsync(stream);
			}

			// Return the relative path for storage in the database
			return $"/{folderPath}/{fileName}";
		}
	}
}
