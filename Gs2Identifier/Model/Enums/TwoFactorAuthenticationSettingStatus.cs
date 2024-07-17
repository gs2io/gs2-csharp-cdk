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
    
    public enum TwoFactorAuthenticationSettingStatus {
        Verifying,
        Enable
    }

    public static class TwoFactorAuthenticationSettingStatusExt
    {
        public static string Str(this TwoFactorAuthenticationSettingStatus self) {
            switch (self) {
                case TwoFactorAuthenticationSettingStatus.Verifying:
                    return "Verifying";
                case TwoFactorAuthenticationSettingStatus.Enable:
                    return "Enable";
            }
            return "unknown";
        }

        public static TwoFactorAuthenticationSettingStatus New(string value) {
            switch (value) {
                case "Verifying":
                    return TwoFactorAuthenticationSettingStatus.Verifying;
                case "Enable":
                    return TwoFactorAuthenticationSettingStatus.Enable;
            }
            return TwoFactorAuthenticationSettingStatus.Verifying;
        }
    }
}
