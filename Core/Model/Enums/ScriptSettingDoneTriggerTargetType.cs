/*
 * Copyright 2016- Game Server Services, Inc. or its affiliates. All Rights
 * Reserved.
 *
 * Licensed under the Apache License, Version 2.0 (the "License").
 * You may not use this file except in compliance with the License.
 * A copy of the License is located at
 *
 *  http://www.apache.org/licenses/LICENSE-2.0
 *
 * or in the "license" file accompanying this file. This file is distributed
 * on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either
 * express or implied. See the License for the specific language governing
 * permissions and limitations under the License.
 */


namespace Gs2Cdk.Core.Model.Enums
{
    
    public enum ScriptSettingDoneTriggerTargetType {
        None,
        Gs2Script,
        Aws
    }

    public static class ScriptSettingDoneTriggerTargetTypeExt
    {
        public static string Str(this ScriptSettingDoneTriggerTargetType self) {
            switch (self) {
                case ScriptSettingDoneTriggerTargetType.None:
                    return "none";
                case ScriptSettingDoneTriggerTargetType.Gs2Script:
                    return "gs2_script";
                case ScriptSettingDoneTriggerTargetType.Aws:
                    return "aws";
            }
            return "unknown";
        }

        public static ScriptSettingDoneTriggerTargetType New(string value) {
            switch (value) {
                case "none":
                    return ScriptSettingDoneTriggerTargetType.None;
                case "gs2_script":
                    return ScriptSettingDoneTriggerTargetType.Gs2Script;
                case "aws":
                    return ScriptSettingDoneTriggerTargetType.Aws;
            }
            return ScriptSettingDoneTriggerTargetType.None;
        }
    }
}
