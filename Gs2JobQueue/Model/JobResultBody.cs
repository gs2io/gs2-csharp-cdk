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
using Gs2Cdk.Gs2JobQueue.Model;
using Gs2Cdk.Gs2JobQueue.Model.Options;

namespace Gs2Cdk.Gs2JobQueue.Model
{
    public class JobResultBody {
        private int tryNumber;
        private string tryNumberString;
        private int statusCode;
        private string statusCodeString;
        private string result;

        public JobResultBody(
            int tryNumber,
            int statusCode,
            string result,
            JobResultBodyOptions options = null
        ){
            this.tryNumber = tryNumber;
            this.statusCode = statusCode;
            this.result = result;
        }


        public JobResultBody(
            string tryNumber,
            string statusCode,
            string result,
            JobResultBodyOptions options = null
        ){
            this.tryNumberString = tryNumber;
            this.statusCodeString = statusCode;
            this.result = result;
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.tryNumberString != null) {
                properties["tryNumber"] = this.tryNumberString;
            } else {
                if (this.tryNumber != null) {
                    properties["tryNumber"] = this.tryNumber;
                }
            }
            if (this.statusCodeString != null) {
                properties["statusCode"] = this.statusCodeString;
            } else {
                if (this.statusCode != null) {
                    properties["statusCode"] = this.statusCode;
                }
            }
            if (this.result != null) {
                properties["result"] = this.result;
            }

            return properties;
        }

        public static JobResultBody FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new JobResultBody(
                properties.TryGetValue("tryNumber", out var tryNumber) ? new Func<int>(() =>
                {
                    return tryNumber switch {
                        int v => v,
                        string v => int.Parse(v),
                        _ => 0
                    };
                })() : default,
                properties.TryGetValue("statusCode", out var statusCode) ? new Func<int>(() =>
                {
                    return statusCode switch {
                        int v => v,
                        string v => int.Parse(v),
                        _ => 0
                    };
                })() : default,
                properties.TryGetValue("result", out var result) ? new Func<string>(() =>
                {
                    return (string) result;
                })() : default,
                new JobResultBodyOptions {
                }
            );

            return model;
        }
    }
}
