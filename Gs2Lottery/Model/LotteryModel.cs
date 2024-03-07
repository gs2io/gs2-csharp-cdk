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
    public class LotteryModel {
        private string name;
        private LotteryModelMode? mode;
        private LotteryModelMethod? method;
        private string metadata;
        private string prizeTableName;
        private string choicePrizeTableScriptId;

        public LotteryModel(
            string name,
            LotteryModelMode mode,
            LotteryModelMethod method,
            LotteryModelOptions options = null
        ){
            this.name = name;
            this.mode = mode;
            this.method = method;
            this.metadata = options?.metadata;
            this.prizeTableName = options?.prizeTableName;
            this.choicePrizeTableScriptId = options?.choicePrizeTableScriptId;
        }

        public static LotteryModel MethodIsPrizeTable(
            string name,
            LotteryModelMode mode,
            string prizeTableName,
            LotteryModelMethodIsPrizeTableOptions options = null
        ){
            return (new LotteryModel(
                name,
                mode,
                LotteryModelMethod.PrizeTable,
                new LotteryModelOptions {
                    prizeTableName = prizeTableName,
                    metadata = options?.metadata,
                }
            ));
        }

        public static LotteryModel MethodIsScript(
            string name,
            LotteryModelMode mode,
            string choicePrizeTableScriptId,
            LotteryModelMethodIsScriptOptions options = null
        ){
            return (new LotteryModel(
                name,
                mode,
                LotteryModelMethod.Script,
                new LotteryModelOptions {
                    choicePrizeTableScriptId = choicePrizeTableScriptId,
                    metadata = options?.metadata,
                }
            ));
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.name != null) {
                properties["name"] = this.name;
            }
            if (this.metadata != null) {
                properties["metadata"] = this.metadata;
            }
            if (this.mode != null) {
                properties["mode"] = this.mode.Value.Str(
                );
            }
            if (this.method != null) {
                properties["method"] = this.method.Value.Str(
                );
            }
            if (this.prizeTableName != null) {
                properties["prizeTableName"] = this.prizeTableName;
            }
            if (this.choicePrizeTableScriptId != null) {
                properties["choicePrizeTableScriptId"] = this.choicePrizeTableScriptId;
            }

            return properties;
        }

        public static LotteryModel FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new LotteryModel(
                (string)properties["name"],
                new Func<LotteryModelMode>(() =>
                {
                    return properties["mode"] switch {
                        LotteryModelMode e => e,
                        string s => LotteryModelModeExt.New(s),
                        _ => LotteryModelMode.Normal
                    };
                })(),
                new Func<LotteryModelMethod>(() =>
                {
                    return properties["method"] switch {
                        LotteryModelMethod e => e,
                        string s => LotteryModelMethodExt.New(s),
                        _ => LotteryModelMethod.PrizeTable
                    };
                })(),
                new LotteryModelOptions {
                    metadata = properties.TryGetValue("metadata", out var metadata) ? (string)metadata : null,
                    prizeTableName = properties.TryGetValue("prizeTableName", out var prizeTableName) ? (string)prizeTableName : null,
                    choicePrizeTableScriptId = properties.TryGetValue("choicePrizeTableScriptId", out var choicePrizeTableScriptId) ? (string)choicePrizeTableScriptId : null
                }
            );

            return model;
        }
    }
}
