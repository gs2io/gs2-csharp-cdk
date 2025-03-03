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


namespace Gs2Cdk.Gs2Money2.Model.Enums
{
    
    public enum SubscribeTransactionStatusDetail {
        ActiveActive,
        ActiveConvertedFromTrial,
        ActiveInTrial,
        ActiveInIntroOffer,
        GraceCanceled,
        GraceGracePeriod,
        GraceOnHold,
        InactiveExpired,
        InactiveRevoked
    }

    public static class SubscribeTransactionStatusDetailExt
    {
        public static string Str(this SubscribeTransactionStatusDetail self) {
            switch (self) {
                case SubscribeTransactionStatusDetail.ActiveActive:
                    return "active@active";
                case SubscribeTransactionStatusDetail.ActiveConvertedFromTrial:
                    return "active@converted_from_trial";
                case SubscribeTransactionStatusDetail.ActiveInTrial:
                    return "active@in_trial";
                case SubscribeTransactionStatusDetail.ActiveInIntroOffer:
                    return "active@in_intro_offer";
                case SubscribeTransactionStatusDetail.GraceCanceled:
                    return "grace@canceled";
                case SubscribeTransactionStatusDetail.GraceGracePeriod:
                    return "grace@grace_period";
                case SubscribeTransactionStatusDetail.GraceOnHold:
                    return "grace@on_hold";
                case SubscribeTransactionStatusDetail.InactiveExpired:
                    return "inactive@expired";
                case SubscribeTransactionStatusDetail.InactiveRevoked:
                    return "inactive@revoked";
            }
            return "unknown";
        }

        public static SubscribeTransactionStatusDetail New(string value) {
            switch (value) {
                case "active@active":
                    return SubscribeTransactionStatusDetail.ActiveActive;
                case "active@converted_from_trial":
                    return SubscribeTransactionStatusDetail.ActiveConvertedFromTrial;
                case "active@in_trial":
                    return SubscribeTransactionStatusDetail.ActiveInTrial;
                case "active@in_intro_offer":
                    return SubscribeTransactionStatusDetail.ActiveInIntroOffer;
                case "grace@canceled":
                    return SubscribeTransactionStatusDetail.GraceCanceled;
                case "grace@grace_period":
                    return SubscribeTransactionStatusDetail.GraceGracePeriod;
                case "grace@on_hold":
                    return SubscribeTransactionStatusDetail.GraceOnHold;
                case "inactive@expired":
                    return SubscribeTransactionStatusDetail.InactiveExpired;
                case "inactive@revoked":
                    return SubscribeTransactionStatusDetail.InactiveRevoked;
            }
            return SubscribeTransactionStatusDetail.ActiveActive;
        }
    }
}
