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
    
    public enum PasswordEnableTwoFactorAuthentication {
        Rfc6238,
        Disable
    }

    public static class PasswordEnableTwoFactorAuthenticationExt
    {
        public static string Str(this PasswordEnableTwoFactorAuthentication self) {
            switch (self) {
                case PasswordEnableTwoFactorAuthentication.Rfc6238:
                    return "RFC6238";
                case PasswordEnableTwoFactorAuthentication.Disable:
                    return "Disable";
            }
            return "unknown";
        }

        public static PasswordEnableTwoFactorAuthentication New(string value) {
            switch (value) {
                case "RFC6238":
                    return PasswordEnableTwoFactorAuthentication.Rfc6238;
                case "Disable":
                    return PasswordEnableTwoFactorAuthentication.Disable;
            }
            return PasswordEnableTwoFactorAuthentication.Rfc6238;
        }
    }
}
