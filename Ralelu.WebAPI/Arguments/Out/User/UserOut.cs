using Newtonsoft.Json;

namespace Ralelu.WebAPI.Arguments.Out.User
{
    public class UserOut
    {
        [JsonProperty("id")]
        public int Id { get; private set; }

        [JsonProperty("name")]
        public string Name { get; private set; }

        [JsonProperty("email")]
        public string Email { get; private set; }

        [JsonProperty("createdOn")]
        public DateTime CreatedOn { get; private set; }

        [JsonProperty("updatedOn")]
        public DateTime? UpdatedOn { get; private set; }

        public UserOut(Domain.Entity.User user)
        {
            Id = user.Id;
            Name = user.Name;
            Email = user.Email;
            CreatedOn = user.CreatedOn;
            UpdatedOn = user.UpdatedOn;
        }

        public static explicit operator UserOut(Domain.Entity.User users)
        {
            return new UserOut(users);
        }
    }
}
