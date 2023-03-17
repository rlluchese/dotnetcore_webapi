using Newtonsoft.Json;
using Ralelu.WebAPI.Arguments.Out.User;

namespace Ralelu.WebAPI.Arguments.Out.Post
{
    public class PostOut
    {
        [JsonProperty("id")]
        public int Id { get; private set; }

        [JsonProperty("name")]
        public string Title { get; private set; }

        [JsonProperty("email")]
        public string Text { get; private set; }

        [JsonProperty("createdOn")]
        public DateTime CreatedOn { get; private set; }

        [JsonProperty("user")]
        public UserOut User { get; private set; }
    }
}
