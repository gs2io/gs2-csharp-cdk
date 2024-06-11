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
    
    public enum VerifyCompleteByUserIdVerifyType {
        Completed,
        NotCompleted,
        Received,
        NotReceived,
        CompletedAndNotReceived
    }

    public static class VerifyCompleteByUserIdVerifyTypeExt
    {
        public static string Str(this VerifyCompleteByUserIdVerifyType self) {
            switch (self) {
                case VerifyCompleteByUserIdVerifyType.Completed:
                    return "completed";
                case VerifyCompleteByUserIdVerifyType.NotCompleted:
                    return "notCompleted";
                case VerifyCompleteByUserIdVerifyType.Received:
                    return "received";
                case VerifyCompleteByUserIdVerifyType.NotReceived:
                    return "notReceived";
                case VerifyCompleteByUserIdVerifyType.CompletedAndNotReceived:
                    return "completedAndNotReceived";
            }
            return "unknown";
        }

        public static VerifyCompleteByUserIdVerifyType New(string value) {
            switch (value) {
                case "completed":
                    return VerifyCompleteByUserIdVerifyType.Completed;
                case "notCompleted":
                    return VerifyCompleteByUserIdVerifyType.NotCompleted;
                case "received":
                    return VerifyCompleteByUserIdVerifyType.Received;
                case "notReceived":
                    return VerifyCompleteByUserIdVerifyType.NotReceived;
                case "completedAndNotReceived":
                    return VerifyCompleteByUserIdVerifyType.CompletedAndNotReceived;
            }
            return VerifyCompleteByUserIdVerifyType.Completed;
        }
    }
}
