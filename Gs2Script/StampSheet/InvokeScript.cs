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
 *
 * deny overwrite
 */
using System;
using System.Collections.Generic;
using System.Linq;

using Gs2Cdk.Core.Model;
using Gs2Cdk.Gs2Script.Model;

namespace Gs2Cdk.Gs2Script.StampSheet
{
    public class InvokeScript : AcquireAction {
        private string scriptId;
        private string userId;
        private string args;
        private RandomStatus randomStatus;
        private bool? forceUseDistributor;
        private string forceUseDistributorString;
        private string timeOffsetToken;


        public InvokeScript(
            string scriptId = null,
            string args = null,
            RandomStatus randomStatus = null,
            bool? forceUseDistributor = null,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){

            this.userId = userId;
            this.args = args;
            this.randomStatus = randomStatus;
            this.forceUseDistributor = forceUseDistributor;
            this.timeOffsetToken = timeOffsetToken;
            this.userId = userId;
        }


        public InvokeScript(
            string scriptId = null,
            string args = null,
            RandomStatus randomStatus = null,
            string forceUseDistributor = null,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){

            this.userId = userId;
            this.args = args;
            this.randomStatus = randomStatus;
            this.forceUseDistributorString = forceUseDistributor;
            this.timeOffsetToken = timeOffsetToken;
            this.userId = userId;
        }

        public override Dictionary<string, object> Request(
        ){
            var properties = new Dictionary<string, object>();

            if (this.scriptId != null) {
                properties["scriptId"] = this.scriptId;
            }
            if (this.userId != null) {
                properties["userId"] = this.userId;
            }
            if (this.args != null) {
                properties["args"] = this.args;
            }
            if (this.randomStatus != null) {
                properties["randomStatus"] = this.randomStatus?.Properties(
                );
            }
            if (this.forceUseDistributorString != null) {
                properties["forceUseDistributor"] = this.forceUseDistributorString;
            } else {
                if (this.forceUseDistributor != null) {
                    properties["forceUseDistributor"] = this.forceUseDistributor;
                }
            }
            if (this.timeOffsetToken != null) {
                properties["timeOffsetToken"] = this.timeOffsetToken;
            }

            return properties;
        }

        public static InvokeScript FromProperties(Dictionary<string, object> properties) {
            try {
                return new InvokeScript(
                    new Func<string>(() =>
                    {
                        return properties.TryGetValue("userId", out var userId) ? userId as string : null;
                    })(),
                    new Func<string>(() =>
                    {
                        return properties.TryGetValue("args", out var args) ? args as string : null;
                    })(),
                    new Func<RandomStatus>(() =>
                    {
                        return properties.TryGetValue("randomStatus", out var randomStatus) ? randomStatus switch {
                            RandomStatus v => v,
                            RandomStatus[] v => v.Length > 0 ? v.First() : null,
                            Dictionary<string, object> v => RandomStatus.FromProperties(v),
                            Dictionary<string, object>[] v => v.Length > 0 ? RandomStatus.FromProperties(v.First()) : null,
                            _ => null
                        } : null;
                    })(),
                    new Func<bool?>(() =>
                    {
                        return properties.TryGetValue("forceUseDistributor", out var forceUseDistributor) ? forceUseDistributor switch {
                            bool v => v,
                            string v => bool.Parse(v),
                            _ => false
                        } : null;
                    })(),
                    new Func<string>(() =>
                    {
                        return properties.TryGetValue("timeOffsetToken", out var timeOffsetToken) ? timeOffsetToken as string : null;
                    })(),
                    new Func<string>(() =>
                    {
                        return properties.TryGetValue("userId", out var userId) ? userId as string : "#{userId}";
                    })()
                );
            } catch (Exception e) when (e is FormatException || e is OverflowException) {
                return new InvokeScript(
                    new Func<string>(() =>
                    {
                        return properties.TryGetValue("userId", out var userId) ? userId.ToString() : null;
                    })(),
                    new Func<string>(() =>
                    {
                        return properties.TryGetValue("args", out var args) ? args.ToString() : null;
                    })(),
                    new Func<RandomStatus>(() =>
                    {
                        return properties.TryGetValue("randomStatus", out var randomStatus) ? randomStatus switch {
                            RandomStatus v => v,
                            RandomStatus[] v => v.Length > 0 ? v.First() : null,
                            Dictionary<string, object> v => RandomStatus.FromProperties(v),
                            Dictionary<string, object>[] v => v.Length > 0 ? RandomStatus.FromProperties(v.First()) : null,
                            _ => null
                        } : null;
                    })(),
                    new Func<string>(() =>
                    {
                        return properties.TryGetValue("forceUseDistributor", out var forceUseDistributor) ? forceUseDistributor.ToString() : null;
                    })(),
                    new Func<string>(() =>
                    {
                        return properties.TryGetValue("timeOffsetToken", out var timeOffsetToken) ? timeOffsetToken.ToString() : null;
                    })(),
                    new Func<string>(() =>
                    {
                        return properties.TryGetValue("userId", out var userId) ? userId as string : "#{userId}";
                    })()
                );
            }
        }

        public override string Action() {
            return "Gs2Script:InvokeScript";
        }

        public static string StaticAction() {
            return "Gs2Script:InvokeScript";
        }
    }
}
