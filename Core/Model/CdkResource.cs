using System.Collections.Generic;

namespace Gs2Cdk.Core.Model
{
    public abstract class CdkResource
    {
        
        private readonly string _resourceName;
        private readonly List<string> _dependsOn;
        
        public string ResourceName => _resourceName;

        protected CdkResource(
            string resourceName
        ) {
            this._resourceName = resourceName;
            this._dependsOn = new List<string>();
        }

        public CdkResource AddDependsOn(
            CdkResource resource
        ) {
            this._dependsOn.Add(resource._resourceName);
            return this;
        }

        public abstract string ResourceType();
        public abstract Dictionary<string, object> Properties();

        public Dictionary<string, object> Template() {
            return new Dictionary<string, object>() {
                {"Type", ResourceType()},
                {"Properties", Properties()},
                {"DependsOn", this._dependsOn},
            };
        }
    }
}