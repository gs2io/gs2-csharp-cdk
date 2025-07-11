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
            this._resources = new List<CdkResource>();
            this._outputs = new Dictionary<string, string>();
        }

        public void AddResource(
            CdkResource resource
        ) {
            this._resources.Add(resource);
        }

        public bool Exists(
            string resourceName
        ) {
            return this._resources.Exists(r => r.ResourceName == resourceName);
        }

        public void Output(
            string name,
            string path
        ) {
            this._outputs[name] = path;
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
            var yaml = serializer.Serialize(Template());
            
            var lines = yaml.Split('\n');
            for (int i = 0; i < lines.Length; i++)
            {
                var line = lines[i];
                if (line.Contains(": \"!") || line.Contains(": '!"))
                {
                    var match = Regex.Match(line, @"^(\s*)(.*?:\s*)['""](![\w:]+\s+.+)['""]$");
                    if (match.Success)
                    {
                        lines[i] = match.Groups[1].Value + match.Groups[2].Value + match.Groups[3].Value;
                    }
                }
            }
            yaml = string.Join("\n", lines);
            
            return yaml;
        }

    }
}