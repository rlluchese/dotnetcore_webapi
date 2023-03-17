using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ralelu.Domain.Base;

namespace Ralelu.Domain.Entity
{
    [Table("User")]
    public class User : BaseEntity
    {
        [Required]
        public string Name { get; private set; }

        [EmailAddress]
        public string Email { get; private set; }

        public ICollection<Post> Posts { get; private set; }

        public User(string name, string email)
        {
            Name = name;
            Email = email;
            Posts = new List<Post>();
            CreatedOn = DateTime.Now;
            UpdatedOn = null;
            IsDeleted = false;
        }

        public void Update(string name, string email)
        {
            Name = name;
            Email = email;
            UpdatedOn = DateTime.Now;
        }
    }
}
