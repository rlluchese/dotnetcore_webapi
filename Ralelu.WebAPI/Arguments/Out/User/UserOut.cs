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
    }
}
