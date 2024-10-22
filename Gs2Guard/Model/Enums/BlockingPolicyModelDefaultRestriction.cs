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
    
    public enum BlockingPolicyModelDefaultRestriction {
        Allow,
        Deny
    }

    public static class BlockingPolicyModelDefaultRestrictionExt
    {
        public static string Str(this BlockingPolicyModelDefaultRestriction self) {
            switch (self) {
                case BlockingPolicyModelDefaultRestriction.Allow:
                    return "Allow";
                case BlockingPolicyModelDefaultRestriction.Deny:
                    return "Deny";
            }
            return "unknown";
        }

        public static BlockingPolicyModelDefaultRestriction New(string value) {
            switch (value) {
                case "Allow":
                    return BlockingPolicyModelDefaultRestriction.Allow;
                case "Deny":
                    return BlockingPolicyModelDefaultRestriction.Deny;
            }
            return BlockingPolicyModelDefaultRestriction.Allow;
        }
    }
}
