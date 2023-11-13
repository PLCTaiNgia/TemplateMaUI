using TestContainerAPP.Dto;
using TestContainerAPP.Models;

namespace TestContainerAPP.Services.ContainerService
{
    public interface IContainerService
    {
        Task<List<Container>> GetContainers();
        Task<Container> GetContainerById(string id);
        Task<bool> UpdateContainerAsync(string id, UpdateContainerRequestDto updateContainerRequestDto);
    }
}
