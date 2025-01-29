using System.Collections.Generic;

namespace Gs2Cdk.Core.Model
{
    public class NotificationSetting
    {
        private readonly string _gatewayNamespaceId;
        private readonly bool? _enableTransferMobileNotification;
        private readonly string _sound;

        public NotificationSetting(
            NotificationSettingOptions options = null
        ) {
            this._gatewayNamespaceId = options?.gatewayNamespaceId;
            this._enableTransferMobileNotification = options?.enableTransferMobileNotification;
            this._sound = options?.sound;
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

        public static NotificationSetting FromProperties(
            Dictionary<string, object> properties
        ) {
            var model = new NotificationSetting(
                new NotificationSettingOptions{
                    gatewayNamespaceId = properties.TryGetValue("gatewayNamespaceId", out var gatewayNamespaceId) ? (string)gatewayNamespaceId : null,
                    enableTransferMobileNotification = properties.TryGetValue("enableTransferMobileNotification", out var enableTransferMobileNotification) ? (bool?)enableTransferMobileNotification : null,
                    sound = properties.TryGetValue("sound", out var sound) ? (string)sound : null,
                }
            );
            return model;
        }
    }
}