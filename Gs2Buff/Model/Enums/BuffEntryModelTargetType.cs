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


namespace Gs2Cdk.Gs2Buff.Model.Enums
{
    
    public enum BuffEntryModelTargetType {
        Model,
        Action
    }

    public static class BuffEntryModelTargetTypeExt
    {
        public static string Str(this BuffEntryModelTargetType self) {
            switch (self) {
                case BuffEntryModelTargetType.Model:
                    return "model";
                case BuffEntryModelTargetType.Action:
                    return "action";
            }
            return "unknown";
        }

        public static BuffEntryModelTargetType New(string value) {
            switch (value) {
                case "model":
                    return BuffEntryModelTargetType.Model;
                case "action":
                    return BuffEntryModelTargetType.Action;
            }
            return BuffEntryModelTargetType.Model;
        }
    }
}
