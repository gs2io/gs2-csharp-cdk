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
    
    public enum BuffTargetModelTargetModelName {
        Gs2ExchangeIncrementalRateModel,
        Gs2ExchangeRateModel,
        Gs2ExperienceExperienceModel,
        Gs2ExperienceStatus,
        Gs2FormationMold,
        Gs2FormationMoldModel,
        Gs2IdleCategoryModel,
        Gs2IdleStatus,
        Gs2InventoryBigInventoryModel,
        Gs2InventoryBigItemModel,
        Gs2InventoryInventory,
        Gs2InventoryInventoryModel,
        Gs2InventoryItemModel,
        Gs2InventorySimpleInventoryModel,
        Gs2InventorySimpleItemModel,
        Gs2LimitCounter,
        Gs2LimitLimitModel,
        Gs2LoginRewardBonusModel,
        Gs2MissionMissionGroupModel,
        Gs2MissionMissionTaskModel,
        Gs2MoneyWallet,
        Gs2QuestQuestGroupModel,
        Gs2QuestQuestModel,
        Gs2ShowcaseDisplayItem,
        Gs2ShowcaseRandomDisplayItemModel,
        Gs2ShowcaseRandomShowcase,
        Gs2ShowcaseShowcase,
        Gs2SkillTreeNodeModel,
        Gs2StaminaStamina,
        Gs2StaminaStaminaModel
    }

    public static class BuffTargetModelTargetModelNameExt
    {
        public static string Str(this BuffTargetModelTargetModelName self) {
            switch (self) {
                case BuffTargetModelTargetModelName.Gs2ExchangeIncrementalRateModel:
                    return "Gs2Exchange:IncrementalRateModel";
                case BuffTargetModelTargetModelName.Gs2ExchangeRateModel:
                    return "Gs2Exchange:RateModel";
                case BuffTargetModelTargetModelName.Gs2ExperienceExperienceModel:
                    return "Gs2Experience:ExperienceModel";
                case BuffTargetModelTargetModelName.Gs2ExperienceStatus:
                    return "Gs2Experience:Status";
                case BuffTargetModelTargetModelName.Gs2FormationMold:
                    return "Gs2Formation:Mold";
                case BuffTargetModelTargetModelName.Gs2FormationMoldModel:
                    return "Gs2Formation:MoldModel";
                case BuffTargetModelTargetModelName.Gs2IdleCategoryModel:
                    return "Gs2Idle:CategoryModel";
                case BuffTargetModelTargetModelName.Gs2IdleStatus:
                    return "Gs2Idle:Status";
                case BuffTargetModelTargetModelName.Gs2InventoryBigInventoryModel:
                    return "Gs2Inventory:BigInventoryModel";
                case BuffTargetModelTargetModelName.Gs2InventoryBigItemModel:
                    return "Gs2Inventory:BigItemModel";
                case BuffTargetModelTargetModelName.Gs2InventoryInventory:
                    return "Gs2Inventory:Inventory";
                case BuffTargetModelTargetModelName.Gs2InventoryInventoryModel:
                    return "Gs2Inventory:InventoryModel";
                case BuffTargetModelTargetModelName.Gs2InventoryItemModel:
                    return "Gs2Inventory:ItemModel";
                case BuffTargetModelTargetModelName.Gs2InventorySimpleInventoryModel:
                    return "Gs2Inventory:SimpleInventoryModel";
                case BuffTargetModelTargetModelName.Gs2InventorySimpleItemModel:
                    return "Gs2Inventory:SimpleItemModel";
                case BuffTargetModelTargetModelName.Gs2LimitCounter:
                    return "Gs2Limit:Counter";
                case BuffTargetModelTargetModelName.Gs2LimitLimitModel:
                    return "Gs2Limit:LimitModel";
                case BuffTargetModelTargetModelName.Gs2LoginRewardBonusModel:
                    return "Gs2LoginReward:BonusModel";
                case BuffTargetModelTargetModelName.Gs2MissionMissionGroupModel:
                    return "Gs2Mission:MissionGroupModel";
                case BuffTargetModelTargetModelName.Gs2MissionMissionTaskModel:
                    return "Gs2Mission:MissionTaskModel";
                case BuffTargetModelTargetModelName.Gs2MoneyWallet:
                    return "Gs2Money:Wallet";
                case BuffTargetModelTargetModelName.Gs2QuestQuestGroupModel:
                    return "Gs2Quest:QuestGroupModel";
                case BuffTargetModelTargetModelName.Gs2QuestQuestModel:
                    return "Gs2Quest:QuestModel";
                case BuffTargetModelTargetModelName.Gs2ShowcaseDisplayItem:
                    return "Gs2Showcase:DisplayItem";
                case BuffTargetModelTargetModelName.Gs2ShowcaseRandomDisplayItemModel:
                    return "Gs2Showcase:RandomDisplayItemModel";
                case BuffTargetModelTargetModelName.Gs2ShowcaseRandomShowcase:
                    return "Gs2Showcase:RandomShowcase";
                case BuffTargetModelTargetModelName.Gs2ShowcaseShowcase:
                    return "Gs2Showcase:Showcase";
                case BuffTargetModelTargetModelName.Gs2SkillTreeNodeModel:
                    return "Gs2SkillTree:NodeModel";
                case BuffTargetModelTargetModelName.Gs2StaminaStamina:
                    return "Gs2Stamina:Stamina";
                case BuffTargetModelTargetModelName.Gs2StaminaStaminaModel:
                    return "Gs2Stamina:StaminaModel";
            }
            return "unknown";
        }

        public static BuffTargetModelTargetModelName New(string value) {
            switch (value) {
                case "Gs2Exchange:IncrementalRateModel":
                    return BuffTargetModelTargetModelName.Gs2ExchangeIncrementalRateModel;
                case "Gs2Exchange:RateModel":
                    return BuffTargetModelTargetModelName.Gs2ExchangeRateModel;
                case "Gs2Experience:ExperienceModel":
                    return BuffTargetModelTargetModelName.Gs2ExperienceExperienceModel;
                case "Gs2Experience:Status":
                    return BuffTargetModelTargetModelName.Gs2ExperienceStatus;
                case "Gs2Formation:Mold":
                    return BuffTargetModelTargetModelName.Gs2FormationMold;
                case "Gs2Formation:MoldModel":
                    return BuffTargetModelTargetModelName.Gs2FormationMoldModel;
                case "Gs2Idle:CategoryModel":
                    return BuffTargetModelTargetModelName.Gs2IdleCategoryModel;
                case "Gs2Idle:Status":
                    return BuffTargetModelTargetModelName.Gs2IdleStatus;
                case "Gs2Inventory:BigInventoryModel":
                    return BuffTargetModelTargetModelName.Gs2InventoryBigInventoryModel;
                case "Gs2Inventory:BigItemModel":
                    return BuffTargetModelTargetModelName.Gs2InventoryBigItemModel;
                case "Gs2Inventory:Inventory":
                    return BuffTargetModelTargetModelName.Gs2InventoryInventory;
                case "Gs2Inventory:InventoryModel":
                    return BuffTargetModelTargetModelName.Gs2InventoryInventoryModel;
                case "Gs2Inventory:ItemModel":
                    return BuffTargetModelTargetModelName.Gs2InventoryItemModel;
                case "Gs2Inventory:SimpleInventoryModel":
                    return BuffTargetModelTargetModelName.Gs2InventorySimpleInventoryModel;
                case "Gs2Inventory:SimpleItemModel":
                    return BuffTargetModelTargetModelName.Gs2InventorySimpleItemModel;
                case "Gs2Limit:Counter":
                    return BuffTargetModelTargetModelName.Gs2LimitCounter;
                case "Gs2Limit:LimitModel":
                    return BuffTargetModelTargetModelName.Gs2LimitLimitModel;
                case "Gs2LoginReward:BonusModel":
                    return BuffTargetModelTargetModelName.Gs2LoginRewardBonusModel;
                case "Gs2Mission:MissionGroupModel":
                    return BuffTargetModelTargetModelName.Gs2MissionMissionGroupModel;
                case "Gs2Mission:MissionTaskModel":
                    return BuffTargetModelTargetModelName.Gs2MissionMissionTaskModel;
                case "Gs2Money:Wallet":
                    return BuffTargetModelTargetModelName.Gs2MoneyWallet;
                case "Gs2Quest:QuestGroupModel":
                    return BuffTargetModelTargetModelName.Gs2QuestQuestGroupModel;
                case "Gs2Quest:QuestModel":
                    return BuffTargetModelTargetModelName.Gs2QuestQuestModel;
                case "Gs2Showcase:DisplayItem":
                    return BuffTargetModelTargetModelName.Gs2ShowcaseDisplayItem;
                case "Gs2Showcase:RandomDisplayItemModel":
                    return BuffTargetModelTargetModelName.Gs2ShowcaseRandomDisplayItemModel;
                case "Gs2Showcase:RandomShowcase":
                    return BuffTargetModelTargetModelName.Gs2ShowcaseRandomShowcase;
                case "Gs2Showcase:Showcase":
                    return BuffTargetModelTargetModelName.Gs2ShowcaseShowcase;
                case "Gs2SkillTree:NodeModel":
                    return BuffTargetModelTargetModelName.Gs2SkillTreeNodeModel;
                case "Gs2Stamina:Stamina":
                    return BuffTargetModelTargetModelName.Gs2StaminaStamina;
                case "Gs2Stamina:StaminaModel":
                    return BuffTargetModelTargetModelName.Gs2StaminaStaminaModel;
            }
            return BuffTargetModelTargetModelName.Gs2ExchangeIncrementalRateModel;
        }
    }
}
