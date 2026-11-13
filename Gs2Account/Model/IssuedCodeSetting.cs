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
using Gs2Cdk.Gs2Account.Model.Options;

namespace Gs2Cdk.Gs2Account.Model
{
    public class IssuedCodeSetting {
        private int expiresDays;
        private string expiresDaysString;
        private bool? deleteOnUse;
        private string deleteOnUseString;
        private int? maxFailedAttempts;
        private string maxFailedAttemptsString;

        public IssuedCodeSetting(
            int expiresDays,
            bool? deleteOnUse,
            IssuedCodeSettingOptions options = null
        ){
            this.expiresDays = expiresDays;
            this.deleteOnUse = deleteOnUse;
            this.maxFailedAttempts = options?.maxFailedAttempts;
        }


        public IssuedCodeSetting(
            string expiresDays,
            string deleteOnUse,
            IssuedCodeSettingOptions options = null
        ){
            this.expiresDaysString = expiresDays;
            this.deleteOnUseString = deleteOnUse;
            this.maxFailedAttempts = options?.maxFailedAttempts;
            this.maxFailedAttemptsString = options?.maxFailedAttemptsString;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.expiresDaysString != null) {
                properties["expiresDays"] = this.expiresDaysString;
            } else {
                if (this.expiresDays != null) {
                    properties["expiresDays"] = this.expiresDays;
                }
            }
            if (this.maxFailedAttemptsString != null) {
                properties["maxFailedAttempts"] = this.maxFailedAttemptsString;
            } else {
                if (this.maxFailedAttempts != null) {
                    properties["maxFailedAttempts"] = this.maxFailedAttempts;
                }
            }
            if (this.deleteOnUseString != null) {
                properties["deleteOnUse"] = this.deleteOnUseString;
            } else {
                if (this.deleteOnUse != null) {
                    properties["deleteOnUse"] = this.deleteOnUse;
                }
            }

            return properties;
        }

        public static IssuedCodeSetting FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new IssuedCodeSetting(
                properties.TryGetValue("expiresDays", out var expiresDays) ? new Func<int>(() =>
                {
                    return expiresDays switch {
                        int v => v,
                        string v => int.Parse(v),
                        _ => 0
                    };
                })() : default,
                properties.TryGetValue("deleteOnUse", out var deleteOnUse) ? new Func<bool?>(() =>
                {
                    return deleteOnUse switch {
                        bool v => v,
                        string v => bool.Parse(v),
                        _ => false
                    };
                })() : default,
                new IssuedCodeSettingOptions {
                    maxFailedAttempts = new Func<int?>(() =>
                    {
                        return properties.TryGetValue("maxFailedAttempts", out var maxFailedAttempts) ? maxFailedAttempts switch {
                            int v => v,
                            string v => int.Parse(v),
                            _ => null
                        } : null;
                    })()
                }
            );

            return model;
        }
    }
}
