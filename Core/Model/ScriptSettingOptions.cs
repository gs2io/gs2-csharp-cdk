using System.Collections.Generic;

using Gs2Cdk.Core.Model.Enums;

namespace Gs2Cdk.Core.Model
{
    public class ScriptSettingOptions
    {
        public string triggerScriptId;
        public ScriptSettingDoneTriggerTargetType? doneTriggerTargetType;
        public string doneTriggerScriptId;
        public string doneTriggerQueueNamespaceId;
    }
}