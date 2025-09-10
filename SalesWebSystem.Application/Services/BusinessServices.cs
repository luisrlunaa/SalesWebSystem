using SalesWebSystem.Application.Services.Abstracts;
using SalesWebSystem.Infrastructure.Data.Entities;
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

        //Boxes
        public async Task<BoxDTO> CreateBox(BoxDTO input)
        {
            var box = await _businessRepositories.AddBox(MapBoxToCaja(input));
            if (box is null)
                return null;
            else
                return input;
        }

        public async Task<BoxDTO> UpdateBox(BoxDTO input)
        {
            var exist = await _businessRepositories.ExitBoxById(input.Id, input.BusinessId);
            if (!exist)
                return null;

            var box = await _businessRepositories.UpdateBox(MapBoxToCaja(input));
            if (box is null)
                return null;
            else
                return input;
        }

        public async Task<int> LastBoxIdbyBusinessId(int businessId)
        {
            var box = await _businessRepositories.LastBoxIdbusinessId(businessId);
            if (box is null || box.id_caja <= 0)
                return 0;
            else 
                return box.id_caja;
        }

        public async Task<BoxDTO> LastBoxbyBusinessId(int businessId)
        {
            var box = await _businessRepositories.LastBoxIdbusinessId(businessId);
            if (box is null)
                return new BoxDTO();
            else
                return MapCajaToBox(box);
        }

        public async Task<List<BoxDTO>> GetBoxes(int businessId)
        {
            var lst = new List<BoxDTO>();
            var boxes = await _businessRepositories.BoxesBybusinessId(businessId);
            if (boxes is null)
                return lst;
            else
            {
                boxes.ForEach(box => lst.Add(MapCajaToBox(box)));
                return lst;
            } 
        }

        public async Task<bool> DeleteBox(int Id, int businessId)
        {
            var exist = await _businessRepositories.ExitBoxById(Id, businessId);
            if (!exist)
                return false;

            return await _businessRepositories.DeleteBoxById(Id, businessId);
        }

        //Balances
        public async Task<BalanceDTO> CreateBalance(BalanceDTO input)
        {
            var box = await _businessRepositories.AddCashBalance(MapBalanceToCuadre(input));
            if (box is null)
                return null;
            else
                return input;
        }

        public async Task<BalanceDTO> UpdateBalance(BalanceDTO input)
        {
            var exist = await _businessRepositories.ExitCashBalanceById(input.Id, input.BusinessId);
            if (!exist)
                return null;

            var box = await _businessRepositories.UpdateCashBalance(MapBalanceToCuadre(input));
            if (box is null)
                return null;
            else
                return input;
        }

        public async Task<List<BalanceDTO>> GetBalances(int businessId)
        {
            var lst = new List<BalanceDTO>();
            var balances = await _businessRepositories.CashBalanceList(businessId);
            if (balances is null)
                return lst;
            else
            {
                balances.ForEach(balance => lst.Add(MapCuadreToBalance(balance)));
                return lst;
            }
        }

        public async Task<BalanceDTO> BalanceById(int businessId, int Id)
        {
            var result = new BalanceDTO();
            var balance = await _businessRepositories.CashBalanceByIdbusinessId(Id, businessId);
            if (balance is null)
                return result;
            else
                return MapCuadreToBalance(balance);
        }

        public async Task<BalanceDTO> BalanceByDate(int businessId, DateTime date)
        {
            var result = new BalanceDTO();
            var balance = await _businessRepositories.CashBalanceByDatebusinessId(businessId, date);
            if (balance is null)
                return result;
            else
                return MapCuadreToBalance(balance);
        }

        public async Task<bool> DeleteBalance(int Id, int businessId)
        {
            var exist = await _businessRepositories.ExitCashBalanceById(Id, businessId);
            if (!exist)
                return false;

            return await _businessRepositories.DeleteCashBalanceById(Id, businessId);
        }

        #region Helpers
        private BoxDTO MapCajaToBox(Caja box)
        {
            return new BoxDTO() { Id = box.id_caja, Actual = box.montoactual, Date = box.fecha, Final = box.monto_final, Initial = box.monto_inicial, BusinessId = box.id_business };
        }
        private Caja MapBoxToCaja(BoxDTO box)
        {
            return new Caja() { id_caja = box.Id, montoactual = box.Actual, fecha = box.Date, monto_final = box.Final, monto_inicial = box.Initial, id_business = box.BusinessId};
        }

        private BalanceDTO MapCuadreToBalance(Cuadre balance)
        {
            return new BalanceDTO() { Id = balance.id, Description = balance.descripcion, Date = balance.fecha, Amount = balance.monto, BusinessId = balance.id_business };
        }
        private Cuadre MapBalanceToCuadre(BalanceDTO balance)
        {
            return new Cuadre() { id = balance.Id, descripcion = balance.Description, fecha = balance.Date, monto = balance.Amount, id_business = balance.BusinessId };
        }
        #endregion
    }
}