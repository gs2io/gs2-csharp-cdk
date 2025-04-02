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


namespace Gs2Cdk.Gs2Limit.StampSheet.Enums
{
    
    public enum VerifyCounterByUserIdVerifyType {
        Less,
        LessEqual,
        Greater,
        GreaterEqual,
        Equal,
        NotEqual
    }

    public static class VerifyCounterByUserIdVerifyTypeExt
    {
        public static string Str(this VerifyCounterByUserIdVerifyType self) {
            switch (self) {
                case VerifyCounterByUserIdVerifyType.Less:
                    return "less";
                case VerifyCounterByUserIdVerifyType.LessEqual:
                    return "lessEqual";
                case VerifyCounterByUserIdVerifyType.Greater:
                    return "greater";
                case VerifyCounterByUserIdVerifyType.GreaterEqual:
                    return "greaterEqual";
                case VerifyCounterByUserIdVerifyType.Equal:
                    return "equal";
                case VerifyCounterByUserIdVerifyType.NotEqual:
                    return "notEqual";
            }
            return "unknown";
        }

        public static VerifyCounterByUserIdVerifyType New(string value) {
            switch (value) {
                case "less":
                    return VerifyCounterByUserIdVerifyType.Less;
                case "lessEqual":
                    return VerifyCounterByUserIdVerifyType.LessEqual;
                case "greater":
                    return VerifyCounterByUserIdVerifyType.Greater;
                case "greaterEqual":
                    return VerifyCounterByUserIdVerifyType.GreaterEqual;
                case "equal":
                    return VerifyCounterByUserIdVerifyType.Equal;
                case "notEqual":
                    return VerifyCounterByUserIdVerifyType.NotEqual;
            }
            return VerifyCounterByUserIdVerifyType.Less;
        }
    }
}
