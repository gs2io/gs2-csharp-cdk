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

        public static TransactionSetting TransactionSettingEnableAutoRun(
            string distributorNamespaceId,
            string queueNamespaceId = null
        ) {
            return new TransactionSetting(
                true,
                distributorNamespaceId,
                null,
                queueNamespaceId
            );
        }

        public static TransactionSetting TransactionSettingDisableAutoRun(
            string keyId,
            string queueNamespaceId = null
        ) {
            return new TransactionSetting(
                true,
                null,
                keyId,
                queueNamespaceId
            );
        }

        public Dictionary<string, object> Properties() {
            var properties = new Dictionary<string, object>();
            if (this._enableAutoRun != null) {
                properties["EnableAutoRun"] = this._enableAutoRun;
            }
            if (this._distributorNamespaceId != null) {
                properties["DistributorNamespaceId"] = this._distributorNamespaceId;
            }
            if (this._keyId != null) {
                properties["KeyId"] = this._keyId;
            }
            if (this._queueNamespaceId != null) {
                properties["QueueNamespaceId"] = this._queueNamespaceId;
            }
            return properties;
        }
    }
}