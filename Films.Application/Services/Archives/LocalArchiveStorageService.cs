using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;

namespace Films.Core.Application.Services.Archives
{
    public class LocalArchiveStorageService : ILocalArchiveStorageService
    {
        private readonly IWebHostEnvironment _env;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LocalArchiveStorageService(IWebHostEnvironment env, IHttpContextAccessor httpContextAccessor)
        {
            _env = env;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<string> EditArchive(string container, IFormFile archive, string route)
        {
            if (string.IsNullOrEmpty(container))
            {
                throw new ArgumentException($"'{nameof(container)}' cannot be null or empty.", nameof(container));
            }

            if (archive is null)
            {
                throw new ArgumentNullException(nameof(archive));
            }

            if (string.IsNullOrEmpty(route))
            {
                throw new ArgumentException($"'{nameof(route)}' cannot be null or empty.", nameof(route));
            }

            await RemoveArchive(route, container);

            return await SaveArchive(container, archive);
        }

        public Task RemoveArchive(string route, string container)
        {
            if (string.IsNullOrEmpty(route))
            {
                throw new ArgumentException($"'{nameof(route)}' cannot be null or empty.", nameof(route));
            }

            if (string.IsNullOrEmpty(container))
            {
                throw new ArgumentException($"'{nameof(container)}' cannot be null or empty.", nameof(container));
            }

            var archiveName = Path.GetFileName(route);
            var archiveDirectory = Path.Combine(_env.WebRootPath, container, archiveName);

            if (File.Exists(archiveDirectory))
            {
                File.Delete(archiveDirectory);
            }

            return Task.CompletedTask;
        }

        public async Task<string> SaveArchive(string container, IFormFile archive)
        {
            if (string.IsNullOrEmpty(container))
            {
                throw new ArgumentException($"'{nameof(container)}' cannot be null or empty.", nameof(container));
            }

            if (archive is null)
            {
                throw new ArgumentNullException(nameof(archive));
            }

            var archiveExtension = Path.GetExtension(archive.FileName);
            var archiveName = $"{Guid.NewGuid()}{archiveExtension}";
            string folder = Path.Combine(_env.WebRootPath, container);

            if (!Directory.Exists(folder)) 
            {
                Directory.CreateDirectory(folder);
            }

            var route = Path.Combine(folder, archiveName);

            using (var memoryStream = new MemoryStream())
            {
                await archive.CopyToAsync(memoryStream);
                var content = memoryStream.ToArray();
                await File.WriteAllBytesAsync(route, content);
            }

            var currentUrl = $"{_httpContextAccessor.HttpContext.Request.Scheme}" +
                $"://{_httpContextAccessor.HttpContext.Request.Host}";

            var forDbRoute = Path.Combine(currentUrl, container, archiveName)
                .Replace("\\", "/");

            return forDbRoute;
        }
    }
}
