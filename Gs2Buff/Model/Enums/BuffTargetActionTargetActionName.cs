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


namespace Gs2Cdk.Gs2Buff.Model.Enums
{
    
    public enum BuffTargetActionTargetActionName {
        Gs2ExperienceAddExperienceByUserId,
        Gs2ExperienceSubExperience,
        Gs2ExperienceSubExperienceByUserId,
        Gs2InventoryAcquireBigItemByUserId,
        Gs2InventoryAcquireItemSetByUserId,
        Gs2InventoryAcquireSimpleItemsByUserId,
        Gs2InventoryConsumeBigItem,
        Gs2InventoryConsumeBigItemByUserId,
        Gs2InventoryConsumeItemSet,
        Gs2InventoryConsumeItemSetByUserId,
        Gs2InventoryConsumeSimpleItems,
        Gs2InventoryConsumeSimpleItemsByUserId,
        Gs2LimitCountUp,
        Gs2LimitCountUpByUserId,
        Gs2Money2DepositByUserId,
        Gs2Money2Withdraw,
        Gs2Money2WithdrawByUserId,
        Gs2MoneyDepositByUserId,
        Gs2MoneyWithdraw,
        Gs2MoneyWithdrawByUserId,
        Gs2StaminaConsumeStamina,
        Gs2StaminaConsumeStaminaByUserId,
        Gs2StaminaRecoverStaminaByUserId
    }

    public static class BuffTargetActionTargetActionNameExt
    {
        public static string Str(this BuffTargetActionTargetActionName self) {
            switch (self) {
                case BuffTargetActionTargetActionName.Gs2ExperienceAddExperienceByUserId:
                    return "Gs2Experience:AddExperienceByUserId";
                case BuffTargetActionTargetActionName.Gs2ExperienceSubExperience:
                    return "Gs2Experience:SubExperience";
                case BuffTargetActionTargetActionName.Gs2ExperienceSubExperienceByUserId:
                    return "Gs2Experience:SubExperienceByUserId";
                case BuffTargetActionTargetActionName.Gs2InventoryAcquireBigItemByUserId:
                    return "Gs2Inventory:AcquireBigItemByUserId";
                case BuffTargetActionTargetActionName.Gs2InventoryAcquireItemSetByUserId:
                    return "Gs2Inventory:AcquireItemSetByUserId";
                case BuffTargetActionTargetActionName.Gs2InventoryAcquireSimpleItemsByUserId:
                    return "Gs2Inventory:AcquireSimpleItemsByUserId";
                case BuffTargetActionTargetActionName.Gs2InventoryConsumeBigItem:
                    return "Gs2Inventory:ConsumeBigItem";
                case BuffTargetActionTargetActionName.Gs2InventoryConsumeBigItemByUserId:
                    return "Gs2Inventory:ConsumeBigItemByUserId";
                case BuffTargetActionTargetActionName.Gs2InventoryConsumeItemSet:
                    return "Gs2Inventory:ConsumeItemSet";
                case BuffTargetActionTargetActionName.Gs2InventoryConsumeItemSetByUserId:
                    return "Gs2Inventory:ConsumeItemSetByUserId";
                case BuffTargetActionTargetActionName.Gs2InventoryConsumeSimpleItems:
                    return "Gs2Inventory:ConsumeSimpleItems";
                case BuffTargetActionTargetActionName.Gs2InventoryConsumeSimpleItemsByUserId:
                    return "Gs2Inventory:ConsumeSimpleItemsByUserId";
                case BuffTargetActionTargetActionName.Gs2LimitCountUp:
                    return "Gs2Limit:CountUp";
                case BuffTargetActionTargetActionName.Gs2LimitCountUpByUserId:
                    return "Gs2Limit:CountUpByUserId";
                case BuffTargetActionTargetActionName.Gs2Money2DepositByUserId:
                    return "Gs2Money2:DepositByUserId";
                case BuffTargetActionTargetActionName.Gs2Money2Withdraw:
                    return "Gs2Money2:Withdraw";
                case BuffTargetActionTargetActionName.Gs2Money2WithdrawByUserId:
                    return "Gs2Money2:WithdrawByUserId";
                case BuffTargetActionTargetActionName.Gs2MoneyDepositByUserId:
                    return "Gs2Money:DepositByUserId";
                case BuffTargetActionTargetActionName.Gs2MoneyWithdraw:
                    return "Gs2Money:Withdraw";
                case BuffTargetActionTargetActionName.Gs2MoneyWithdrawByUserId:
                    return "Gs2Money:WithdrawByUserId";
                case BuffTargetActionTargetActionName.Gs2StaminaConsumeStamina:
                    return "Gs2Stamina:ConsumeStamina";
                case BuffTargetActionTargetActionName.Gs2StaminaConsumeStaminaByUserId:
                    return "Gs2Stamina:ConsumeStaminaByUserId";
                case BuffTargetActionTargetActionName.Gs2StaminaRecoverStaminaByUserId:
                    return "Gs2Stamina:RecoverStaminaByUserId";
            }
            return "unknown";
        }

        public static BuffTargetActionTargetActionName New(string value) {
            switch (value) {
                case "Gs2Experience:AddExperienceByUserId":
                    return BuffTargetActionTargetActionName.Gs2ExperienceAddExperienceByUserId;
                case "Gs2Experience:SubExperience":
                    return BuffTargetActionTargetActionName.Gs2ExperienceSubExperience;
                case "Gs2Experience:SubExperienceByUserId":
                    return BuffTargetActionTargetActionName.Gs2ExperienceSubExperienceByUserId;
                case "Gs2Inventory:AcquireBigItemByUserId":
                    return BuffTargetActionTargetActionName.Gs2InventoryAcquireBigItemByUserId;
                case "Gs2Inventory:AcquireItemSetByUserId":
                    return BuffTargetActionTargetActionName.Gs2InventoryAcquireItemSetByUserId;
                case "Gs2Inventory:AcquireSimpleItemsByUserId":
                    return BuffTargetActionTargetActionName.Gs2InventoryAcquireSimpleItemsByUserId;
                case "Gs2Inventory:ConsumeBigItem":
                    return BuffTargetActionTargetActionName.Gs2InventoryConsumeBigItem;
                case "Gs2Inventory:ConsumeBigItemByUserId":
                    return BuffTargetActionTargetActionName.Gs2InventoryConsumeBigItemByUserId;
                case "Gs2Inventory:ConsumeItemSet":
                    return BuffTargetActionTargetActionName.Gs2InventoryConsumeItemSet;
                case "Gs2Inventory:ConsumeItemSetByUserId":
                    return BuffTargetActionTargetActionName.Gs2InventoryConsumeItemSetByUserId;
                case "Gs2Inventory:ConsumeSimpleItems":
                    return BuffTargetActionTargetActionName.Gs2InventoryConsumeSimpleItems;
                case "Gs2Inventory:ConsumeSimpleItemsByUserId":
                    return BuffTargetActionTargetActionName.Gs2InventoryConsumeSimpleItemsByUserId;
                case "Gs2Limit:CountUp":
                    return BuffTargetActionTargetActionName.Gs2LimitCountUp;
                case "Gs2Limit:CountUpByUserId":
                    return BuffTargetActionTargetActionName.Gs2LimitCountUpByUserId;
                case "Gs2Money2:DepositByUserId":
                    return BuffTargetActionTargetActionName.Gs2Money2DepositByUserId;
                case "Gs2Money2:Withdraw":
                    return BuffTargetActionTargetActionName.Gs2Money2Withdraw;
                case "Gs2Money2:WithdrawByUserId":
                    return BuffTargetActionTargetActionName.Gs2Money2WithdrawByUserId;
                case "Gs2Money:DepositByUserId":
                    return BuffTargetActionTargetActionName.Gs2MoneyDepositByUserId;
                case "Gs2Money:Withdraw":
                    return BuffTargetActionTargetActionName.Gs2MoneyWithdraw;
                case "Gs2Money:WithdrawByUserId":
                    return BuffTargetActionTargetActionName.Gs2MoneyWithdrawByUserId;
                case "Gs2Stamina:ConsumeStamina":
                    return BuffTargetActionTargetActionName.Gs2StaminaConsumeStamina;
                case "Gs2Stamina:ConsumeStaminaByUserId":
                    return BuffTargetActionTargetActionName.Gs2StaminaConsumeStaminaByUserId;
                case "Gs2Stamina:RecoverStaminaByUserId":
                    return BuffTargetActionTargetActionName.Gs2StaminaRecoverStaminaByUserId;
            }
            return BuffTargetActionTargetActionName.Gs2ExperienceAddExperienceByUserId;
        }
    }
}


