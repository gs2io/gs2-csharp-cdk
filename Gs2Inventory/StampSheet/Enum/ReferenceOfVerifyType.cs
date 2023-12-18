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


namespace Gs2Cdk.Gs2Inventory.Model.Enums
{
    
    public enum ReferenceOfVerifyType {
        NotEntry,
        AlreadyEntry,
        Empty,
        NotEmpty
    }

    public static class ReferenceOfVerifyTypeExt
    {
        public static string Str(this ReferenceOfVerifyType self) {
            switch (self) {
                case ReferenceOfVerifyType.NotEntry:
                    return "not_entry";
                case ReferenceOfVerifyType.AlreadyEntry:
                    return "already_entry";
                case ReferenceOfVerifyType.Empty:
                    return "empty";
                case ReferenceOfVerifyType.NotEmpty:
                    return "not_empty";
            }
            return "unknown";
        }

        public static ReferenceOfVerifyType New(string value) {
            switch (value) {
                case "not_entry":
                    return ReferenceOfVerifyType.NotEntry;
                case "already_entry":
                    return ReferenceOfVerifyType.AlreadyEntry;
                case "empty":
                    return ReferenceOfVerifyType.Empty;
                case "not_empty":
                    return ReferenceOfVerifyType.NotEmpty;
            }
            return ReferenceOfVerifyType.NotEntry;
        }
    }
}
