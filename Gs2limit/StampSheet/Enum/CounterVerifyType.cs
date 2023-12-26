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
    
    public enum CounterVerifyType {
        Less,
        LessEqual,
        Greater,
        GreaterEqual,
        Equal,
        NotEqual
    }

    public static class CounterVerifyTypeExt
    {
        public static string Str(this CounterVerifyType self) {
            switch (self) {
                case CounterVerifyType.Less:
                    return "less";
                case CounterVerifyType.LessEqual:
                    return "lessEqual";
                case CounterVerifyType.Greater:
                    return "greater";
                case CounterVerifyType.GreaterEqual:
                    return "greaterEqual";
                case CounterVerifyType.Equal:
                    return "equal";
                case CounterVerifyType.NotEqual:
                    return "notEqual";
            }
            return "unknown";
        }

        public static CounterVerifyType New(string value) {
            switch (value) {
                case "less":
                    return CounterVerifyType.Less;
                case "lessEqual":
                    return CounterVerifyType.LessEqual;
                case "greater":
                    return CounterVerifyType.Greater;
                case "greaterEqual":
                    return CounterVerifyType.GreaterEqual;
                case "equal":
                    return CounterVerifyType.Equal;
                case "notEqual":
                    return CounterVerifyType.NotEqual;
            }
            return CounterVerifyType.Less;
        }
    }
}
