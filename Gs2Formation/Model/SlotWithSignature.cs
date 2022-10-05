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
using Gs2Cdk.Gs2Formation.Resource;

namespace Gs2Cdk.Gs2Formation.Model
{

    public static class SlotWithSignaturePropertyTypeExt
    {
        public static string ToString(this SlotWithSignature.PropertyType self)
        {
            switch (self) {
                case SlotWithSignature.PropertyType.Gs2Inventory:
                    return "gs2_inventory";
                case SlotWithSignature.PropertyType.Gs2Dictionary:
                    return "gs2_dictionary";
            }
            return "unknown";
        }
    }

    public class SlotWithSignature
    {

        public enum PropertyType
        {
            Gs2Inventory,
            Gs2Dictionary
        }
	    private readonly string _name;
	    private readonly PropertyType _propertyType;
	    private readonly string _body;
	    private readonly string _signature;
	    private readonly string _metadata;

        public SlotWithSignature(
                string name,
                PropertyType propertyType,
                string body,
                string signature,
                string metadata = null
        )
        {
            this._name = name;
            this._propertyType = propertyType;
            this._body = body;
            this._signature = signature;
            this._metadata = metadata;
        }

        public Dictionary<string, object> Properties() {
            var properties = new Dictionary<string, object>();
            if (this._name != null) {
                properties["Name"] = this._name;
            }
            if (this._propertyType != null) {
                properties["PropertyType"] = this._propertyType.ToString();
            }
            if (this._body != null) {
                properties["Body"] = this._body;
            }
            if (this._signature != null) {
                properties["Signature"] = this._signature;
            }
            if (this._metadata != null) {
                properties["Metadata"] = this._metadata;
            }
            return properties;
        }
    }
}
