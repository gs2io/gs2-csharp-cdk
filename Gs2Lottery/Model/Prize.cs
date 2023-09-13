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
using Gs2Cdk.Gs2Lottery.Model;
using Gs2Cdk.Gs2Lottery.Model.Enums;
using Gs2Cdk.Gs2Lottery.Model.Options;

namespace Gs2Cdk.Gs2Lottery.Model
{
    public class Prize {
        private string prizeId;
        private PrizeType? type;
        private int weight;
        private AcquireAction[] acquireActions;
        private int? drawnLimit;
        private string limitFailOverPrizeId;
        private string prizeTableName;

        public Prize(
            string prizeId,
            PrizeType type,
            int weight,
            PrizeOptions options = null
        ){
            this.prizeId = prizeId;
            this.type = type;
            this.weight = weight;
            this.acquireActions = options?.acquireActions;
            this.drawnLimit = options?.drawnLimit;
            this.limitFailOverPrizeId = options?.limitFailOverPrizeId;
            this.prizeTableName = options?.prizeTableName;
        }

        public static Prize TypeIsAction(
            string prizeId,
            int weight,
            AcquireAction[] acquireActions,
            PrizeTypeIsActionOptions options = null
        ){
            return (new Prize(
                prizeId,
                PrizeType.Action,
                weight,
                new PrizeOptions {
                    acquireActions = acquireActions,
                    drawnLimit = options?.drawnLimit,
                }
            ));
        }

        public static Prize TypeIsPrizeTable(
            string prizeId,
            int weight,
            string prizeTableName,
            PrizeTypeIsPrizeTableOptions options = null
        ){
            return (new Prize(
                prizeId,
                PrizeType.PrizeTable,
                weight,
                new PrizeOptions {
                    prizeTableName = prizeTableName,
                    drawnLimit = options?.drawnLimit,
                }
            ));
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.prizeId != null) {
                properties["prizeId"] = this.prizeId;
            }
            if (this.type != null) {
                properties["type"] = this.type?.Str(
                );
            }
            if (this.acquireActions != null) {
                properties["acquireActions"] = this.acquireActions.Select(v => v.Properties(
                        )).ToList();
            }
            if (this.drawnLimit != null) {
                properties["drawnLimit"] = this.drawnLimit;
            }
            if (this.limitFailOverPrizeId != null) {
                properties["limitFailOverPrizeId"] = this.limitFailOverPrizeId;
            }
            if (this.prizeTableName != null) {
                properties["prizeTableName"] = this.prizeTableName;
            }
            if (this.weight != null) {
                properties["weight"] = this.weight;
            }

            return properties;
        }

        public static Prize FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new Prize(
                (string)properties["prizeId"],
                new Func<PrizeType>(() =>
                {
                    return properties["type"] switch {
                        PrizeType e => e,
                        string s => PrizeTypeExt.New(s),
                        _ => PrizeType.Action
                    };
                })(),
                new Func<int>(() =>
                {
                    return properties["weight"] switch {
                        int v => v,
                        string v => int.Parse(v),
                        _ => 0
                    };
                })(),
                new PrizeOptions {
                    acquireActions = properties.TryGetValue("acquireActions", out var acquireActions) ? new Func<AcquireAction[]>(() =>
                    {
                        return acquireActions switch {
                            AcquireAction[] v => v,
                            List<AcquireAction> v => v.ToArray(),
                            Dictionary<string, object>[] v => v.Select(AcquireAction.FromProperties).ToArray(),
                            List<Dictionary<string, object>> v => v.Select(AcquireAction.FromProperties).ToArray(),
                            _ => null
                        };
                    })() : null,
                    drawnLimit = new Func<int?>(() =>
                    {
                        return properties.TryGetValue("drawnLimit", out var drawnLimit) ? drawnLimit switch {
                            int v => v,
                            string v => int.Parse(v),
                            _ => null
                        } : null;
                    })(),
                    limitFailOverPrizeId = properties.TryGetValue("limitFailOverPrizeId", out var limitFailOverPrizeId) ? (string)limitFailOverPrizeId : null,
                    prizeTableName = properties.TryGetValue("prizeTableName", out var prizeTableName) ? (string)prizeTableName : null
                }
            );

            return model;
        }
    }
}
