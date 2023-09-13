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
                {"key", key},
                {"value", value},
            };
        }

        public static Config FromProperties(
            Dictionary<string, object> properties
        ) {
            var model = new Config(
                properties["key"] as string,
                properties["value"] as string
            );

            return model;
        }
    }
}