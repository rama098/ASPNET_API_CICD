using Microsoft.AspNetCore.Mvc;
using WebApiNewTemp.Model;
namespace WebApiNewTemp.Controllers
{
    public class FileUploadController : Controller
    {
        public readonly FileUploadContext _context;
        public FileUploadController(FileUploadContext context)
        {
            this._context = context;
        }
        [HttpPost("upload")]
        public IActionResult Upload(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file uploaded");

            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            var filePath = Path.Combine(folderPath, file.FileName);
            using (var stream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                file.CopyTo(stream);
            }
            var fileUpload = new FileUpload
            {
                FileName = file.FileName
            };
            _context.Files.Add(fileUpload);
            _context.SaveChanges();
            return Ok(new { message = "File uploaded successfully" });
        }
        [HttpGet("download/{fileName}")]
        public IActionResult Download(string fileName)
        {
            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
            var filePath = Path.Combine(folderPath, fileName);
            if (!System.IO.File.Exists(filePath))
                return NotFound("File not found");
            var fileBytes = System.IO.File.ReadAllBytes(filePath);
            var contentType = "application/octet-stream";
            return File(fileBytes, contentType, fileName);
        }
        [HttpGet("View")]
        public IActionResult ViewFiles()
        {
            var files = _context.Files.ToList();
            return Ok(files);
        }
    }   
}