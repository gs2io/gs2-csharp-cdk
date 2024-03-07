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
using Gs2Cdk.Gs2Money.Model;

namespace Gs2Cdk.Gs2Money.StampSheet
{
    public class RecordReceipt : ConsumeAction {
        private string namespaceName;
        private string userId;
        private string contentsId;
        private string receipt;


        public RecordReceipt(
            string namespaceName,
            string contentsId,
            string receipt,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.contentsId = contentsId;
            this.receipt = receipt;
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
            if (this.contentsId != null) {
                properties["contentsId"] = this.contentsId;
            }
            if (this.receipt != null) {
                properties["receipt"] = this.receipt;
            }

            return properties;
        }

        public static RecordReceipt FromProperties(Dictionary<string, object> properties) {
            try {
                return new RecordReceipt(
                    (string)properties["namespaceName"],
                    (string)properties["contentsId"],
                    (string)properties["receipt"],
                    new Func<string>(() =>
                    {
                        return properties.TryGetValue("userId", out var userId) ? userId as string : "#{userId}";
                    })()
                );
            } catch (Exception e) when (e is FormatException || e is OverflowException) {
                return new RecordReceipt(
                    properties["namespaceName"].ToString(),
                    properties["contentsId"].ToString(),
                    properties["receipt"].ToString(),
                    new Func<string>(() =>
                    {
                        return properties.TryGetValue("userId", out var userId) ? userId as string : "#{userId}";
                    })()
                );
            }
        }

        public override string Action() {
            return "Gs2Money:RecordReceipt";
        }

        public static string StaticAction() {
            return "Gs2Money:RecordReceipt";
        }
    }
}
