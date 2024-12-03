using ShopAPI.Application.DTOs;
using ShopAPI.Domain.Entities;

namespace ShopAPI.Application.Interfaces;
public interface IClientService
{
    Task<IEnumerable<ClientBirthdayDto>> GetBirthdayClientsAsync(DateTime date);
    Task<IEnumerable<ClientLastPurchaseDto>> GetRecentBuyersAsync(int days);
    Task<IEnumerable<ClientCategoryDto>> GetClientCategoriesAsync(int clientId);
}

