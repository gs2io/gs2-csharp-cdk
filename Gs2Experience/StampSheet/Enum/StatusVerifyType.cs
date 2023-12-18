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


namespace Gs2Cdk.Gs2Experience.Model.Enums
{
    
    public enum StatusVerifyType {
        Less,
        LessEqual,
        Greater,
        GreaterEqual,
        Equal,
        NotEqual
    }

    public static class StatusVerifyTypeExt
    {
        public static string Str(this StatusVerifyType self) {
            switch (self) {
                case StatusVerifyType.Less:
                    return "less";
                case StatusVerifyType.LessEqual:
                    return "lessEqual";
                case StatusVerifyType.Greater:
                    return "greater";
                case StatusVerifyType.GreaterEqual:
                    return "greaterEqual";
                case StatusVerifyType.Equal:
                    return "equal";
                case StatusVerifyType.NotEqual:
                    return "notEqual";
            }
            return "unknown";
        }

        public static StatusVerifyType New(string value) {
            switch (value) {
                case "less":
                    return StatusVerifyType.Less;
                case "lessEqual":
                    return StatusVerifyType.LessEqual;
                case "greater":
                    return StatusVerifyType.Greater;
                case "greaterEqual":
                    return StatusVerifyType.GreaterEqual;
                case "equal":
                    return StatusVerifyType.Equal;
                case "notEqual":
                    return StatusVerifyType.NotEqual;
            }
            return StatusVerifyType.Less;
        }
    }
}
