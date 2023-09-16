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


namespace Gs2Cdk.Gs2Log.Model.Enums
{
    
    public enum NamespaceType {
        Gs2,
        Bigquery,
        Firehose
    }

    public static class NamespaceTypeExt
    {
        public static string Str(this NamespaceType self) {
            switch (self) {
                case NamespaceType.Gs2:
                    return "gs2";
                case NamespaceType.Bigquery:
                    return "bigquery";
                case NamespaceType.Firehose:
                    return "firehose";
            }
            return "unknown";
        }

        public static NamespaceType New(string value) {
            switch (value) {
                case "gs2":
                    return NamespaceType.Gs2;
                case "bigquery":
                    return NamespaceType.Bigquery;
                case "firehose":
                    return NamespaceType.Firehose;
            }
            return NamespaceType.Gs2;
        }
    }
}
