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
using Gs2Cdk.Gs2Log.Ref;
using Gs2Cdk.Gs2Log.Model;
using Gs2Cdk.Gs2Log.Model.Enums;
using Gs2Cdk.Gs2Log.Model.Options;

namespace Gs2Cdk.Gs2Log.Model
{
    public class Namespace : CdkResource {
        private Stack? stack;
        public string name;
        public string description;
        public NamespaceType? type;
        public string gcpCredentialJson;
        public string bigQueryDatasetName;
        public int? logExpireDays;
        public string awsRegion;
        public string awsAccessKeyId;
        public string awsSecretAccessKey;
        public string firehoseStreamName;

        public Namespace(
            Stack stack,
            string name,
            NamespaceOptions options = null
        ): base(
            "Log_Namespace_" + name
        ){

            this.stack = stack;
            this.name = name;
            this.description = options?.description;
            this.type = options?.type;
            this.gcpCredentialJson = options?.gcpCredentialJson;
            this.bigQueryDatasetName = options?.bigQueryDatasetName;
            this.logExpireDays = options?.logExpireDays;
            this.awsRegion = options?.awsRegion;
            this.awsAccessKeyId = options?.awsAccessKeyId;
            this.awsSecretAccessKey = options?.awsSecretAccessKey;
            this.firehoseStreamName = options?.firehoseStreamName;
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
            return "GS2::Log::Namespace";
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
            if (this.type != null) {
                properties["Type"] = this.type.Value.Str(
                );
            }
            if (this.gcpCredentialJson != null) {
                properties["GcpCredentialJson"] = this.gcpCredentialJson;
            }
            if (this.bigQueryDatasetName != null) {
                properties["BigQueryDatasetName"] = this.bigQueryDatasetName;
            }
            if (this.logExpireDays != null) {
                properties["LogExpireDays"] = this.logExpireDays;
            }
            if (this.awsRegion != null) {
                properties["AwsRegion"] = this.awsRegion;
            }
            if (this.awsAccessKeyId != null) {
                properties["AwsAccessKeyId"] = this.awsAccessKeyId;
            }
            if (this.awsSecretAccessKey != null) {
                properties["AwsSecretAccessKey"] = this.awsSecretAccessKey;
            }
            if (this.firehoseStreamName != null) {
                properties["FirehoseStreamName"] = this.firehoseStreamName;
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
