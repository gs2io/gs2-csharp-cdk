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


namespace Gs2Cdk.Gs2Formation.Model.Enums
{
    
    public enum SlotWithSignaturePropertyType {
        Gs2Inventory,
        Gs2SimpleInventory,
        Gs2Dictionary
    }

    public static class SlotWithSignaturePropertyTypeExt
    {
        public static string Str(this SlotWithSignaturePropertyType self) {
            switch (self) {
                case SlotWithSignaturePropertyType.Gs2Inventory:
                    return "gs2_inventory";
                case SlotWithSignaturePropertyType.Gs2SimpleInventory:
                    return "gs2_simple_inventory";
                case SlotWithSignaturePropertyType.Gs2Dictionary:
                    return "gs2_dictionary";
            }
            return "unknown";
        }
    }
}
