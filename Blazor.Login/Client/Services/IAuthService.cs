using Blazor.Login.Shared.Models;
using System.Threading.Tasks;

namespace Blazor.Login.Client.Services
{
    public interface IAuthService
    {
        Task Login(LoginRequest loginRequest);
        Task Register(RegisterRequest registerRequest);
        Task Logout();
        Task<CurrentUser> CurrentUserInfo();
    }
}
