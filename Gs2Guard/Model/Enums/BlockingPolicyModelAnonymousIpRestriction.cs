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


namespace Gs2Cdk.Gs2Guard.Model.Enums
{
    
    public enum BlockingPolicyModelAnonymousIpRestriction {
        Deny
    }

    public static class BlockingPolicyModelAnonymousIpRestrictionExt
    {
        public static string Str(this BlockingPolicyModelAnonymousIpRestriction self) {
            switch (self) {
                case BlockingPolicyModelAnonymousIpRestriction.Deny:
                    return "Deny";
            }
            return "unknown";
        }

        public static BlockingPolicyModelAnonymousIpRestriction New(string value) {
            switch (value) {
                case "Deny":
                    return BlockingPolicyModelAnonymousIpRestriction.Deny;
            }
            return BlockingPolicyModelAnonymousIpRestriction.Deny;
        }
    }
}
