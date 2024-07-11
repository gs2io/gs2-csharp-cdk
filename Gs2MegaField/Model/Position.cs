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
using Gs2Cdk.Gs2MegaField.Model;
using Gs2Cdk.Gs2MegaField.Model.Options;

namespace Gs2Cdk.Gs2MegaField.Model
{
    public class Position {
        private float x;
        private string xString;
        private float y;
        private string yString;
        private float z;
        private string zString;

        public Position(
            float x,
            float y,
            float z,
            PositionOptions options = null
        ){
            this.x = x;
            this.y = y;
            this.z = z;
        }


        public Position(
            string x,
            string y,
            string z,
            PositionOptions options = null
        ){
            this.xString = x;
            this.yString = y;
            this.zString = z;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.xString != null) {
                properties["x"] = this.xString;
            } else {
                if (this.x != null) {
                    properties["x"] = this.x;
                }
            }
            if (this.yString != null) {
                properties["y"] = this.yString;
            } else {
                if (this.y != null) {
                    properties["y"] = this.y;
                }
            }
            if (this.zString != null) {
                properties["z"] = this.zString;
            } else {
                if (this.z != null) {
                    properties["z"] = this.z;
                }
            }

            return properties;
        }

        public static Position FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new Position(
                new Func<float>(() =>
                {
                    return properties["x"] switch {
                        float v => v,
                        string v => float.Parse(v),
                        _ => 0
                    };
                })(),
                new Func<float>(() =>
                {
                    return properties["y"] switch {
                        float v => v,
                        string v => float.Parse(v),
                        _ => 0
                    };
                })(),
                new Func<float>(() =>
                {
                    return properties["z"] switch {
                        float v => v,
                        string v => float.Parse(v),
                        _ => 0
                    };
                })(),
                new PositionOptions {
                }
            );

            return model;
        }
    }
}
