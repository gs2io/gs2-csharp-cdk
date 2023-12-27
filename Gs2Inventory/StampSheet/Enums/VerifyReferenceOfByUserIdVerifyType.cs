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


namespace Gs2Cdk.Gs2Inventory.StampSheet.Enums
{
    
    public enum VerifyReferenceOfByUserIdVerifyType {
        NotEntry,
        AlreadyEntry,
        Empty,
        NotEmpty
    }

    public static class VerifyReferenceOfByUserIdVerifyTypeExt
    {
        public static string Str(this VerifyReferenceOfByUserIdVerifyType self) {
            switch (self) {
                case VerifyReferenceOfByUserIdVerifyType.NotEntry:
                    return "not_entry";
                case VerifyReferenceOfByUserIdVerifyType.AlreadyEntry:
                    return "already_entry";
                case VerifyReferenceOfByUserIdVerifyType.Empty:
                    return "empty";
                case VerifyReferenceOfByUserIdVerifyType.NotEmpty:
                    return "not_empty";
            }
            return "unknown";
        }

        public static VerifyReferenceOfByUserIdVerifyType New(string value) {
            switch (value) {
                case "not_entry":
                    return VerifyReferenceOfByUserIdVerifyType.NotEntry;
                case "already_entry":
                    return VerifyReferenceOfByUserIdVerifyType.AlreadyEntry;
                case "empty":
                    return VerifyReferenceOfByUserIdVerifyType.Empty;
                case "not_empty":
                    return VerifyReferenceOfByUserIdVerifyType.NotEmpty;
            }
            return VerifyReferenceOfByUserIdVerifyType.NotEntry;
        }
    }
}
