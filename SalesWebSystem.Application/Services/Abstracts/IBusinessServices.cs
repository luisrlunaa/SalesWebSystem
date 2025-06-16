using SalesWebSystem.Models.Models.DTO.BusinessDTO;

namespace SalesWebSystem.Application.Services.Abstracts
{
    public interface IBusinessServices
    {
        Task<int> LastBoxId();
        Task<BoxDTO> LastBox();
    }
}
