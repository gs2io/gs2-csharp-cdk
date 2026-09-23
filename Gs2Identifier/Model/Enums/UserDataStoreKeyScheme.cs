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
    
    public enum UserDataStoreKeyScheme {
        V1,
        V2
    }

    public static class UserDataStoreKeySchemeExt
    {
        public static string Str(this UserDataStoreKeyScheme self) {
            switch (self) {
                case UserDataStoreKeyScheme.V1:
                    return "v1";
                case UserDataStoreKeyScheme.V2:
                    return "v2";
            }
            return "unknown";
        }

        public static UserDataStoreKeyScheme? New(string value) {
            switch (value) {
                case "v1":
                    return UserDataStoreKeyScheme.V1;
                case "v2":
                    return UserDataStoreKeyScheme.V2;
            }
            return null;
        }
    }
}
