using System.Collections.Generic;

namespace Gs2Cdk.Core.Model
{
    public class Config
    {
        string key;
        string value;

        public Config(
            string key,
            string value
        ) {
            this.key = key;
            this.value = value;
        }

        public Dictionary<string, object> Properties() {
            return new Dictionary<string, object>() {
                {"Key", key},
                {"Value", value},
            };
        }
    }
}