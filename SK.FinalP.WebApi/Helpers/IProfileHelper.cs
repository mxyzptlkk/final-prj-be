using System.Threading.Tasks;
using SK.FinalP.Domain.Entities;

namespace SK.FinalP.WebApi.Helpers;

public interface IProfileHelper
{
    Task<Adm_User> GetUser();
}