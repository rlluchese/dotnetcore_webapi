using Ralelu.WebAPI.Arguments.In.User;
using Ralelu.WebAPI.Arguments.Out.User;

namespace Ralelu.WebAPI.Services.Interfaces
{
    public interface IUserService
    {
        IEnumerable<UserOut> GetAll();
        UserOut GetById(int id);
        UserOut Create(UserCreate userCreate);
        UserOut Update(UserCreate userCreate, int id);
        bool Delete(int id);

    }
}
