using SalesWebSystem.Application.Services.Abstracts;
using SalesWebSystem.Infrastructure.Repositories.Abstracts;
using SalesWebSystem.Models.Models.DTO.BusinessDTO;

namespace SalesWebSystem.Application.Services
{
    public class BusinessServices : IBusinessServices
    {
        private readonly IBusinessRepositories _businessRepositories;

        public BusinessServices(IBusinessRepositories businessRepositories)
        {
            _businessRepositories = businessRepositories;
        }

        public async Task<int> LastBoxId()
        {
            var box = await _businessRepositories.LastBox();
            if (box is null || box.id_caja <= 0)
                return 0;
            else 
                return box.id_caja;
        }

        public async Task<BoxDTO> LastBox()
        {
            var box = await _businessRepositories.LastBox();
            if (box is null)
                return new BoxDTO();
            else
                return new BoxDTO() { Id = box.id_caja, Actual = box.montoactual, Date = box.fecha, Final = box.monto_final, Initial = box.monto_inicial};
        }
    }
}
