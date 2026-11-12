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
using System;
using System.Collections.Generic;
using System.Linq;

using Gs2Cdk.Core.Model;
using Gs2Cdk.Gs2Account.Model;
using Gs2Cdk.Gs2Account.Model.Enums;
using Gs2Cdk.Gs2Account.Model.Options;

namespace Gs2Cdk.Gs2Account.Model
{
    public class AccountDeletionSetting {
        private int? gracePeriodMinutes;
        private string gracePeriodMinutesString;
        private AccountDeletionSettingLoginDuringGracePeriod? loginDuringGracePeriod;
        private AccountDeletionSettingCleanUserDataScope? cleanUserDataScope;

        public AccountDeletionSetting(
            int? gracePeriodMinutes,
            AccountDeletionSettingLoginDuringGracePeriod loginDuringGracePeriod,
            AccountDeletionSettingCleanUserDataScope cleanUserDataScope,
            AccountDeletionSettingOptions options = null
        ){
            this.gracePeriodMinutes = gracePeriodMinutes;
            this.loginDuringGracePeriod = loginDuringGracePeriod;
            this.cleanUserDataScope = cleanUserDataScope;
        }


        public AccountDeletionSetting(
            string gracePeriodMinutes,
            AccountDeletionSettingLoginDuringGracePeriod loginDuringGracePeriod,
            AccountDeletionSettingCleanUserDataScope cleanUserDataScope,
            AccountDeletionSettingOptions options = null
        ){
            this.gracePeriodMinutesString = gracePeriodMinutes;
            this.loginDuringGracePeriod = loginDuringGracePeriod;
            this.cleanUserDataScope = cleanUserDataScope;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.gracePeriodMinutesString != null) {
                properties["gracePeriodMinutes"] = this.gracePeriodMinutesString;
            } else {
                if (this.gracePeriodMinutes != null) {
                    properties["gracePeriodMinutes"] = this.gracePeriodMinutes;
                }
            }
            if (this.loginDuringGracePeriod != null) {
                properties["loginDuringGracePeriod"] = this.loginDuringGracePeriod.Value.Str(
                );
            }
            if (this.cleanUserDataScope != null) {
                properties["cleanUserDataScope"] = this.cleanUserDataScope.Value.Str(
                );
            }

            return properties;
        }

        public static AccountDeletionSetting FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new AccountDeletionSetting(
                properties.TryGetValue("gracePeriodMinutes", out var gracePeriodMinutes) ? new Func<int?>(() =>
                {
                    return gracePeriodMinutes switch {
                        int v => v,
                        string v => int.Parse(v),
                        _ => 0
                    };
                })() : default,
                properties.TryGetValue("loginDuringGracePeriod", out var loginDuringGracePeriod) ? new Func<AccountDeletionSettingLoginDuringGracePeriod>(() =>
                {
                    return loginDuringGracePeriod switch {
                        AccountDeletionSettingLoginDuringGracePeriod e => e,
                        string s => AccountDeletionSettingLoginDuringGracePeriodExt.New(s),
                        _ => AccountDeletionSettingLoginDuringGracePeriod.Reject
                    };
                })() : default,
                properties.TryGetValue("cleanUserDataScope", out var cleanUserDataScope) ? new Func<AccountDeletionSettingCleanUserDataScope>(() =>
                {
                    return cleanUserDataScope switch {
                        AccountDeletionSettingCleanUserDataScope e => e,
                        string s => AccountDeletionSettingCleanUserDataScopeExt.New(s),
                        _ => AccountDeletionSettingCleanUserDataScope.Account
                    };
                })() : default,
                new AccountDeletionSettingOptions {
                }
            );

            return model;
        }
    }
}
