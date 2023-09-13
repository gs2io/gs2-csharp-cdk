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
using Gs2Cdk.Gs2Lottery.Model.Options;

namespace Gs2Cdk.Gs2Lottery.Model
{
    public class PrizeLimit {
        private string prizeId;
        private int drawnCount;
        private long? revision;

        public PrizeLimit(
            string prizeId,
            int drawnCount,
            PrizeLimitOptions options = null
        ){
            this.prizeId = prizeId;
            this.drawnCount = drawnCount;
            this.revision = options?.revision;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.prizeId != null) {
                properties["prizeId"] = this.prizeId;
            }
            if (this.drawnCount != null) {
                properties["drawnCount"] = this.drawnCount;
            }

            return properties;
        }

        public static PrizeLimit FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new PrizeLimit(
                (string)properties["prizeId"],
                (int)properties["drawnCount"],
                new PrizeLimitOptions {
                    revision = properties.TryGetValue("revision", out var revision) ? (long?)revision : null
                }
            );

            return model;
        }
    }
}
