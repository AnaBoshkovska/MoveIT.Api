using MoveIT.Core.Models;
using System.Threading.Tasks;

namespace MoveIT.Core.Services
{
    public interface IAuthService
    {
        public Task<string> Authenticate(string username, string password);
    }
}
