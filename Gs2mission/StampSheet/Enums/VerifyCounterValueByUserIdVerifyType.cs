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


namespace Gs2Cdk.Gs2Mission.StampSheet.Enums
{
    
    public enum VerifyCounterValueByUserIdVerifyType {
        Less,
        LessEqual,
        Greater,
        GreaterEqual,
        Equal,
        NotEqual
    }

    public static class VerifyCounterValueByUserIdVerifyTypeExt
    {
        public static string Str(this VerifyCounterValueByUserIdVerifyType self) {
            switch (self) {
                case VerifyCounterValueByUserIdVerifyType.Less:
                    return "less";
                case VerifyCounterValueByUserIdVerifyType.LessEqual:
                    return "lessEqual";
                case VerifyCounterValueByUserIdVerifyType.Greater:
                    return "greater";
                case VerifyCounterValueByUserIdVerifyType.GreaterEqual:
                    return "greaterEqual";
                case VerifyCounterValueByUserIdVerifyType.Equal:
                    return "equal";
                case VerifyCounterValueByUserIdVerifyType.NotEqual:
                    return "notEqual";
            }
            return "unknown";
        }

        public static VerifyCounterValueByUserIdVerifyType New(string value) {
            switch (value) {
                case "less":
                    return VerifyCounterValueByUserIdVerifyType.Less;
                case "lessEqual":
                    return VerifyCounterValueByUserIdVerifyType.LessEqual;
                case "greater":
                    return VerifyCounterValueByUserIdVerifyType.Greater;
                case "greaterEqual":
                    return VerifyCounterValueByUserIdVerifyType.GreaterEqual;
                case "equal":
                    return VerifyCounterValueByUserIdVerifyType.Equal;
                case "notEqual":
                    return VerifyCounterValueByUserIdVerifyType.NotEqual;
            }
            return VerifyCounterValueByUserIdVerifyType.Less;
        }
    }
}
