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
            return new Dictionary<string, object>() {
                {"GatewayNamespaceId", _gatewayNamespaceId},
                {"EnableTransferMobileNotification", _enableTransferMobileNotification},
                {"Sound", _sound},
            };
        }
    }
}