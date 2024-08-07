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
    public class SignedBallot {
        private string body;
        private string signature;

        public SignedBallot(
            string body,
            string signature,
            SignedBallotOptions options = null
        ){
            this.body = body;
            this.signature = signature;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.body != null) {
                properties["body"] = this.body;
            }
            if (this.signature != null) {
                properties["signature"] = this.signature;
            }

            return properties;
        }

        public static SignedBallot FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new SignedBallot(
                properties.TryGetValue("body", out var body) ? new Func<string>(() =>
                {
                    return (string) body;
                })() : default,
                properties.TryGetValue("signature", out var signature) ? new Func<string>(() =>
                {
                    return (string) signature;
                })() : default,
                new SignedBallotOptions {
                }
            );

            return model;
        }
    }
}
