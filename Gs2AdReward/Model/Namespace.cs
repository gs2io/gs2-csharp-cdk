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
using Gs2Cdk.Core.Func;
using Gs2Cdk.Gs2AdReward.Ref;
using Gs2Cdk.Gs2AdReward.Model;
using Gs2Cdk.Gs2AdReward.Model.Options;

namespace Gs2Cdk.Gs2AdReward.Model
{
    public class Namespace : CdkResource {
        private Stack? stack;
        public string name;
        public string description;
        public TransactionSetting transactionSetting;
        public AdMob admob;
        public UnityAd unityAd;
        public AppLovinMax[] appLovinMaxes;
        public ScriptSetting acquirePointScript;
        public ScriptSetting consumePointScript;
        public NotificationSetting changePointNotification;
        public LogSetting logSetting;

        public Namespace(
            Stack stack,
            string name,
            NamespaceOptions options = null
        ): base(
            "AdReward_Namespace_" + name
        ){

            this.stack = stack;
            this.name = name;
            this.description = options?.description;
            this.transactionSetting = options?.transactionSetting;
            this.admob = options?.admob;
            this.unityAd = options?.unityAd;
            this.appLovinMaxes = options?.appLovinMaxes;
            this.acquirePointScript = options?.acquirePointScript;
            this.consumePointScript = options?.consumePointScript;
            this.changePointNotification = options?.changePointNotification;
            this.logSetting = options?.logSetting;
            stack.AddResource(
                this
            );
        }


        public string AlternateKeys(
        ){
            return "name";
        }

        public override string ResourceType(
        ){
            return "GS2::AdReward::Namespace";
        }

        public override Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.name != null) {
                properties["Name"] = this.name;
            }
            if (this.description != null) {
                properties["Description"] = this.description;
            }
            if (this.transactionSetting != null) {
                properties["TransactionSetting"] = this.transactionSetting?.Properties(
                );
            }
            if (this.admob != null) {
                properties["Admob"] = this.admob?.Properties(
                );
            }
            if (this.unityAd != null) {
                properties["UnityAd"] = this.unityAd?.Properties(
                );
            }
            if (this.appLovinMaxes != null) {
                properties["AppLovinMaxes"] = this.appLovinMaxes.Select(v => v?.Properties(
                        )).ToList();
            }
            if (this.acquirePointScript != null) {
                properties["AcquirePointScript"] = this.acquirePointScript?.Properties(
                );
            }
            if (this.consumePointScript != null) {
                properties["ConsumePointScript"] = this.consumePointScript?.Properties(
                );
            }
            if (this.changePointNotification != null) {
                properties["ChangePointNotification"] = this.changePointNotification?.Properties(
                );
            }
            if (this.logSetting != null) {
                properties["LogSetting"] = this.logSetting?.Properties(
                );
            }

            return properties;
        }

        public NamespaceRef Ref(
        ){
            return (new NamespaceRef(
                this.name
            ));
        }

        public GetAttr GetAttrNamespaceId(
        ){
            return (new GetAttr(
                this,
                "Item.NamespaceId",
                null
            ));
        }
    }
}
