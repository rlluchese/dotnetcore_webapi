using Ralelu.Domain.Repository;

namespace Ralelu.Domain
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }

        void Commit();
        void Rollback();
        Task CommitAsync();
        Task RollbackAsync();
    }
}
