using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ralelu.Domain.Base.Interface;

namespace Ralelu.Domain.Base
{
    public abstract class BaseEntity : IEntityBase, IDeleteEntity, IAuditEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int Id { get; protected set; }
        public bool IsDeleted { get; protected set; }
        public DateTime CreatedOn { get; protected set; }
        public DateTime? UpdatedOn { get; protected set; }
    }
}
