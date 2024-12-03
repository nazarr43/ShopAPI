using ShopAPI.Application.DTOs;
using ShopAPI.Application.Interfaces;
using ShopAPI.Domain.Entities;

namespace ShopAPI.Application.Services;
public class ClientService : IClientService
{
    private readonly IClientRepository _clientRepository;

    public ClientService(IClientRepository clientRepository)
    {
        _clientRepository = clientRepository;
    }
    public Task<IEnumerable<ClientBirthdayDto>> GetBirthdayClientsAsync(DateTime date)
    {
        return _clientRepository.GetBirthdayClientsAsync(date);
    }

    public Task<IEnumerable<ClientLastPurchaseDto>> GetRecentBuyersAsync(int days)
    {
        return _clientRepository.GetRecentBuyersAsync(days);
    }

    public Task<IEnumerable<ClientCategoryDto>> GetClientCategoriesAsync(int clientId)
    {
        return _clientRepository.GetClientCategoriesAsync(clientId);
    }

}

