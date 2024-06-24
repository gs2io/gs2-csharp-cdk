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
        Gs2AdRewardAcquirePointByUserId,
        Gs2DictionaryAddEntriesByUserId,
        Gs2EnchantAddRarityParameterStatusByUserId,
        Gs2EnchantReDrawBalanceParameterStatusByUserId,
        Gs2EnchantReDrawRarityParameterStatusByUserId,
        Gs2EnchantSetBalanceParameterStatusByUserId,
        Gs2EnchantSetRarityParameterStatusByUserId,
        Gs2EnhanceCreateProgressByUserId,
        Gs2EnhanceDirectEnhanceByUserId,
        Gs2EnhanceUnleashByUserId,
        Gs2ExchangeCreateAwaitByUserId,
        Gs2ExchangeExchangeByUserId,
        Gs2ExchangeIncrementalExchangeByUserId,
        Gs2ExchangeSkipByUserId,
        Gs2ExchangeUnlockIncrementalExchangeByUserId,
        Gs2ExperienceAddExperienceByUserId,
        Gs2ExperienceAddRankCapByUserId,
        Gs2ExperienceMultiplyAcquireActionsByUserId,
        Gs2ExperienceSetExperienceByUserId,
        Gs2ExperienceSetRankCapByUserId,
        Gs2FormationAcquireActionsToFormProperties,
        Gs2FormationAcquireActionsToPropertyFormProperties,
        Gs2FormationAddMoldCapacityByUserId,
        Gs2FormationSetFormByUserId,
        Gs2FormationSetMoldCapacityByUserId,
        Gs2GradeAddGradeByUserId,
        Gs2GradeApplyRankCapByUserId,
        Gs2GradeMultiplyAcquireActionsByUserId,
        Gs2IdleIncreaseMaximumIdleMinutesByUserId,
        Gs2IdleReceiveByUserId,
        Gs2IdleSetMaximumIdleMinutesByUserId,
        Gs2InboxSendMessageByUserId,
        Gs2InventoryAcquireBigItemByUserId,
        Gs2InventoryAcquireItemSetByUserId,
        Gs2InventoryAcquireItemSetWithGradeByUserId,
        Gs2InventoryAcquireSimpleItemsByUserId,
        Gs2InventoryAddCapacityByUserId,
        Gs2InventoryAddReferenceOfByUserId,
        Gs2InventoryDeleteReferenceOfByUserId,
        Gs2InventorySetBigItemByUserId,
        Gs2InventorySetCapacityByUserId,
        Gs2InventorySetSimpleItemsByUserId,
        Gs2JobQueuePushByUserId,
        Gs2LimitCountDownByUserId,
        Gs2LimitDeleteCounterByUserId,
        Gs2LoginRewardDeleteReceiveStatusByUserId,
        Gs2LoginRewardUnmarkReceivedByUserId,
        Gs2LotteryDrawByUserId,
        Gs2LotteryResetBoxByUserId,
        Gs2MissionIncreaseCounterByUserId,
        Gs2MissionRevertReceiveByUserId,
        Gs2MissionSetCounterByUserId,
        Gs2MoneyDepositByUserId,
        Gs2MoneyRevertRecordReceipt,
        Gs2QuestCreateProgressByUserId,
        Gs2ScheduleTriggerByUserId,
        Gs2SerialKeyRevertUseByUserId,
        Gs2ShowcaseDecrementPurchaseCountByUserId,
        Gs2ShowcaseForceReDrawByUserId,
        Gs2SkillTreeMarkReleaseByUserId,
        Gs2StaminaRaiseMaxValueByUserId,
        Gs2StaminaRecoverStaminaByUserId,
        Gs2StaminaSetMaxValueByUserId,
        Gs2StaminaSetRecoverIntervalByUserId,
        Gs2StaminaSetRecoverValueByUserId,
        Gs2StateMachineStartStateMachineByUserId,
        Gs2AdRewardConsumePointByUserId,
        Gs2DictionaryDeleteEntriesByUserId,
        Gs2DictionaryVerifyEntryByUserId,
        Gs2EnchantVerifyRarityParameterStatusByUserId,
        Gs2EnhanceDeleteProgressByUserId,
        Gs2ExchangeDeleteAwaitByUserId,
        Gs2ExperienceSubExperienceByUserId,
        Gs2ExperienceSubRankCapByUserId,
        Gs2ExperienceVerifyRankByUserId,
        Gs2ExperienceVerifyRankCapByUserId,
        Gs2FormationSubMoldCapacityByUserId,
        Gs2GradeSubGradeByUserId,
        Gs2GradeVerifyGradeByUserId,
        Gs2GradeVerifyGradeUpMaterialByUserId,
        Gs2IdleDecreaseMaximumIdleMinutesByUserId,
        Gs2InboxDeleteMessageByUserId,
        Gs2InboxOpenMessageByUserId,
        Gs2InventoryConsumeBigItemByUserId,
        Gs2InventoryConsumeItemSetByUserId,
        Gs2InventoryConsumeSimpleItemsByUserId,
        Gs2InventoryVerifyBigItemByUserId,
        Gs2InventoryVerifyInventoryCurrentMaxCapacityByUserId,
        Gs2InventoryVerifyItemSetByUserId,
        Gs2InventoryVerifyReferenceOfByUserId,
        Gs2InventoryVerifySimpleItemByUserId,
        Gs2JobQueueDeleteJobByUserId,
        Gs2LimitCountUpByUserId,
        Gs2LimitVerifyCounterByUserId,
        Gs2LoginRewardMarkReceivedByUserId,
        Gs2MatchmakingVerifyIncludeParticipantByUserId,
        Gs2MissionDecreaseCounterByUserId,
        Gs2MissionReceiveByUserId,
        Gs2MissionVerifyCompleteByUserId,
        Gs2MissionVerifyCounterValueByUserId,
        Gs2MoneyRecordReceipt,
        Gs2MoneyWithdrawByUserId,
        Gs2QuestDeleteProgressByUserId,
        Gs2ScheduleDeleteTriggerByUserId,
        Gs2ScheduleVerifyEventByUserId,
        Gs2SerialKeyUseByUserId,
        Gs2ShowcaseIncrementPurchaseCountByUserId,
        Gs2SkillTreeMarkRestrainByUserId,
        Gs2StaminaConsumeStaminaByUserId,
        Gs2StaminaDecreaseMaxValueByUserId
    }

    public static class BuffTargetActionTargetActionNameExt
    {
        public static string Str(this BuffTargetActionTargetActionName self) {
            switch (self) {
                case BuffTargetActionTargetActionName.Gs2AdRewardAcquirePointByUserId:
                    return "Gs2AdReward:AcquirePointByUserId";
                case BuffTargetActionTargetActionName.Gs2DictionaryAddEntriesByUserId:
                    return "Gs2Dictionary:AddEntriesByUserId";
                case BuffTargetActionTargetActionName.Gs2EnchantAddRarityParameterStatusByUserId:
                    return "Gs2Enchant:AddRarityParameterStatusByUserId";
                case BuffTargetActionTargetActionName.Gs2EnchantReDrawBalanceParameterStatusByUserId:
                    return "Gs2Enchant:ReDrawBalanceParameterStatusByUserId";
                case BuffTargetActionTargetActionName.Gs2EnchantReDrawRarityParameterStatusByUserId:
                    return "Gs2Enchant:ReDrawRarityParameterStatusByUserId";
                case BuffTargetActionTargetActionName.Gs2EnchantSetBalanceParameterStatusByUserId:
                    return "Gs2Enchant:SetBalanceParameterStatusByUserId";
                case BuffTargetActionTargetActionName.Gs2EnchantSetRarityParameterStatusByUserId:
                    return "Gs2Enchant:SetRarityParameterStatusByUserId";
                case BuffTargetActionTargetActionName.Gs2EnhanceCreateProgressByUserId:
                    return "Gs2Enhance:CreateProgressByUserId";
                case BuffTargetActionTargetActionName.Gs2EnhanceDirectEnhanceByUserId:
                    return "Gs2Enhance:DirectEnhanceByUserId";
                case BuffTargetActionTargetActionName.Gs2EnhanceUnleashByUserId:
                    return "Gs2Enhance:UnleashByUserId";
                case BuffTargetActionTargetActionName.Gs2ExchangeCreateAwaitByUserId:
                    return "Gs2Exchange:CreateAwaitByUserId";
                case BuffTargetActionTargetActionName.Gs2ExchangeExchangeByUserId:
                    return "Gs2Exchange:ExchangeByUserId";
                case BuffTargetActionTargetActionName.Gs2ExchangeIncrementalExchangeByUserId:
                    return "Gs2Exchange:IncrementalExchangeByUserId";
                case BuffTargetActionTargetActionName.Gs2ExchangeSkipByUserId:
                    return "Gs2Exchange:SkipByUserId";
                case BuffTargetActionTargetActionName.Gs2ExchangeUnlockIncrementalExchangeByUserId:
                    return "Gs2Exchange:UnlockIncrementalExchangeByUserId";
                case BuffTargetActionTargetActionName.Gs2ExperienceAddExperienceByUserId:
                    return "Gs2Experience:AddExperienceByUserId";
                case BuffTargetActionTargetActionName.Gs2ExperienceAddRankCapByUserId:
                    return "Gs2Experience:AddRankCapByUserId";
                case BuffTargetActionTargetActionName.Gs2ExperienceMultiplyAcquireActionsByUserId:
                    return "Gs2Experience:MultiplyAcquireActionsByUserId";
                case BuffTargetActionTargetActionName.Gs2ExperienceSetExperienceByUserId:
                    return "Gs2Experience:SetExperienceByUserId";
                case BuffTargetActionTargetActionName.Gs2ExperienceSetRankCapByUserId:
                    return "Gs2Experience:SetRankCapByUserId";
                case BuffTargetActionTargetActionName.Gs2FormationAcquireActionsToFormProperties:
                    return "Gs2Formation:AcquireActionsToFormProperties";
                case BuffTargetActionTargetActionName.Gs2FormationAcquireActionsToPropertyFormProperties:
                    return "Gs2Formation:AcquireActionsToPropertyFormProperties";
                case BuffTargetActionTargetActionName.Gs2FormationAddMoldCapacityByUserId:
                    return "Gs2Formation:AddMoldCapacityByUserId";
                case BuffTargetActionTargetActionName.Gs2FormationSetFormByUserId:
                    return "Gs2Formation:SetFormByUserId";
                case BuffTargetActionTargetActionName.Gs2FormationSetMoldCapacityByUserId:
                    return "Gs2Formation:SetMoldCapacityByUserId";
                case BuffTargetActionTargetActionName.Gs2GradeAddGradeByUserId:
                    return "Gs2Grade:AddGradeByUserId";
                case BuffTargetActionTargetActionName.Gs2GradeApplyRankCapByUserId:
                    return "Gs2Grade:ApplyRankCapByUserId";
                case BuffTargetActionTargetActionName.Gs2GradeMultiplyAcquireActionsByUserId:
                    return "Gs2Grade:MultiplyAcquireActionsByUserId";
                case BuffTargetActionTargetActionName.Gs2IdleIncreaseMaximumIdleMinutesByUserId:
                    return "Gs2Idle:IncreaseMaximumIdleMinutesByUserId";
                case BuffTargetActionTargetActionName.Gs2IdleReceiveByUserId:
                    return "Gs2Idle:ReceiveByUserId";
                case BuffTargetActionTargetActionName.Gs2IdleSetMaximumIdleMinutesByUserId:
                    return "Gs2Idle:SetMaximumIdleMinutesByUserId";
                case BuffTargetActionTargetActionName.Gs2InboxSendMessageByUserId:
                    return "Gs2Inbox:SendMessageByUserId";
                case BuffTargetActionTargetActionName.Gs2InventoryAcquireBigItemByUserId:
                    return "Gs2Inventory:AcquireBigItemByUserId";
                case BuffTargetActionTargetActionName.Gs2InventoryAcquireItemSetByUserId:
                    return "Gs2Inventory:AcquireItemSetByUserId";
                case BuffTargetActionTargetActionName.Gs2InventoryAcquireItemSetWithGradeByUserId:
                    return "Gs2Inventory:AcquireItemSetWithGradeByUserId";
                case BuffTargetActionTargetActionName.Gs2InventoryAcquireSimpleItemsByUserId:
                    return "Gs2Inventory:AcquireSimpleItemsByUserId";
                case BuffTargetActionTargetActionName.Gs2InventoryAddCapacityByUserId:
                    return "Gs2Inventory:AddCapacityByUserId";
                case BuffTargetActionTargetActionName.Gs2InventoryAddReferenceOfByUserId:
                    return "Gs2Inventory:AddReferenceOfByUserId";
                case BuffTargetActionTargetActionName.Gs2InventoryDeleteReferenceOfByUserId:
                    return "Gs2Inventory:DeleteReferenceOfByUserId";
                case BuffTargetActionTargetActionName.Gs2InventorySetBigItemByUserId:
                    return "Gs2Inventory:SetBigItemByUserId";
                case BuffTargetActionTargetActionName.Gs2InventorySetCapacityByUserId:
                    return "Gs2Inventory:SetCapacityByUserId";
                case BuffTargetActionTargetActionName.Gs2InventorySetSimpleItemsByUserId:
                    return "Gs2Inventory:SetSimpleItemsByUserId";
                case BuffTargetActionTargetActionName.Gs2JobQueuePushByUserId:
                    return "Gs2JobQueue:PushByUserId";
                case BuffTargetActionTargetActionName.Gs2LimitCountDownByUserId:
                    return "Gs2Limit:CountDownByUserId";
                case BuffTargetActionTargetActionName.Gs2LimitDeleteCounterByUserId:
                    return "Gs2Limit:DeleteCounterByUserId";
                case BuffTargetActionTargetActionName.Gs2LoginRewardDeleteReceiveStatusByUserId:
                    return "Gs2LoginReward:DeleteReceiveStatusByUserId";
                case BuffTargetActionTargetActionName.Gs2LoginRewardUnmarkReceivedByUserId:
                    return "Gs2LoginReward:UnmarkReceivedByUserId";
                case BuffTargetActionTargetActionName.Gs2LotteryDrawByUserId:
                    return "Gs2Lottery:DrawByUserId";
                case BuffTargetActionTargetActionName.Gs2LotteryResetBoxByUserId:
                    return "Gs2Lottery:ResetBoxByUserId";
                case BuffTargetActionTargetActionName.Gs2MissionIncreaseCounterByUserId:
                    return "Gs2Mission:IncreaseCounterByUserId";
                case BuffTargetActionTargetActionName.Gs2MissionRevertReceiveByUserId:
                    return "Gs2Mission:RevertReceiveByUserId";
                case BuffTargetActionTargetActionName.Gs2MissionSetCounterByUserId:
                    return "Gs2Mission:SetCounterByUserId";
                case BuffTargetActionTargetActionName.Gs2MoneyDepositByUserId:
                    return "Gs2Money:DepositByUserId";
                case BuffTargetActionTargetActionName.Gs2MoneyRevertRecordReceipt:
                    return "Gs2Money:RevertRecordReceipt";
                case BuffTargetActionTargetActionName.Gs2QuestCreateProgressByUserId:
                    return "Gs2Quest:CreateProgressByUserId";
                case BuffTargetActionTargetActionName.Gs2ScheduleTriggerByUserId:
                    return "Gs2Schedule:TriggerByUserId";
                case BuffTargetActionTargetActionName.Gs2SerialKeyRevertUseByUserId:
                    return "Gs2SerialKey:RevertUseByUserId";
                case BuffTargetActionTargetActionName.Gs2ShowcaseDecrementPurchaseCountByUserId:
                    return "Gs2Showcase:DecrementPurchaseCountByUserId";
                case BuffTargetActionTargetActionName.Gs2ShowcaseForceReDrawByUserId:
                    return "Gs2Showcase:ForceReDrawByUserId";
                case BuffTargetActionTargetActionName.Gs2SkillTreeMarkReleaseByUserId:
                    return "Gs2SkillTree:MarkReleaseByUserId";
                case BuffTargetActionTargetActionName.Gs2StaminaRaiseMaxValueByUserId:
                    return "Gs2Stamina:RaiseMaxValueByUserId";
                case BuffTargetActionTargetActionName.Gs2StaminaRecoverStaminaByUserId:
                    return "Gs2Stamina:RecoverStaminaByUserId";
                case BuffTargetActionTargetActionName.Gs2StaminaSetMaxValueByUserId:
                    return "Gs2Stamina:SetMaxValueByUserId";
                case BuffTargetActionTargetActionName.Gs2StaminaSetRecoverIntervalByUserId:
                    return "Gs2Stamina:SetRecoverIntervalByUserId";
                case BuffTargetActionTargetActionName.Gs2StaminaSetRecoverValueByUserId:
                    return "Gs2Stamina:SetRecoverValueByUserId";
                case BuffTargetActionTargetActionName.Gs2StateMachineStartStateMachineByUserId:
                    return "Gs2StateMachine:StartStateMachineByUserId";
                case BuffTargetActionTargetActionName.Gs2AdRewardConsumePointByUserId:
                    return "Gs2AdReward:ConsumePointByUserId";
                case BuffTargetActionTargetActionName.Gs2DictionaryDeleteEntriesByUserId:
                    return "Gs2Dictionary:DeleteEntriesByUserId";
                case BuffTargetActionTargetActionName.Gs2DictionaryVerifyEntryByUserId:
                    return "Gs2Dictionary:VerifyEntryByUserId";
                case BuffTargetActionTargetActionName.Gs2EnchantVerifyRarityParameterStatusByUserId:
                    return "Gs2Enchant:VerifyRarityParameterStatusByUserId";
                case BuffTargetActionTargetActionName.Gs2EnhanceDeleteProgressByUserId:
                    return "Gs2Enhance:DeleteProgressByUserId";
                case BuffTargetActionTargetActionName.Gs2ExchangeDeleteAwaitByUserId:
                    return "Gs2Exchange:DeleteAwaitByUserId";
                case BuffTargetActionTargetActionName.Gs2ExperienceSubExperienceByUserId:
                    return "Gs2Experience:SubExperienceByUserId";
                case BuffTargetActionTargetActionName.Gs2ExperienceSubRankCapByUserId:
                    return "Gs2Experience:SubRankCapByUserId";
                case BuffTargetActionTargetActionName.Gs2ExperienceVerifyRankByUserId:
                    return "Gs2Experience:VerifyRankByUserId";
                case BuffTargetActionTargetActionName.Gs2ExperienceVerifyRankCapByUserId:
                    return "Gs2Experience:VerifyRankCapByUserId";
                case BuffTargetActionTargetActionName.Gs2FormationSubMoldCapacityByUserId:
                    return "Gs2Formation:SubMoldCapacityByUserId";
                case BuffTargetActionTargetActionName.Gs2GradeSubGradeByUserId:
                    return "Gs2Grade:SubGradeByUserId";
                case BuffTargetActionTargetActionName.Gs2GradeVerifyGradeByUserId:
                    return "Gs2Grade:VerifyGradeByUserId";
                case BuffTargetActionTargetActionName.Gs2GradeVerifyGradeUpMaterialByUserId:
                    return "Gs2Grade:VerifyGradeUpMaterialByUserId";
                case BuffTargetActionTargetActionName.Gs2IdleDecreaseMaximumIdleMinutesByUserId:
                    return "Gs2Idle:DecreaseMaximumIdleMinutesByUserId";
                case BuffTargetActionTargetActionName.Gs2InboxDeleteMessageByUserId:
                    return "Gs2Inbox:DeleteMessageByUserId";
                case BuffTargetActionTargetActionName.Gs2InboxOpenMessageByUserId:
                    return "Gs2Inbox:OpenMessageByUserId";
                case BuffTargetActionTargetActionName.Gs2InventoryConsumeBigItemByUserId:
                    return "Gs2Inventory:ConsumeBigItemByUserId";
                case BuffTargetActionTargetActionName.Gs2InventoryConsumeItemSetByUserId:
                    return "Gs2Inventory:ConsumeItemSetByUserId";
                case BuffTargetActionTargetActionName.Gs2InventoryConsumeSimpleItemsByUserId:
                    return "Gs2Inventory:ConsumeSimpleItemsByUserId";
                case BuffTargetActionTargetActionName.Gs2InventoryVerifyBigItemByUserId:
                    return "Gs2Inventory:VerifyBigItemByUserId";
                case BuffTargetActionTargetActionName.Gs2InventoryVerifyInventoryCurrentMaxCapacityByUserId:
                    return "Gs2Inventory:VerifyInventoryCurrentMaxCapacityByUserId";
                case BuffTargetActionTargetActionName.Gs2InventoryVerifyItemSetByUserId:
                    return "Gs2Inventory:VerifyItemSetByUserId";
                case BuffTargetActionTargetActionName.Gs2InventoryVerifyReferenceOfByUserId:
                    return "Gs2Inventory:VerifyReferenceOfByUserId";
                case BuffTargetActionTargetActionName.Gs2InventoryVerifySimpleItemByUserId:
                    return "Gs2Inventory:VerifySimpleItemByUserId";
                case BuffTargetActionTargetActionName.Gs2JobQueueDeleteJobByUserId:
                    return "Gs2JobQueue:DeleteJobByUserId";
                case BuffTargetActionTargetActionName.Gs2LimitCountUpByUserId:
                    return "Gs2Limit:CountUpByUserId";
                case BuffTargetActionTargetActionName.Gs2LimitVerifyCounterByUserId:
                    return "Gs2Limit:VerifyCounterByUserId";
                case BuffTargetActionTargetActionName.Gs2LoginRewardMarkReceivedByUserId:
                    return "Gs2LoginReward:MarkReceivedByUserId";
                case BuffTargetActionTargetActionName.Gs2MatchmakingVerifyIncludeParticipantByUserId:
                    return "Gs2Matchmaking:VerifyIncludeParticipantByUserId";
                case BuffTargetActionTargetActionName.Gs2MissionDecreaseCounterByUserId:
                    return "Gs2Mission:DecreaseCounterByUserId";
                case BuffTargetActionTargetActionName.Gs2MissionReceiveByUserId:
                    return "Gs2Mission:ReceiveByUserId";
                case BuffTargetActionTargetActionName.Gs2MissionVerifyCompleteByUserId:
                    return "Gs2Mission:VerifyCompleteByUserId";
                case BuffTargetActionTargetActionName.Gs2MissionVerifyCounterValueByUserId:
                    return "Gs2Mission:VerifyCounterValueByUserId";
                case BuffTargetActionTargetActionName.Gs2MoneyRecordReceipt:
                    return "Gs2Money:RecordReceipt";
                case BuffTargetActionTargetActionName.Gs2MoneyWithdrawByUserId:
                    return "Gs2Money:WithdrawByUserId";
                case BuffTargetActionTargetActionName.Gs2QuestDeleteProgressByUserId:
                    return "Gs2Quest:DeleteProgressByUserId";
                case BuffTargetActionTargetActionName.Gs2ScheduleDeleteTriggerByUserId:
                    return "Gs2Schedule:DeleteTriggerByUserId";
                case BuffTargetActionTargetActionName.Gs2ScheduleVerifyEventByUserId:
                    return "Gs2Schedule:VerifyEventByUserId";
                case BuffTargetActionTargetActionName.Gs2SerialKeyUseByUserId:
                    return "Gs2SerialKey:UseByUserId";
                case BuffTargetActionTargetActionName.Gs2ShowcaseIncrementPurchaseCountByUserId:
                    return "Gs2Showcase:IncrementPurchaseCountByUserId";
                case BuffTargetActionTargetActionName.Gs2SkillTreeMarkRestrainByUserId:
                    return "Gs2SkillTree:MarkRestrainByUserId";
                case BuffTargetActionTargetActionName.Gs2StaminaConsumeStaminaByUserId:
                    return "Gs2Stamina:ConsumeStaminaByUserId";
                case BuffTargetActionTargetActionName.Gs2StaminaDecreaseMaxValueByUserId:
                    return "Gs2Stamina:DecreaseMaxValueByUserId";
            }
            return "unknown";
        }

        public static BuffTargetActionTargetActionName New(string value) {
            switch (value) {
                case "Gs2AdReward:AcquirePointByUserId":
                    return BuffTargetActionTargetActionName.Gs2AdRewardAcquirePointByUserId;
                case "Gs2Dictionary:AddEntriesByUserId":
                    return BuffTargetActionTargetActionName.Gs2DictionaryAddEntriesByUserId;
                case "Gs2Enchant:AddRarityParameterStatusByUserId":
                    return BuffTargetActionTargetActionName.Gs2EnchantAddRarityParameterStatusByUserId;
                case "Gs2Enchant:ReDrawBalanceParameterStatusByUserId":
                    return BuffTargetActionTargetActionName.Gs2EnchantReDrawBalanceParameterStatusByUserId;
                case "Gs2Enchant:ReDrawRarityParameterStatusByUserId":
                    return BuffTargetActionTargetActionName.Gs2EnchantReDrawRarityParameterStatusByUserId;
                case "Gs2Enchant:SetBalanceParameterStatusByUserId":
                    return BuffTargetActionTargetActionName.Gs2EnchantSetBalanceParameterStatusByUserId;
                case "Gs2Enchant:SetRarityParameterStatusByUserId":
                    return BuffTargetActionTargetActionName.Gs2EnchantSetRarityParameterStatusByUserId;
                case "Gs2Enhance:CreateProgressByUserId":
                    return BuffTargetActionTargetActionName.Gs2EnhanceCreateProgressByUserId;
                case "Gs2Enhance:DirectEnhanceByUserId":
                    return BuffTargetActionTargetActionName.Gs2EnhanceDirectEnhanceByUserId;
                case "Gs2Enhance:UnleashByUserId":
                    return BuffTargetActionTargetActionName.Gs2EnhanceUnleashByUserId;
                case "Gs2Exchange:CreateAwaitByUserId":
                    return BuffTargetActionTargetActionName.Gs2ExchangeCreateAwaitByUserId;
                case "Gs2Exchange:ExchangeByUserId":
                    return BuffTargetActionTargetActionName.Gs2ExchangeExchangeByUserId;
                case "Gs2Exchange:IncrementalExchangeByUserId":
                    return BuffTargetActionTargetActionName.Gs2ExchangeIncrementalExchangeByUserId;
                case "Gs2Exchange:SkipByUserId":
                    return BuffTargetActionTargetActionName.Gs2ExchangeSkipByUserId;
                case "Gs2Exchange:UnlockIncrementalExchangeByUserId":
                    return BuffTargetActionTargetActionName.Gs2ExchangeUnlockIncrementalExchangeByUserId;
                case "Gs2Experience:AddExperienceByUserId":
                    return BuffTargetActionTargetActionName.Gs2ExperienceAddExperienceByUserId;
                case "Gs2Experience:AddRankCapByUserId":
                    return BuffTargetActionTargetActionName.Gs2ExperienceAddRankCapByUserId;
                case "Gs2Experience:MultiplyAcquireActionsByUserId":
                    return BuffTargetActionTargetActionName.Gs2ExperienceMultiplyAcquireActionsByUserId;
                case "Gs2Experience:SetExperienceByUserId":
                    return BuffTargetActionTargetActionName.Gs2ExperienceSetExperienceByUserId;
                case "Gs2Experience:SetRankCapByUserId":
                    return BuffTargetActionTargetActionName.Gs2ExperienceSetRankCapByUserId;
                case "Gs2Formation:AcquireActionsToFormProperties":
                    return BuffTargetActionTargetActionName.Gs2FormationAcquireActionsToFormProperties;
                case "Gs2Formation:AcquireActionsToPropertyFormProperties":
                    return BuffTargetActionTargetActionName.Gs2FormationAcquireActionsToPropertyFormProperties;
                case "Gs2Formation:AddMoldCapacityByUserId":
                    return BuffTargetActionTargetActionName.Gs2FormationAddMoldCapacityByUserId;
                case "Gs2Formation:SetFormByUserId":
                    return BuffTargetActionTargetActionName.Gs2FormationSetFormByUserId;
                case "Gs2Formation:SetMoldCapacityByUserId":
                    return BuffTargetActionTargetActionName.Gs2FormationSetMoldCapacityByUserId;
                case "Gs2Grade:AddGradeByUserId":
                    return BuffTargetActionTargetActionName.Gs2GradeAddGradeByUserId;
                case "Gs2Grade:ApplyRankCapByUserId":
                    return BuffTargetActionTargetActionName.Gs2GradeApplyRankCapByUserId;
                case "Gs2Grade:MultiplyAcquireActionsByUserId":
                    return BuffTargetActionTargetActionName.Gs2GradeMultiplyAcquireActionsByUserId;
                case "Gs2Idle:IncreaseMaximumIdleMinutesByUserId":
                    return BuffTargetActionTargetActionName.Gs2IdleIncreaseMaximumIdleMinutesByUserId;
                case "Gs2Idle:ReceiveByUserId":
                    return BuffTargetActionTargetActionName.Gs2IdleReceiveByUserId;
                case "Gs2Idle:SetMaximumIdleMinutesByUserId":
                    return BuffTargetActionTargetActionName.Gs2IdleSetMaximumIdleMinutesByUserId;
                case "Gs2Inbox:SendMessageByUserId":
                    return BuffTargetActionTargetActionName.Gs2InboxSendMessageByUserId;
                case "Gs2Inventory:AcquireBigItemByUserId":
                    return BuffTargetActionTargetActionName.Gs2InventoryAcquireBigItemByUserId;
                case "Gs2Inventory:AcquireItemSetByUserId":
                    return BuffTargetActionTargetActionName.Gs2InventoryAcquireItemSetByUserId;
                case "Gs2Inventory:AcquireItemSetWithGradeByUserId":
                    return BuffTargetActionTargetActionName.Gs2InventoryAcquireItemSetWithGradeByUserId;
                case "Gs2Inventory:AcquireSimpleItemsByUserId":
                    return BuffTargetActionTargetActionName.Gs2InventoryAcquireSimpleItemsByUserId;
                case "Gs2Inventory:AddCapacityByUserId":
                    return BuffTargetActionTargetActionName.Gs2InventoryAddCapacityByUserId;
                case "Gs2Inventory:AddReferenceOfByUserId":
                    return BuffTargetActionTargetActionName.Gs2InventoryAddReferenceOfByUserId;
                case "Gs2Inventory:DeleteReferenceOfByUserId":
                    return BuffTargetActionTargetActionName.Gs2InventoryDeleteReferenceOfByUserId;
                case "Gs2Inventory:SetBigItemByUserId":
                    return BuffTargetActionTargetActionName.Gs2InventorySetBigItemByUserId;
                case "Gs2Inventory:SetCapacityByUserId":
                    return BuffTargetActionTargetActionName.Gs2InventorySetCapacityByUserId;
                case "Gs2Inventory:SetSimpleItemsByUserId":
                    return BuffTargetActionTargetActionName.Gs2InventorySetSimpleItemsByUserId;
                case "Gs2JobQueue:PushByUserId":
                    return BuffTargetActionTargetActionName.Gs2JobQueuePushByUserId;
                case "Gs2Limit:CountDownByUserId":
                    return BuffTargetActionTargetActionName.Gs2LimitCountDownByUserId;
                case "Gs2Limit:DeleteCounterByUserId":
                    return BuffTargetActionTargetActionName.Gs2LimitDeleteCounterByUserId;
                case "Gs2LoginReward:DeleteReceiveStatusByUserId":
                    return BuffTargetActionTargetActionName.Gs2LoginRewardDeleteReceiveStatusByUserId;
                case "Gs2LoginReward:UnmarkReceivedByUserId":
                    return BuffTargetActionTargetActionName.Gs2LoginRewardUnmarkReceivedByUserId;
                case "Gs2Lottery:DrawByUserId":
                    return BuffTargetActionTargetActionName.Gs2LotteryDrawByUserId;
                case "Gs2Lottery:ResetBoxByUserId":
                    return BuffTargetActionTargetActionName.Gs2LotteryResetBoxByUserId;
                case "Gs2Mission:IncreaseCounterByUserId":
                    return BuffTargetActionTargetActionName.Gs2MissionIncreaseCounterByUserId;
                case "Gs2Mission:RevertReceiveByUserId":
                    return BuffTargetActionTargetActionName.Gs2MissionRevertReceiveByUserId;
                case "Gs2Mission:SetCounterByUserId":
                    return BuffTargetActionTargetActionName.Gs2MissionSetCounterByUserId;
                case "Gs2Money:DepositByUserId":
                    return BuffTargetActionTargetActionName.Gs2MoneyDepositByUserId;
                case "Gs2Money:RevertRecordReceipt":
                    return BuffTargetActionTargetActionName.Gs2MoneyRevertRecordReceipt;
                case "Gs2Quest:CreateProgressByUserId":
                    return BuffTargetActionTargetActionName.Gs2QuestCreateProgressByUserId;
                case "Gs2Schedule:TriggerByUserId":
                    return BuffTargetActionTargetActionName.Gs2ScheduleTriggerByUserId;
                case "Gs2SerialKey:RevertUseByUserId":
                    return BuffTargetActionTargetActionName.Gs2SerialKeyRevertUseByUserId;
                case "Gs2Showcase:DecrementPurchaseCountByUserId":
                    return BuffTargetActionTargetActionName.Gs2ShowcaseDecrementPurchaseCountByUserId;
                case "Gs2Showcase:ForceReDrawByUserId":
                    return BuffTargetActionTargetActionName.Gs2ShowcaseForceReDrawByUserId;
                case "Gs2SkillTree:MarkReleaseByUserId":
                    return BuffTargetActionTargetActionName.Gs2SkillTreeMarkReleaseByUserId;
                case "Gs2Stamina:RaiseMaxValueByUserId":
                    return BuffTargetActionTargetActionName.Gs2StaminaRaiseMaxValueByUserId;
                case "Gs2Stamina:RecoverStaminaByUserId":
                    return BuffTargetActionTargetActionName.Gs2StaminaRecoverStaminaByUserId;
                case "Gs2Stamina:SetMaxValueByUserId":
                    return BuffTargetActionTargetActionName.Gs2StaminaSetMaxValueByUserId;
                case "Gs2Stamina:SetRecoverIntervalByUserId":
                    return BuffTargetActionTargetActionName.Gs2StaminaSetRecoverIntervalByUserId;
                case "Gs2Stamina:SetRecoverValueByUserId":
                    return BuffTargetActionTargetActionName.Gs2StaminaSetRecoverValueByUserId;
                case "Gs2StateMachine:StartStateMachineByUserId":
                    return BuffTargetActionTargetActionName.Gs2StateMachineStartStateMachineByUserId;
                case "Gs2AdReward:ConsumePointByUserId":
                    return BuffTargetActionTargetActionName.Gs2AdRewardConsumePointByUserId;
                case "Gs2Dictionary:DeleteEntriesByUserId":
                    return BuffTargetActionTargetActionName.Gs2DictionaryDeleteEntriesByUserId;
                case "Gs2Dictionary:VerifyEntryByUserId":
                    return BuffTargetActionTargetActionName.Gs2DictionaryVerifyEntryByUserId;
                case "Gs2Enchant:VerifyRarityParameterStatusByUserId":
                    return BuffTargetActionTargetActionName.Gs2EnchantVerifyRarityParameterStatusByUserId;
                case "Gs2Enhance:DeleteProgressByUserId":
                    return BuffTargetActionTargetActionName.Gs2EnhanceDeleteProgressByUserId;
                case "Gs2Exchange:DeleteAwaitByUserId":
                    return BuffTargetActionTargetActionName.Gs2ExchangeDeleteAwaitByUserId;
                case "Gs2Experience:SubExperienceByUserId":
                    return BuffTargetActionTargetActionName.Gs2ExperienceSubExperienceByUserId;
                case "Gs2Experience:SubRankCapByUserId":
                    return BuffTargetActionTargetActionName.Gs2ExperienceSubRankCapByUserId;
                case "Gs2Experience:VerifyRankByUserId":
                    return BuffTargetActionTargetActionName.Gs2ExperienceVerifyRankByUserId;
                case "Gs2Experience:VerifyRankCapByUserId":
                    return BuffTargetActionTargetActionName.Gs2ExperienceVerifyRankCapByUserId;
                case "Gs2Formation:SubMoldCapacityByUserId":
                    return BuffTargetActionTargetActionName.Gs2FormationSubMoldCapacityByUserId;
                case "Gs2Grade:SubGradeByUserId":
                    return BuffTargetActionTargetActionName.Gs2GradeSubGradeByUserId;
                case "Gs2Grade:VerifyGradeByUserId":
                    return BuffTargetActionTargetActionName.Gs2GradeVerifyGradeByUserId;
                case "Gs2Grade:VerifyGradeUpMaterialByUserId":
                    return BuffTargetActionTargetActionName.Gs2GradeVerifyGradeUpMaterialByUserId;
                case "Gs2Idle:DecreaseMaximumIdleMinutesByUserId":
                    return BuffTargetActionTargetActionName.Gs2IdleDecreaseMaximumIdleMinutesByUserId;
                case "Gs2Inbox:DeleteMessageByUserId":
                    return BuffTargetActionTargetActionName.Gs2InboxDeleteMessageByUserId;
                case "Gs2Inbox:OpenMessageByUserId":
                    return BuffTargetActionTargetActionName.Gs2InboxOpenMessageByUserId;
                case "Gs2Inventory:ConsumeBigItemByUserId":
                    return BuffTargetActionTargetActionName.Gs2InventoryConsumeBigItemByUserId;
                case "Gs2Inventory:ConsumeItemSetByUserId":
                    return BuffTargetActionTargetActionName.Gs2InventoryConsumeItemSetByUserId;
                case "Gs2Inventory:ConsumeSimpleItemsByUserId":
                    return BuffTargetActionTargetActionName.Gs2InventoryConsumeSimpleItemsByUserId;
                case "Gs2Inventory:VerifyBigItemByUserId":
                    return BuffTargetActionTargetActionName.Gs2InventoryVerifyBigItemByUserId;
                case "Gs2Inventory:VerifyInventoryCurrentMaxCapacityByUserId":
                    return BuffTargetActionTargetActionName.Gs2InventoryVerifyInventoryCurrentMaxCapacityByUserId;
                case "Gs2Inventory:VerifyItemSetByUserId":
                    return BuffTargetActionTargetActionName.Gs2InventoryVerifyItemSetByUserId;
                case "Gs2Inventory:VerifyReferenceOfByUserId":
                    return BuffTargetActionTargetActionName.Gs2InventoryVerifyReferenceOfByUserId;
                case "Gs2Inventory:VerifySimpleItemByUserId":
                    return BuffTargetActionTargetActionName.Gs2InventoryVerifySimpleItemByUserId;
                case "Gs2JobQueue:DeleteJobByUserId":
                    return BuffTargetActionTargetActionName.Gs2JobQueueDeleteJobByUserId;
                case "Gs2Limit:CountUpByUserId":
                    return BuffTargetActionTargetActionName.Gs2LimitCountUpByUserId;
                case "Gs2Limit:VerifyCounterByUserId":
                    return BuffTargetActionTargetActionName.Gs2LimitVerifyCounterByUserId;
                case "Gs2LoginReward:MarkReceivedByUserId":
                    return BuffTargetActionTargetActionName.Gs2LoginRewardMarkReceivedByUserId;
                case "Gs2Matchmaking:VerifyIncludeParticipantByUserId":
                    return BuffTargetActionTargetActionName.Gs2MatchmakingVerifyIncludeParticipantByUserId;
                case "Gs2Mission:DecreaseCounterByUserId":
                    return BuffTargetActionTargetActionName.Gs2MissionDecreaseCounterByUserId;
                case "Gs2Mission:ReceiveByUserId":
                    return BuffTargetActionTargetActionName.Gs2MissionReceiveByUserId;
                case "Gs2Mission:VerifyCompleteByUserId":
                    return BuffTargetActionTargetActionName.Gs2MissionVerifyCompleteByUserId;
                case "Gs2Mission:VerifyCounterValueByUserId":
                    return BuffTargetActionTargetActionName.Gs2MissionVerifyCounterValueByUserId;
                case "Gs2Money:RecordReceipt":
                    return BuffTargetActionTargetActionName.Gs2MoneyRecordReceipt;
                case "Gs2Money:WithdrawByUserId":
                    return BuffTargetActionTargetActionName.Gs2MoneyWithdrawByUserId;
                case "Gs2Quest:DeleteProgressByUserId":
                    return BuffTargetActionTargetActionName.Gs2QuestDeleteProgressByUserId;
                case "Gs2Schedule:DeleteTriggerByUserId":
                    return BuffTargetActionTargetActionName.Gs2ScheduleDeleteTriggerByUserId;
                case "Gs2Schedule:VerifyEventByUserId":
                    return BuffTargetActionTargetActionName.Gs2ScheduleVerifyEventByUserId;
                case "Gs2SerialKey:UseByUserId":
                    return BuffTargetActionTargetActionName.Gs2SerialKeyUseByUserId;
                case "Gs2Showcase:IncrementPurchaseCountByUserId":
                    return BuffTargetActionTargetActionName.Gs2ShowcaseIncrementPurchaseCountByUserId;
                case "Gs2SkillTree:MarkRestrainByUserId":
                    return BuffTargetActionTargetActionName.Gs2SkillTreeMarkRestrainByUserId;
                case "Gs2Stamina:ConsumeStaminaByUserId":
                    return BuffTargetActionTargetActionName.Gs2StaminaConsumeStaminaByUserId;
                case "Gs2Stamina:DecreaseMaxValueByUserId":
                    return BuffTargetActionTargetActionName.Gs2StaminaDecreaseMaxValueByUserId;
            }
            return BuffTargetActionTargetActionName.Gs2AdRewardAcquirePointByUserId;
        }
    }
}
