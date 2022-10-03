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
            return new Dictionary<string, object>() {
                {"TriggerScriptId", _triggerScriptId},
                {"DoneTriggerTargetType", _doneTriggerTargetType},
                {"DoneTriggerScriptId", _doneTriggerScriptId},
                {"DoneTriggerQueueNamespaceId", _doneTriggerQueueNamespaceId},
            };
        }
    }
}