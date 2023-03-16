namespace Ralelu.Domain.Base.Interface
{
    public interface IAuditEntity
    {
        DateTime CreatedOn { get; }
        DateTime? UpdatedOn { get; }
    }
}
