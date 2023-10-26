using System.Collections.Generic;
using System.Text.RegularExpressions;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace Gs2Cdk.Core.Model
{
    public class Stack
    {
        private readonly List<CdkResource> _resources;
        private readonly Dictionary<string, string> _outputs;

        public Stack() {
            _resources = new List<CdkResource>();
            _outputs = new Dictionary<string, string>();
        }

        public void AddResource(
            CdkResource resource
        ) {
            _resources.Add(resource);
        }

        public void Output(
            string name,
            string path
        ) {
            _outputs[name] = path;
        }

        public Dictionary<string, object> Template() {
            var templateResources = new Dictionary<string, object>();
            foreach (var resource in _resources) {
                templateResources[resource.ResourceName] = resource.Template();
            }
            return new Dictionary<string, object>() {
                {"GS2TemplateFormatVersion", "2019-05-01"},
                {"Resources", templateResources},
                {"Outputs", _outputs},
            };
        }

        public string Yaml() {
            var serializer = new SerializerBuilder()
                .DisableAliases()
                .WithQuotingNecessaryStrings()
                .WithNamingConvention(CamelCaseNamingConvention.Instance)
                .Build();
            return new Regex("['\"]!(.*) (.*)['\"]").Replace(serializer.Serialize(Template()), "!$1 $2");
        }

    }
}