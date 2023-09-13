using System.Collections.Generic;

namespace Gs2Cdk.Core.Model
{
    public class NotificationSetting
    {
        private readonly string _gatewayNamespaceId;
        private readonly bool _enableTransferMobileNotification;
        private readonly string _sound;

        public NotificationSetting(
            string gatewayNamespaceId,
            bool enableTransferMobileNotification = false,
            string sound = null
        ) {
            this._gatewayNamespaceId = gatewayNamespaceId;
            this._enableTransferMobileNotification = enableTransferMobileNotification;
            this._sound = sound;
        }

        public Dictionary<string, object> Properties() {
            var properties = new Dictionary<string, object>();
            if (this._gatewayNamespaceId != null) {
                properties["GatewayNamespaceId"] = this._gatewayNamespaceId;
            }
            if (this._enableTransferMobileNotification != null) {
                properties["EnableTransferMobileNotification"] = this._enableTransferMobileNotification;
            }
            if (this._sound != null) {
                properties["Sound"] = this._sound;
            }
            return properties;
        }
    }
}