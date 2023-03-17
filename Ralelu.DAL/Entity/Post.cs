using Ralelu.Domain.Base;

namespace Ralelu.Domain.Entity
{
    public class Post : BaseEntity
    {
        public string Title { get; private set; }
        public string Text { get; private set; }

        // RelationShips
        public int UserId { get; private set; }
        public User User { get; private set; }

        // Entity Framework only
        protected Post()
        {

        }

        public Post(string title, string text, User user)
        {
            Title = title;
            Text = text;
            UserId = user.Id;
            User = user;
            CreatedOn = DateTime.Now;
            UpdatedOn = null;
            IsDeleted = false;
        }
    }
}
