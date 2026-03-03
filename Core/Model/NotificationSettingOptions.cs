using System.Collections.Generic;

using Gs2Cdk.Core.Model.Enums;

namespace Gs2Cdk.Core.Model
{
    public class NotificationSettingOptions
    {
        public string gatewayNamespaceId;
        public bool? enableTransferMobileNotification;
        public string sound;
        public NotificationSettingEnable enable;
    }
}