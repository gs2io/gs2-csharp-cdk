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
using Gs2Cdk.Gs2StateMachine.Model;

namespace Gs2Cdk.Gs2StateMachine.StampSheet
{
    public class StartStateMachineByUserId : AcquireAction {
        private string namespaceName;
        private string userId;
        private string args;
        private int? ttl;
        private string ttlString;
        private string timeOffsetToken;


        public StartStateMachineByUserId(
            string namespaceName,
            string args = null,
            int? ttl = null,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.args = args;
            this.ttl = ttl;
            this.timeOffsetToken = timeOffsetToken;
            this.userId = userId;
        }


        public StartStateMachineByUserId(
            string namespaceName,
            string args = null,
            string ttl = null,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.args = args;
            this.ttlString = ttl;
            this.timeOffsetToken = timeOffsetToken;
            this.userId = userId;
        }

        public override Dictionary<string, object> Request(
        ){
            var properties = new Dictionary<string, object>();

            if (this.namespaceName != null) {
                properties["namespaceName"] = this.namespaceName;
            }
            if (this.userId != null) {
                properties["userId"] = this.userId;
            }
            if (this.args != null) {
                properties["args"] = this.args;
            }
            if (this.ttlString != null) {
                properties["ttl"] = this.ttlString;
            } else {
                if (this.ttl != null) {
                    properties["ttl"] = this.ttl;
                }
            }
            if (this.timeOffsetToken != null) {
                properties["timeOffsetToken"] = this.timeOffsetToken;
            }

            return properties;
        }

        public static StartStateMachineByUserId FromProperties(Dictionary<string, object> properties) {
            try {
                return new StartStateMachineByUserId(
                    (string)properties["namespaceName"],
                    new Func<string>(() =>
                    {
                        return properties.TryGetValue("args", out var args) ? args as string : null;
                    })(),
                    new Func<int?>(() =>
                    {
                        return properties.TryGetValue("ttl", out var ttl) ? ttl switch {
                            long v => (int)v,
                            int v => (int)v,
                            float v => (int)v,
                            double v => (int)v,
                            string v => int.Parse(v),
                            _ => 0
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
                return new StartStateMachineByUserId(
                    properties["namespaceName"].ToString(),
                    new Func<string>(() =>
                    {
                        return properties.TryGetValue("args", out var args) ? args.ToString() : null;
                    })(),
                    new Func<string>(() =>
                    {
                        return properties.TryGetValue("ttl", out var ttl) ? ttl.ToString() : null;
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
            return "Gs2StateMachine:StartStateMachineByUserId";
        }

        public static string StaticAction() {
            return "Gs2StateMachine:StartStateMachineByUserId";
        }
    }
}
