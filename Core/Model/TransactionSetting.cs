using System.Collections.Generic;

namespace Gs2Cdk.Core.Model
{
    public class TransactionSetting
    {
        private readonly bool _enableAutoRun;
        private readonly string _distributorNamespaceId;
        private readonly string _keyId;
        private readonly string _queueNamespaceId;

        public TransactionSetting(
            bool enableAutoRun,
            string distributorNamespaceId = null,
            string keyId = null,
            string queueNamespaceId = null
        ) {
            this._enableAutoRun = enableAutoRun;
            this._distributorNamespaceId = distributorNamespaceId;
            this._keyId = keyId;
            this._queueNamespaceId = queueNamespaceId;
        }

        public Dictionary<string, object> Properties() {
            return new Dictionary<string, object>() {
                {"EnableAutoRun", _enableAutoRun},
                {"DistributorNamespaceId", _distributorNamespaceId},
                {"KeyId", _keyId},
                {"QueueNamespaceId", _queueNamespaceId},
            };
        }
    }
}