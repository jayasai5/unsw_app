using System.Threading.Tasks;
using System.Security.Claims;

namespace unsw_app.Auth
{
 public interface IJwtFactory
    {
        Task<string> GenerateEncodedToken(string userName, ClaimsIdentity identity);
        ClaimsIdentity GenerateClaimsIdentity(string userName,string id,bool admin);
    }
}