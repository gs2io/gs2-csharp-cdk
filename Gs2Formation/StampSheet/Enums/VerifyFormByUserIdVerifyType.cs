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


namespace Gs2Cdk.Gs2Formation.StampSheet.Enums
{
    
    public enum VerifyFormByUserIdVerifyType {
        Less,
        LessEqual,
        Greater,
        GreaterEqual,
        Equal,
        NotEqual
    }

    public static class VerifyFormByUserIdVerifyTypeExt
    {
        public static string Str(this VerifyFormByUserIdVerifyType self) {
            switch (self) {
                case VerifyFormByUserIdVerifyType.Less:
                    return "less";
                case VerifyFormByUserIdVerifyType.LessEqual:
                    return "lessEqual";
                case VerifyFormByUserIdVerifyType.Greater:
                    return "greater";
                case VerifyFormByUserIdVerifyType.GreaterEqual:
                    return "greaterEqual";
                case VerifyFormByUserIdVerifyType.Equal:
                    return "equal";
                case VerifyFormByUserIdVerifyType.NotEqual:
                    return "notEqual";
            }
            return "unknown";
        }

        public static VerifyFormByUserIdVerifyType New(string value) {
            switch (value) {
                case "less":
                    return VerifyFormByUserIdVerifyType.Less;
                case "lessEqual":
                    return VerifyFormByUserIdVerifyType.LessEqual;
                case "greater":
                    return VerifyFormByUserIdVerifyType.Greater;
                case "greaterEqual":
                    return VerifyFormByUserIdVerifyType.GreaterEqual;
                case "equal":
                    return VerifyFormByUserIdVerifyType.Equal;
                case "notEqual":
                    return VerifyFormByUserIdVerifyType.NotEqual;
            }
            return VerifyFormByUserIdVerifyType.Less;
        }
    }
}
