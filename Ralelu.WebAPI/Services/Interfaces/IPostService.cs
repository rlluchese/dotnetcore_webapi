using Ralelu.WebAPI.Arguments.In.Post;
using Ralelu.WebAPI.Arguments.Out.Post;

namespace Ralelu.WebAPI.Services.Interfaces
{
    public interface IPostService
    {
        IEnumerable<PostOut> GetAll();
        PostOut GetById(int id);
        PostOut Create(PostCreate postCreate);
    }
}
