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
using Gs2Cdk.Gs2SeasonRating.Model;
using Gs2Cdk.Gs2SeasonRating.Model.Options;

namespace Gs2Cdk.Gs2SeasonRating.Model
{
    public class GameResult {
        private int rank;
        private string rankString;
        private string userId;

        public GameResult(
            int rank,
            string userId,
            GameResultOptions options = null
        ){
            this.rank = rank;
            this.userId = userId;
        }


        public GameResult(
            string rank,
            string userId,
            GameResultOptions options = null
        ){
            this.rankString = rank;
            this.userId = userId;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.rankString != null) {
                properties["rank"] = this.rankString;
            } else {
                if (this.rank != null) {
                    properties["rank"] = this.rank;
                }
            }
            if (this.userId != null) {
                properties["userId"] = this.userId;
            }

            return properties;
        }

        public static GameResult FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new GameResult(
                properties.TryGetValue("rank", out var rank) ? new Func<int>(() =>
                {
                    return rank switch {
                        int v => v,
                        string v => int.Parse(v),
                        _ => 0
                    };
                })() : default,
                properties.TryGetValue("userId", out var userId) ? new Func<string>(() =>
                {
                    return (string) userId;
                })() : default,
                new GameResultOptions {
                }
            );

            return model;
        }
    }
}
