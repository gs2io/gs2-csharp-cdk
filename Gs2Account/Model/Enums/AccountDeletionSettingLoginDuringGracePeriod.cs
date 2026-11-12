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


namespace Gs2Cdk.Gs2Account.Model.Enums
{
    
    public enum AccountDeletionSettingLoginDuringGracePeriod {
        Reject,
        Cancel
    }

    public static class AccountDeletionSettingLoginDuringGracePeriodExt
    {
        public static string Str(this AccountDeletionSettingLoginDuringGracePeriod self) {
            switch (self) {
                case AccountDeletionSettingLoginDuringGracePeriod.Reject:
                    return "reject";
                case AccountDeletionSettingLoginDuringGracePeriod.Cancel:
                    return "cancel";
            }
            return "unknown";
        }

        public static AccountDeletionSettingLoginDuringGracePeriod New(string value) {
            switch (value) {
                case "reject":
                    return AccountDeletionSettingLoginDuringGracePeriod.Reject;
                case "cancel":
                    return AccountDeletionSettingLoginDuringGracePeriod.Cancel;
            }
            return AccountDeletionSettingLoginDuringGracePeriod.Reject;
        }
    }
}
