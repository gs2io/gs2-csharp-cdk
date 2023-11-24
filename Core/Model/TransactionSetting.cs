using System.Collections.Generic;

namespace Gs2Cdk.Core.Model
{
    public class TransactionSetting
    {
        private readonly string _distributorNamespaceId;
        private readonly string _queueNamespaceId;

        public TransactionSetting(
            TransactionSettingOptions options = null
        ) {
            this._distributorNamespaceId = options?.distributorNamespaceId;
            this._queueNamespaceId = options?.queueNamespaceId;
        }

        public Dictionary<string, object> Properties() {
            var properties = new Dictionary<string, object>();
            properties["EnableAutoRun"] = true;
            if (this._distributorNamespaceId != null) {
                properties["DistributorNamespaceId"] = this._distributorNamespaceId;
            }
            if (this._queueNamespaceId != null) {
                properties["QueueNamespaceId"] = this._queueNamespaceId;
            }
            return properties;
        }
        
        public static TransactionSetting FromProperties(
            Dictionary<string, object> properties
        ) {
            var model = new TransactionSetting(
                new TransactionSettingOptions {
                    distributorNamespaceId = properties.TryGetValue("distributorNamespaceId", out var distributorNamespaceId) ? (string)distributorNamespaceId : null,
                    queueNamespaceId = properties.TryGetValue("queueNamespaceId", out var queueNamespaceId) ? (string)queueNamespaceId : null,
                }
            );
            return model;
        }
    }
}