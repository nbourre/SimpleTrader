using SimplerTrader.Domain;
using SimplerTrader.Domain.Models;
using System.Threading.Tasks;

namespace SimpleTrader.Domain.Services.AuthenticationServices
{


    public interface IAccountService : IDataService<Account>
    {
        Task<Account> GetByEmail(string email);
        Task<Account> GetByUsername(string username);
    }
}
