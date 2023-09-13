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


namespace Gs2Cdk.Gs2Exchange.Model.Enums
{
    
    public enum IncrementalRateModelCalculateType {
        Linear,
        Power,
        Gs2Script
    }

    public static class IncrementalRateModelCalculateTypeExt
    {
        public static string Str(this IncrementalRateModelCalculateType self) {
            switch (self) {
                case IncrementalRateModelCalculateType.Linear:
                    return "linear";
                case IncrementalRateModelCalculateType.Power:
                    return "power";
                case IncrementalRateModelCalculateType.Gs2Script:
                    return "gs2_script";
            }
            return "unknown";
        }

        public static IncrementalRateModelCalculateType New(string value) {
            switch (value) {
                case "linear":
                    return IncrementalRateModelCalculateType.Linear;
                case "power":
                    return IncrementalRateModelCalculateType.Power;
                case "gs2_script":
                    return IncrementalRateModelCalculateType.Gs2Script;
            }
            return IncrementalRateModelCalculateType.Linear;
        }
    }
}
