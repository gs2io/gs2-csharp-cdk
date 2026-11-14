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


namespace Gs2Cdk.Gs2AdReward.StampSheet.Enums
{
    
    public enum VerifyPointByUserIdVerifyType {
        Less,
        LessEqual,
        Greater,
        GreaterEqual,
        Equal,
        NotEqual
    }

    public static class VerifyPointByUserIdVerifyTypeExt
    {
        public static string Str(this VerifyPointByUserIdVerifyType self) {
            switch (self) {
                case VerifyPointByUserIdVerifyType.Less:
                    return "less";
                case VerifyPointByUserIdVerifyType.LessEqual:
                    return "lessEqual";
                case VerifyPointByUserIdVerifyType.Greater:
                    return "greater";
                case VerifyPointByUserIdVerifyType.GreaterEqual:
                    return "greaterEqual";
                case VerifyPointByUserIdVerifyType.Equal:
                    return "equal";
                case VerifyPointByUserIdVerifyType.NotEqual:
                    return "notEqual";
            }
            return "unknown";
        }

        public static VerifyPointByUserIdVerifyType New(string value) {
            switch (value) {
                case "less":
                    return VerifyPointByUserIdVerifyType.Less;
                case "lessEqual":
                    return VerifyPointByUserIdVerifyType.LessEqual;
                case "greater":
                    return VerifyPointByUserIdVerifyType.Greater;
                case "greaterEqual":
                    return VerifyPointByUserIdVerifyType.GreaterEqual;
                case "equal":
                    return VerifyPointByUserIdVerifyType.Equal;
                case "notEqual":
                    return VerifyPointByUserIdVerifyType.NotEqual;
            }
            return VerifyPointByUserIdVerifyType.Less;
        }
    }
}
