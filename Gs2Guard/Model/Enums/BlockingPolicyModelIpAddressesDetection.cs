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
    
    public enum BlockingPolicyModelIpAddressesDetection {
        Enable,
        Disable
    }

    public static class BlockingPolicyModelIpAddressesDetectionExt
    {
        public static string Str(this BlockingPolicyModelIpAddressesDetection self) {
            switch (self) {
                case BlockingPolicyModelIpAddressesDetection.Enable:
                    return "Enable";
                case BlockingPolicyModelIpAddressesDetection.Disable:
                    return "Disable";
            }
            return "unknown";
        }

        public static BlockingPolicyModelIpAddressesDetection New(string value) {
            switch (value) {
                case "Enable":
                    return BlockingPolicyModelIpAddressesDetection.Enable;
                case "Disable":
                    return BlockingPolicyModelIpAddressesDetection.Disable;
            }
            return BlockingPolicyModelIpAddressesDetection.Enable;
        }
    }
}
