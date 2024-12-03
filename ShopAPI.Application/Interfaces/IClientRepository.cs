using ShopAPI.Application.DTOs;

namespace ShopAPI.Application.Interfaces;
public interface IClientRepository
{
    Task<IEnumerable<ClientBirthdayDto>> GetBirthdayClientsAsync(DateTime date);
    Task<IEnumerable<ClientLastPurchaseDto>> GetRecentBuyersAsync(int days);
    Task<IEnumerable<ClientCategoryDto>> GetClientCategoriesAsync(int clientId);
}

