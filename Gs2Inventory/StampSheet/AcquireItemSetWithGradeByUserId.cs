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
using Gs2Cdk.Gs2Inventory.Model;

namespace Gs2Cdk.Gs2Inventory.StampSheet
{
    public class AcquireItemSetWithGradeByUserId : AcquireAction {
        private string namespaceName;
        private string inventoryName;
        private string itemName;
        private string userId;
        private string gradeModelId;
        private long gradeValue;
        private string? gradeValueString;


        public AcquireItemSetWithGradeByUserId(
            string namespaceName,
            string inventoryName,
            string itemName,
            string gradeModelId,
            long gradeValue,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.inventoryName = inventoryName;
            this.itemName = itemName;
            this.gradeModelId = gradeModelId;
            this.gradeValue = gradeValue;
            this.userId = userId;
        }


        public AcquireItemSetWithGradeByUserId(
            string namespaceName,
            string inventoryName,
            string itemName,
            string gradeModelId,
            string gradeValue,
            string userId = "#{userId}"
        ){

            this.namespaceName = namespaceName;
            this.inventoryName = inventoryName;
            this.itemName = itemName;
            this.gradeModelId = gradeModelId;
            this.gradeValueString = gradeValue;
            this.userId = userId;
        }

        public override Dictionary<string, object> Request(
        ){
            var properties = new Dictionary<string, object>();

            if (this.namespaceName != null) {
                properties["namespaceName"] = this.namespaceName;
            }
            if (this.inventoryName != null) {
                properties["inventoryName"] = this.inventoryName;
            }
            if (this.itemName != null) {
                properties["itemName"] = this.itemName;
            }
            if (this.userId != null) {
                properties["userId"] = this.userId;
            }
            if (this.gradeModelId != null) {
                properties["gradeModelId"] = this.gradeModelId;
            }
            if (this.gradeValueString != null) {
                properties["gradeValue"] = this.gradeValueString;
            } else {
                if (this.gradeValue != null) {
                    properties["gradeValue"] = this.gradeValue;
                }
            }

            return properties;
        }

        public static AcquireItemSetWithGradeByUserId FromProperties(Dictionary<string, object> properties) {
            try {
                return new AcquireItemSetWithGradeByUserId(
                    (string)properties["namespaceName"],
                    (string)properties["inventoryName"],
                    (string)properties["itemName"],
                    (string)properties["gradeModelId"],
                    new Func<long>(() =>
                    {
                        return properties["gradeValue"] switch {
                            long v => (long)v,
                            int v => (long)v,
                            float v => (long)v,
                            double v => (long)v,
                            string v => long.Parse(v),
                            _ => 0
                        };
                    })(),
                    new Func<string>(() =>
                    {
                        return properties.TryGetValue("userId", out var userId) ? userId as string : "#{userId}";
                    })()
                );
            } catch (Exception e) when (e is FormatException || e is OverflowException) {
                return new AcquireItemSetWithGradeByUserId(
                    properties["namespaceName"].ToString(),
                    properties["inventoryName"].ToString(),
                    properties["itemName"].ToString(),
                    properties["gradeModelId"].ToString(),
                    properties["gradeValue"].ToString(),
                    new Func<string>(() =>
                    {
                        return properties.TryGetValue("userId", out var userId) ? userId as string : "#{userId}";
                    })()
                );
            }
        }

        public override string Action() {
            return "Gs2Inventory:AcquireItemSetWithGradeByUserId";
        }

        public static string StaticAction() {
            return "Gs2Inventory:AcquireItemSetWithGradeByUserId";
        }
    }
}
