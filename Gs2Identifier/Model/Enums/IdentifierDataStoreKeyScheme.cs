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


namespace Gs2Cdk.Gs2Identifier.Model.Enums
{
    
    public enum IdentifierDataStoreKeyScheme {
        V1,
        V2
    }

    public static class IdentifierDataStoreKeySchemeExt
    {
        public static string Str(this IdentifierDataStoreKeyScheme self) {
            switch (self) {
                case IdentifierDataStoreKeyScheme.V1:
                    return "v1";
                case IdentifierDataStoreKeyScheme.V2:
                    return "v2";
            }
            return "unknown";
        }

        public static IdentifierDataStoreKeyScheme? New(string value) {
            switch (value) {
                case "v1":
                    return IdentifierDataStoreKeyScheme.V1;
                case "v2":
                    return IdentifierDataStoreKeyScheme.V2;
            }
            return null;
        }
    }
}
