/*
 * Copyright 2016 Game Server Services, Inc. or its affiliates. All Rights
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
using Gs2Cdk.Core.Func;
using Gs2Cdk.Core.Model;
using Gs2Cdk.Gs2Log.Model;
using Gs2Cdk.Gs2Log.Ref;

namespace Gs2Cdk.Gs2Log.Resource
{
    public class Namespace : CdkResource
    {

        private readonly Stack _stack;
        private readonly string _name;
        private readonly string _description;
        private readonly string _type;
        private readonly string _gcpCredentialJson;
        private readonly string _bigQueryDatasetName;
        private readonly int? _logExpireDays;
        private readonly string _awsRegion;
        private readonly string _awsAccessKeyId;
        private readonly string _awsSecretAccessKey;
        private readonly string _firehoseStreamName;

        public Namespace(
                Stack stack,
                string name,
                string type,
                string gcpCredentialJson,
                string bigQueryDatasetName,
                int? logExpireDays,
                string awsRegion,
                string awsAccessKeyId,
                string awsSecretAccessKey,
                string firehoseStreamName,
                string description = null
        ): base("Log_Namespace_" + name) {
            this._stack = stack;
            this._name = name;
            this._description = description;
            this._type = type;
            this._gcpCredentialJson = gcpCredentialJson;
            this._bigQueryDatasetName = bigQueryDatasetName;
            this._logExpireDays = logExpireDays;
            this._awsRegion = awsRegion;
            this._awsAccessKeyId = awsAccessKeyId;
            this._awsSecretAccessKey = awsSecretAccessKey;
            this._firehoseStreamName = firehoseStreamName;

            stack.AddResource(this);
        }

        public override string ResourceType() {
            return "GS2::Log::Namespace";
        }

        public override Dictionary<string, object> Properties() {
            var properties = new Dictionary<string, object>();
            if (this._name != null) {
                properties["Name"] = this._name;
            }
            if (this._description != null) {
                properties["Description"] = this._description;
            }
            if (this._type != null) {
                properties["Type"] = this._type.ToString();
            }
            if (this._gcpCredentialJson != null) {
                properties["GcpCredentialJson"] = this._gcpCredentialJson;
            }
            if (this._bigQueryDatasetName != null) {
                properties["BigQueryDatasetName"] = this._bigQueryDatasetName;
            }
            if (this._logExpireDays != null) {
                properties["LogExpireDays"] = this._logExpireDays;
            }
            if (this._awsRegion != null) {
                properties["AwsRegion"] = this._awsRegion;
            }
            if (this._awsAccessKeyId != null) {
                properties["AwsAccessKeyId"] = this._awsAccessKeyId;
            }
            if (this._awsSecretAccessKey != null) {
                properties["AwsSecretAccessKey"] = this._awsSecretAccessKey;
            }
            if (this._firehoseStreamName != null) {
                properties["FirehoseStreamName"] = this._firehoseStreamName;
            }
            return properties;
        }

        public NamespaceRef Ref(
        ) {
            return new NamespaceRef(
                this._name
            );
        }

        public GetAttr GetAttrNamespaceId() {
            return new GetAttr(
                "Item.NamespaceId"
            );
        }
    }
}
