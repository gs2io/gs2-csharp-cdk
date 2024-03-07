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
using Gs2Cdk.Gs2Inbox.Model;

namespace Gs2Cdk.Gs2Inbox.StampSheet
{
    public class DeleteMessageByUserId : ConsumeAction {
        private string namespaceName;
        private string userId;
        private string messageName;


        public DeleteMessageByUserId(
            string namespaceName,
            string messageName = null,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.messageName = messageName;
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

            return properties;
        }

        public static DeleteMessageByUserId FromProperties(Dictionary<string, object> properties) {
            try {
                return new DeleteMessageByUserId(
                    (string)properties["namespaceName"],
                    new Func<string>(() =>
                    {
                        return properties.TryGetValue("messageName", out var messageName) ? messageName as string : null;
                    })(),
                    new Func<string>(() =>
                    {
                        return properties.TryGetValue("userId", out var userId) ? userId as string : "#{userId}";
                    })()
                );
            } catch (Exception e) when (e is FormatException || e is OverflowException) {
                return new DeleteMessageByUserId(
                    properties["namespaceName"].ToString(),
                    new Func<string>(() =>
                    {
                        return properties.TryGetValue("messageName", out var messageName) ? messageName.ToString() : null;
                    })(),
                    new Func<string>(() =>
                    {
                        return properties.TryGetValue("userId", out var userId) ? userId as string : "#{userId}";
                    })()
                );
            }
        }

        public override string Action() {
            return "Gs2Inbox:DeleteMessageByUserId";
        }

        public static string StaticAction() {
            return "Gs2Inbox:DeleteMessageByUserId";
        }
    }
}
