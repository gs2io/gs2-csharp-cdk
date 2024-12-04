using System.Collections.Generic;

namespace Gs2Cdk.Core.Model
{
    public class TransactionSetting
    {
        private readonly bool _enableAtomicCommit;
        private readonly bool _transactionUseDistributor;
        private readonly bool _acquireActionUseJobQueue;
        private readonly string _distributorNamespaceId;
        private readonly string _queueNamespaceId;

        public TransactionSetting(
            TransactionSettingOptions options = null
        ) {
            this._enableAtomicCommit = options?.enableAtomicCommit ?? false;
            this._transactionUseDistributor = options?.transactionUseDistributor ?? false;
            this._acquireActionUseJobQueue = options?.acquireActionUseJobQueue ?? false;
            this._distributorNamespaceId = options?.distributorNamespaceId;
            this._queueNamespaceId = options?.queueNamespaceId;
        }

        public Dictionary<string, object> Properties() {
            var properties = new Dictionary<string, object>();
            properties["EnableAutoRun"] = true;
            if (this._enableAtomicCommit) {
                properties["EnableAtomicCommit"] = this._enableAtomicCommit;
            }
            if (this._transactionUseDistributor) {
                properties["TransactionUseDistributor"] = this._transactionUseDistributor;
            }
            if (this._acquireActionUseJobQueue) {
                properties["AcquireActionUseJobQueue"] = this._acquireActionUseJobQueue;
            }
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
                    enableAtomicCommit = properties.TryGetValue("EnableAtomicCommit", out var enableAtomicCommit) ? (bool?) enableAtomicCommit : null,
                    transactionUseDistributor = properties.TryGetValue("TransactionUseDistributor", out var transactionUseDistributor) ? (bool?) transactionUseDistributor : null,
                    acquireActionUseJobQueue = properties.TryGetValue("AcquireActionUseJobQueue", out var acquireActionUseJobQueue) ? (bool?) acquireActionUseJobQueue : null,
                    distributorNamespaceId = properties.TryGetValue("distributorNamespaceId", out var distributorNamespaceId) ? (string)distributorNamespaceId : null,
                    queueNamespaceId = properties.TryGetValue("queueNamespaceId", out var queueNamespaceId) ? (string)queueNamespaceId : null,
                }
            );
            return model;
        }
    }
}