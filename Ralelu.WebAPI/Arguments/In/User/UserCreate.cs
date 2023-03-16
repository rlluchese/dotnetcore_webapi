using Newtonsoft.Json;

namespace Ralelu.WebAPI.Arguments.In.User
{
    public class UserCreate
    {
        // Binding Json attribute with C# field by annotations using Newtonsoft.Json
        [JsonProperty("name")]
        public string Name { get; private set; }

        // Bind occurs directly, as the field has the same name as the json attribute
        public string email { get; private set; }

        public UserCreate(string name, string email)
        {
            Name = name;
            this.email = email;
        }
    }
}
