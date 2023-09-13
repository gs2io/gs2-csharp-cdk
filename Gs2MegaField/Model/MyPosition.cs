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
            if (this.r != null) {
                properties["r"] = this.r;
            }

            return properties;
        }

        public static MyPosition FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new MyPosition(
                new Func<Position>(() =>
                {
                    return properties["position"] switch {
                        Position v => v,
                        Dictionary<string, object> v => Position.FromProperties(v),
                        _ => null
                    };
                })(),
                new Func<Vector>(() =>
                {
                    return properties["vector"] switch {
                        Vector v => v,
                        Dictionary<string, object> v => Vector.FromProperties(v),
                        _ => null
                    };
                })(),
                new Func<float?>(() =>
                {
                    return properties["r"] switch {
                        float v => v,
                        string v => float.Parse(v),
                        _ => 0
                    };
                })(),
                new MyPositionOptions {
                }
            );

            return model;
        }
    }
}
