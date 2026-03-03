using System.Collections.Generic;

using Gs2Cdk.Core.Model.Enums;

namespace Gs2Cdk.Core.Model
{
    public class ScriptSetting
    {
        private readonly string _triggerScriptId;
        private readonly ScriptSettingDoneTriggerTargetType? _doneTriggerTargetType;
        private readonly string _doneTriggerScriptId;
        private readonly string _doneTriggerQueueNamespaceId;

        public ScriptSetting(
            ScriptSettingOptions options = null
        )
        {
            this._triggerScriptId = options?.triggerScriptId;
            this._doneTriggerTargetType = options?.doneTriggerTargetType;
            this._doneTriggerScriptId = options?.doneTriggerScriptId;
            this._doneTriggerQueueNamespaceId = options?.doneTriggerQueueNamespaceId;
        }

        public Dictionary<string, object> Properties() {
            var properties = new Dictionary<string, object>();
            if (this._triggerScriptId != null) {
                properties["TriggerScriptId"] = this._triggerScriptId;
            }
            if (this._doneTriggerTargetType != null) {
                properties["DoneTriggerTargetType"] = this._doneTriggerTargetType;
            }
            if (this._doneTriggerScriptId != null) {
                properties["DoneTriggerScriptId"] = this._doneTriggerScriptId;
            }
            if (this._doneTriggerQueueNamespaceId != null) {
                properties["DoneTriggerQueueNamespaceId"] = this._doneTriggerQueueNamespaceId;
            }
            return properties;
        }
        
        public static ScriptSetting FromProperties(
            Dictionary<string, object> properties
        ) {
            var model = new ScriptSetting(
                new ScriptSettingOptions{
                    triggerScriptId = properties.TryGetValue("triggerScriptId", out var triggerScriptId) ? (string)triggerScriptId : null,
                    doneTriggerTargetType = properties.TryGetValue("doneTriggerTargetType", out var doneTriggerTargetType) ? (ScriptSettingDoneTriggerTargetType?)doneTriggerTargetType : null,
                    doneTriggerScriptId = properties.TryGetValue("doneTriggerScriptId", out var doneTriggerScriptId) ? (string)doneTriggerScriptId : null,
                    doneTriggerQueueNamespaceId = properties.TryGetValue("doneTriggerQueueNamespaceId", out var doneTriggerQueueNamespaceId) ? (string)doneTriggerQueueNamespaceId : null
                }
            );
            return model;
        }
    }
}