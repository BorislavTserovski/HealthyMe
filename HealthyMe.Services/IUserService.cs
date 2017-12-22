using HealthyMe.Services.Models;
using System.Threading.Tasks;

namespace HealthyMe.Services
{
    public interface IUserService
    {
        Task<UserWithProductsServiceModel> MyProducts(string userId);

        Task ClearFoodAndDrinksList(string userId);

        Task SendMessage(string userId, string content);
    }
}