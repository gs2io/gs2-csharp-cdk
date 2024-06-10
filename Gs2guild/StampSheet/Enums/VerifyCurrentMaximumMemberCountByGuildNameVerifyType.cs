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


namespace Gs2Cdk.Gs2Guild.StampSheet.Enums
{
    
    public enum VerifyCurrentMaximumMemberCountByGuildNameVerifyType {
        Less,
        LessEqual,
        Greater,
        GreaterEqual,
        Equal,
        NotEqual
    }

    public static class VerifyCurrentMaximumMemberCountByGuildNameVerifyTypeExt
    {
        public static string Str(this VerifyCurrentMaximumMemberCountByGuildNameVerifyType self) {
            switch (self) {
                case VerifyCurrentMaximumMemberCountByGuildNameVerifyType.Less:
                    return "less";
                case VerifyCurrentMaximumMemberCountByGuildNameVerifyType.LessEqual:
                    return "lessEqual";
                case VerifyCurrentMaximumMemberCountByGuildNameVerifyType.Greater:
                    return "greater";
                case VerifyCurrentMaximumMemberCountByGuildNameVerifyType.GreaterEqual:
                    return "greaterEqual";
                case VerifyCurrentMaximumMemberCountByGuildNameVerifyType.Equal:
                    return "equal";
                case VerifyCurrentMaximumMemberCountByGuildNameVerifyType.NotEqual:
                    return "notEqual";
            }
            return "unknown";
        }

        public static VerifyCurrentMaximumMemberCountByGuildNameVerifyType New(string value) {
            switch (value) {
                case "less":
                    return VerifyCurrentMaximumMemberCountByGuildNameVerifyType.Less;
                case "lessEqual":
                    return VerifyCurrentMaximumMemberCountByGuildNameVerifyType.LessEqual;
                case "greater":
                    return VerifyCurrentMaximumMemberCountByGuildNameVerifyType.Greater;
                case "greaterEqual":
                    return VerifyCurrentMaximumMemberCountByGuildNameVerifyType.GreaterEqual;
                case "equal":
                    return VerifyCurrentMaximumMemberCountByGuildNameVerifyType.Equal;
                case "notEqual":
                    return VerifyCurrentMaximumMemberCountByGuildNameVerifyType.NotEqual;
            }
            return VerifyCurrentMaximumMemberCountByGuildNameVerifyType.Less;
        }
    }
}
