using AutoMapper;
using Ralelu.Domain;
using Ralelu.Domain.Entity;
using Ralelu.WebAPI.Arguments.In.Post;
using Ralelu.WebAPI.Arguments.Out.Post;
using Ralelu.WebAPI.Services.Interfaces;

namespace Ralelu.WebAPI.Services
{
    public class PostService : IPostService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PostService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public PostOut Create(PostCreate postCreate)
        {
            User user = _unitOfWork.UserRepository.Get(x => x.Id == postCreate.UserId);

            if (user == null)
            {
                return null;
            }

            Post post = new Post(postCreate.Title, postCreate.Text, user);
            _unitOfWork.PostRepository.Add(post);
            _unitOfWork.Commit();

            return _mapper.Map<PostOut>(post);
        }

        public IEnumerable<PostOut> GetAll()
        {
            return _unitOfWork.PostRepository.GetAllWithUser().Select(x => _mapper.Map<PostOut>(x));
        }

        public PostOut GetById(int id)
        {
            Post post = _unitOfWork.PostRepository.Get(x => x.Id == id);

            if (post == null)
            {
                return null;
            }

            return _mapper.Map<PostOut>(post);
        }
    }
}
