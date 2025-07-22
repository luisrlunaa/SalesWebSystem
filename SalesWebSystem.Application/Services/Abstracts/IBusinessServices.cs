using SalesWebSystem.Models.Models.DTO.BusinessDTO;

namespace SalesWebSystem.Application.Services.Abstracts
{
    public interface IBusinessServices
    {
        //Boxes
        Task<BoxDTO> CreateBox(BoxDTO input);
        Task<BoxDTO> UpdateBox(BoxDTO input);
        Task<int> LastBoxIdbyBusinessId(int businessId);
        Task<BoxDTO> LastBoxbyBusinessId(int businessId);
        Task<List<BoxDTO>> GetBoxes(int businessId);
        Task<bool> DeleteBox(int Id, int businessId);

        //Balances
        Task<BalanceDTO> CreateBalance(BalanceDTO input);
        Task<BalanceDTO> UpdateBalance(BalanceDTO input);
        Task<List<BalanceDTO>> GetBalances(int businessId);
        Task<BalanceDTO> BalanceById(int businessId, int Id);
        Task<BalanceDTO> BalanceByDate(int businessId, DateTime date);
        Task<bool> DeleteBalance(int Id, int businessId);
    }
}