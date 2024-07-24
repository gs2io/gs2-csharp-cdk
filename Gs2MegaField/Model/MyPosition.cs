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
    public class MyPosition {
        private Position position;
        private Vector vector;
        private float? r;
        private string rString;

        public MyPosition(
            Position position,
            Vector vector,
            float? r,
            MyPositionOptions options = null
        ){
            this.position = position;
            this.vector = vector;
            this.r = r;
        }


        public MyPosition(
            Position position,
            Vector vector,
            string r,
            MyPositionOptions options = null
        ){
            this.position = position;
            this.vector = vector;
            this.rString = r;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.position != null) {
                properties["position"] = this.position?.Properties(
                );
            }
            if (this.vector != null) {
                properties["vector"] = this.vector?.Properties(
                );
            }
            if (this.rString != null) {
                properties["r"] = this.rString;
            } else {
                if (this.r != null) {
                    properties["r"] = this.r;
                }
            }

            return properties;
        }

        public static MyPosition FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new MyPosition(
                properties.TryGetValue("position", out var position) ? new Func<Position>(() =>
                {
                    return position switch {
                        Position v => v,
                        Position[] v => v.Length > 0 ? v.First() : null,
                        Dictionary<string, object> v => Position.FromProperties(v),
                        Dictionary<string, object>[] v => v.Length > 0 ? Position.FromProperties(v.First()) : null,
                        _ => null
                    };
                })() : null,
                properties.TryGetValue("vector", out var vector) ? new Func<Vector>(() =>
                {
                    return vector switch {
                        Vector v => v,
                        Vector[] v => v.Length > 0 ? v.First() : null,
                        Dictionary<string, object> v => Vector.FromProperties(v),
                        Dictionary<string, object>[] v => v.Length > 0 ? Vector.FromProperties(v.First()) : null,
                        _ => null
                    };
                })() : null,
                properties.TryGetValue("r", out var r) ? new Func<float?>(() =>
                {
                    return r switch {
                        float v => v,
                        string v => float.Parse(v),
                        _ => 0
                    };
                })() : default,
                new MyPositionOptions {
                }
            );

            return model;
        }
    }
}
