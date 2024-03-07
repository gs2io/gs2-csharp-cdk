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
using Gs2Cdk.Gs2Formation.Model;

namespace Gs2Cdk.Gs2Formation.StampSheet
{
    public class AcquireActionsToPropertyFormProperties : AcquireAction {
        private string namespaceName;
        private string userId;
        private string propertyFormModelName;
        private string propertyId;
        private AcquireAction acquireAction;
        private Config[] config;


        public AcquireActionsToPropertyFormProperties(
            string namespaceName,
            string propertyFormModelName,
            string propertyId,
            AcquireAction acquireAction,
            Config[] config = null,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.propertyFormModelName = propertyFormModelName;
            this.propertyId = propertyId;
            this.acquireAction = acquireAction;
            this.config = config;
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
            if (this.propertyFormModelName != null) {
                properties["propertyFormModelName"] = this.propertyFormModelName;
            }
            if (this.propertyId != null) {
                properties["propertyId"] = this.propertyId;
            }
            if (this.acquireAction != null) {
                properties["acquireAction"] = this.acquireAction?.Properties(
                );
            }
            if (this.config != null) {
                properties["config"] = this.config.Select(v => v?.Properties(
                        )).ToList();
            }

            return properties;
        }

        public static AcquireActionsToPropertyFormProperties FromProperties(Dictionary<string, object> properties) {
            try {
                return new AcquireActionsToPropertyFormProperties(
                    (string)properties["namespaceName"],
                    (string)properties["propertyFormModelName"],
                    (string)properties["propertyId"],
                    new Func<AcquireAction>(() =>
                    {
                        return properties["acquireAction"] switch {
                            AcquireAction v => v,
                            AcquireAction[] v => v.Length > 0 ? v.First() : null,
                            Dictionary<string, object> v => AcquireAction.FromProperties(v),
                            Dictionary<string, object>[] v => v.Length > 0 ? AcquireAction.FromProperties(v.First()) : null,
                            _ => null
                        };
                    })(),
                    new Func<Config[]>(() =>
                    {
                        return properties.TryGetValue("config", out var config) ? config switch {
                            Dictionary<string, object>[] v => v.Select(Config.FromProperties).ToArray(),
                            Dictionary<string, object> v => new []{ Config.FromProperties(v) },
                            List<Dictionary<string, object>> v => v.Select(Config.FromProperties).ToArray(),
                            object[] v => v.Select(v2 => v2 as Config).ToArray(),
                            { } v => new []{ v as Config },
                            _ => null
                        } : null;
                    })(),
                    new Func<string>(() =>
                    {
                        return properties.TryGetValue("userId", out var userId) ? userId as string : "#{userId}";
                    })()
                );
            } catch (Exception e) when (e is FormatException || e is OverflowException) {
                return new AcquireActionsToPropertyFormProperties(
                    properties["namespaceName"].ToString(),
                    properties["propertyFormModelName"].ToString(),
                    properties["propertyId"].ToString(),
                    new Func<AcquireAction>(() =>
                    {
                        return properties["acquireAction"] switch {
                            AcquireAction v => v,
                            AcquireAction[] v => v.Length > 0 ? v.First() : null,
                            Dictionary<string, object> v => AcquireAction.FromProperties(v),
                            Dictionary<string, object>[] v => v.Length > 0 ? AcquireAction.FromProperties(v.First()) : null,
                            _ => null
                        };
                    })(),
                    new Func<Config[]>(() =>
                    {
                        return properties.TryGetValue("config", out var config) ? config switch {
                            Dictionary<string, object>[] v => v.Select(Config.FromProperties).ToArray(),
                            Dictionary<string, object> v => new []{ Config.FromProperties(v) },
                            List<Dictionary<string, object>> v => v.Select(Config.FromProperties).ToArray(),
                            object[] v => v.Select(v2 => v2 as Config).ToArray(),
                            { } v => new []{ v as Config },
                            _ => null
                        } : null;
                    })(),
                    new Func<string>(() =>
                    {
                        return properties.TryGetValue("userId", out var userId) ? userId as string : "#{userId}";
                    })()
                );
            }
        }

        public override string Action() {
            return "Gs2Formation:AcquireActionsToPropertyFormProperties";
        }

        public static string StaticAction() {
            return "Gs2Formation:AcquireActionsToPropertyFormProperties";
        }
    }
}
