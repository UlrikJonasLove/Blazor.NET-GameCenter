using System.Threading.Tasks;

namespace gamecenter.Server.Helpers.Interface
{
    public interface IFileStorageService 
    {
        Task<string> SaveFile(byte[] content, string extension, string containerName);
        Task DeleteFile(string fileRoute, string containerName);
        Task<string> EditFile(byte[] content, string extension, string containerName, string fileRoute);
    }
}