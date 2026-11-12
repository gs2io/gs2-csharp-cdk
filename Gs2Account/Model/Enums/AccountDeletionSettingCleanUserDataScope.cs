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
    
    public enum AccountDeletionSettingCleanUserDataScope {
        Account,
        Project,
        ProjectExceptMoney
    }

    public static class AccountDeletionSettingCleanUserDataScopeExt
    {
        public static string Str(this AccountDeletionSettingCleanUserDataScope self) {
            switch (self) {
                case AccountDeletionSettingCleanUserDataScope.Account:
                    return "account";
                case AccountDeletionSettingCleanUserDataScope.Project:
                    return "project";
                case AccountDeletionSettingCleanUserDataScope.ProjectExceptMoney:
                    return "projectExceptMoney";
            }
            return "unknown";
        }

        public static AccountDeletionSettingCleanUserDataScope New(string value) {
            switch (value) {
                case "account":
                    return AccountDeletionSettingCleanUserDataScope.Account;
                case "project":
                    return AccountDeletionSettingCleanUserDataScope.Project;
                case "projectExceptMoney":
                    return AccountDeletionSettingCleanUserDataScope.ProjectExceptMoney;
            }
            return AccountDeletionSettingCleanUserDataScope.Account;
        }
    }
}
