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

namespace Gs2Cdk.Core.StampSheet
{
    public class Void : AcquireAction {
        private Config[] config;

        public Void(
            Config[] config = null
        ){
            this.config = config;
        }

        public override Dictionary<string, object> Request(
        ){
            var properties = new Dictionary<string, object>();
            if (this.config != null) {
                properties["config"] = this.config.Select(v => v?.Properties(
                )).ToList();
            }
            return properties;
        }

        public static Void FromProperties(Dictionary<string, object> properties) {
            try {
                return new Void(
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
                    })()
                );
            } catch (Exception e) when (e is FormatException || e is OverflowException) {
                return new Void(
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
                    })()
                );
            }
        }

        public override string Action() {
            return "Void";
        }

        public static string StaticAction() {
            return "Void";
        }
    }
}
