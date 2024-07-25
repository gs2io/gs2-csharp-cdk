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


namespace Gs2Cdk.Gs2Mission.Model.Enums
{
    
    public enum MissionTaskModelVerifyCompleteType {
        Counter,
        VerifyActions
    }

    public static class MissionTaskModelVerifyCompleteTypeExt
    {
        public static string Str(this MissionTaskModelVerifyCompleteType self) {
            switch (self) {
                case MissionTaskModelVerifyCompleteType.Counter:
                    return "counter";
                case MissionTaskModelVerifyCompleteType.VerifyActions:
                    return "verifyActions";
            }
            return "unknown";
        }

        public static MissionTaskModelVerifyCompleteType New(string value) {
            switch (value) {
                case "counter":
                    return MissionTaskModelVerifyCompleteType.Counter;
                case "verifyActions":
                    return MissionTaskModelVerifyCompleteType.VerifyActions;
            }
            return MissionTaskModelVerifyCompleteType.Counter;
        }
    }
}
