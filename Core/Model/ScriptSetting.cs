using System.Collections.Generic;

namespace Gs2Cdk.Core.Model
{
    public class ScriptSetting
    {
        private readonly string _triggerScriptId;
        private readonly string _doneTriggerTargetType;
        private readonly string _doneTriggerScriptId;
        private readonly string _doneTriggerQueueNamespaceId;

        public ScriptSetting(
                string triggerScriptId = null,
                string doneTriggerTargetType = null,
                string doneTriggerScriptId = null,
                string doneTriggerQueueNamespaceId = null
        )
        {
            this._triggerScriptId = triggerScriptId;
            this._doneTriggerTargetType = doneTriggerTargetType;
            this._doneTriggerScriptId = doneTriggerScriptId;
            this._doneTriggerQueueNamespaceId = doneTriggerQueueNamespaceId;
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
                properties.TryGetValue("triggerScriptId", out var triggerScriptId) ? (string)triggerScriptId : null,
                properties.TryGetValue("doneTriggerTargetType", out var doneTriggerTargetType) ? (string)doneTriggerTargetType : null,
                properties.TryGetValue("doneTriggerScriptId", out var doneTriggerScriptId) ? (string)doneTriggerScriptId : null,
                properties.TryGetValue("doneTriggerQueueNamespaceId", out var doneTriggerQueueNamespaceId) ? (string)doneTriggerQueueNamespaceId : null
            );
            return model;
        }
    }
}