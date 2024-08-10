using Microsoft.AspNetCore.Http;

namespace Films.Core.Application.Services.Archives
{
    public interface ILocalArchiveStorageService
    {
        Task RemoveArchive(string route, string container);
        Task<string> EditArchive(string container, IFormFile archive, string route);
        Task<string> SaveArchive(string container, IFormFile archive);
    }
}
