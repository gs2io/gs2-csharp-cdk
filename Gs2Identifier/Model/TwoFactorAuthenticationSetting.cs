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
using Gs2Cdk.Gs2Identifier.Model;
using Gs2Cdk.Gs2Identifier.Model.Enums;
using Gs2Cdk.Gs2Identifier.Model.Options;

namespace Gs2Cdk.Gs2Identifier.Model
{
    public class TwoFactorAuthenticationSetting {
        private string authenticationKey;
        private TwoFactorAuthenticationSettingStatus? status;

        public TwoFactorAuthenticationSetting(
            string authenticationKey,
            TwoFactorAuthenticationSettingStatus status,
            TwoFactorAuthenticationSettingOptions options = null
        ){
            this.authenticationKey = authenticationKey;
            this.status = status;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.authenticationKey != null) {
                properties["authenticationKey"] = this.authenticationKey;
            }
            if (this.status != null) {
                properties["status"] = this.status.Value.Str(
                );
            }

            return properties;
        }

        public static TwoFactorAuthenticationSetting FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new TwoFactorAuthenticationSetting(
                (string)properties["authenticationKey"],
                new Func<TwoFactorAuthenticationSettingStatus>(() =>
                {
                    return properties["status"] switch {
                        TwoFactorAuthenticationSettingStatus e => e,
                        string s => TwoFactorAuthenticationSettingStatusExt.New(s),
                        _ => TwoFactorAuthenticationSettingStatus.Verifying
                    };
                })(),
                new TwoFactorAuthenticationSettingOptions {
                }
            );

            return model;
        }
    }
}
