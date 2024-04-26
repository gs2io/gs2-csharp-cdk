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
using Gs2Cdk.Gs2Dictionary.Model;

namespace Gs2Cdk.Gs2Dictionary.StampSheet
{
    public class DeleteEntriesByUserId : ConsumeAction {
        private string namespaceName;
        private string userId;
        private string[] entryModelNames;
        private string timeOffsetToken;


        public DeleteEntriesByUserId(
            string namespaceName,
            string[] entryModelNames = null,
            string timeOffsetToken = null,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.entryModelNames = entryModelNames;
            this.timeOffsetToken = timeOffsetToken;
            this.userId = userId;
        }

        public override Dictionary<string, object> Request(
        ){
            var properties = new Dictionary<string, object>();

            if (this.namespaceName != null) {
                properties["namespaceName"] = this.namespaceName;
            }
            if (this.userId != null) {
                properties["userId"] = this.userId;
            }
            if (this.entryModelNames != null) {
                properties["entryModelNames"] = this.entryModelNames;
            }
            if (this.timeOffsetToken != null) {
                properties["timeOffsetToken"] = this.timeOffsetToken;
            }

            return properties;
        }

        public static DeleteEntriesByUserId FromProperties(Dictionary<string, object> properties) {
            try {
                return new DeleteEntriesByUserId(
                    (string)properties["namespaceName"],
                    new Func<string[]>(() =>
                    {
                        return properties.TryGetValue("entryModelNames", out var entryModelNames) ? entryModelNames switch {
                            string[] v => v.ToArray(),
                            List<string> v => v.ToArray(),
                            object[] v => v.Select(v2 => v2?.ToString()).ToArray(),
                            { } v => new []{ v.ToString() },
                            _ => null
                        } : null;
                    })(),
                    new Func<string>(() =>
                    {
                        return properties.TryGetValue("timeOffsetToken", out var timeOffsetToken) ? timeOffsetToken as string : null;
                    })(),
                    new Func<string>(() =>
                    {
                        return properties.TryGetValue("userId", out var userId) ? userId as string : "#{userId}";
                    })()
                );
            } catch (Exception e) when (e is FormatException || e is OverflowException) {
                return new DeleteEntriesByUserId(
                    properties["namespaceName"].ToString(),
                    new Func<string[]>(() =>
                    {
                        return properties.TryGetValue("entryModelNames", out var entryModelNames) ? entryModelNames switch {
                            string[] v => v.ToArray(),
                            List<string> v => v.ToArray(),
                            object[] v => v.Select(v2 => v2?.ToString()).ToArray(),
                            { } v => new []{ v.ToString() },
                            _ => null
                        } : null;
                    })(),
                    new Func<string>(() =>
                    {
                        return properties.TryGetValue("timeOffsetToken", out var timeOffsetToken) ? timeOffsetToken.ToString() : null;
                    })(),
                    new Func<string>(() =>
                    {
                        return properties.TryGetValue("userId", out var userId) ? userId as string : "#{userId}";
                    })()
                );
            }
        }

        public override string Action() {
            return "Gs2Dictionary:DeleteEntriesByUserId";
        }

        public static string StaticAction() {
            return "Gs2Dictionary:DeleteEntriesByUserId";
        }
    }
}
