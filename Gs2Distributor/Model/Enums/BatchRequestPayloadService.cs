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


namespace Gs2Cdk.Gs2Distributor.Model.Enums
{
    
    public enum BatchRequestPayloadService {
        Account,
        AdReward,
        Auth,
        Buff,
        Chat,
        Datastore,
        Deploy,
        Dictionary,
        Distributor,
        Enchant,
        Enhance,
        Exchange,
        Experience,
        Formation,
        Friend,
        Gateway,
        Grade,
        Guard,
        Guild,
        Identifier,
        Idle,
        Inbox,
        Inventory,
        JobQueue,
        Key,
        Limit,
        Lock,
        Log,
        LoginReward,
        Lottery,
        Matchmaking,
        MegaField,
        Mission,
        Money,
        Money2,
        News,
        Quest,
        Ranking,
        Ranking2,
        Realtime,
        Schedule,
        Script,
        SeasonRating,
        SerialKey,
        Showcase,
        SkillTree,
        Stamina,
        StateMachine,
        Version
    }

    public static class BatchRequestPayloadServiceExt
    {
        public static string Str(this BatchRequestPayloadService self) {
            switch (self) {
                case BatchRequestPayloadService.Account:
                    return "account";
                case BatchRequestPayloadService.AdReward:
                    return "adReward";
                case BatchRequestPayloadService.Auth:
                    return "auth";
                case BatchRequestPayloadService.Buff:
                    return "buff";
                case BatchRequestPayloadService.Chat:
                    return "chat";
                case BatchRequestPayloadService.Datastore:
                    return "datastore";
                case BatchRequestPayloadService.Deploy:
                    return "deploy";
                case BatchRequestPayloadService.Dictionary:
                    return "dictionary";
                case BatchRequestPayloadService.Distributor:
                    return "distributor";
                case BatchRequestPayloadService.Enchant:
                    return "enchant";
                case BatchRequestPayloadService.Enhance:
                    return "enhance";
                case BatchRequestPayloadService.Exchange:
                    return "exchange";
                case BatchRequestPayloadService.Experience:
                    return "experience";
                case BatchRequestPayloadService.Formation:
                    return "formation";
                case BatchRequestPayloadService.Friend:
                    return "friend";
                case BatchRequestPayloadService.Gateway:
                    return "gateway";
                case BatchRequestPayloadService.Grade:
                    return "grade";
                case BatchRequestPayloadService.Guard:
                    return "guard";
                case BatchRequestPayloadService.Guild:
                    return "guild";
                case BatchRequestPayloadService.Identifier:
                    return "identifier";
                case BatchRequestPayloadService.Idle:
                    return "idle";
                case BatchRequestPayloadService.Inbox:
                    return "inbox";
                case BatchRequestPayloadService.Inventory:
                    return "inventory";
                case BatchRequestPayloadService.JobQueue:
                    return "jobQueue";
                case BatchRequestPayloadService.Key:
                    return "key";
                case BatchRequestPayloadService.Limit:
                    return "limit";
                case BatchRequestPayloadService.Lock:
                    return "lock";
                case BatchRequestPayloadService.Log:
                    return "log";
                case BatchRequestPayloadService.LoginReward:
                    return "loginReward";
                case BatchRequestPayloadService.Lottery:
                    return "lottery";
                case BatchRequestPayloadService.Matchmaking:
                    return "matchmaking";
                case BatchRequestPayloadService.MegaField:
                    return "megaField";
                case BatchRequestPayloadService.Mission:
                    return "mission";
                case BatchRequestPayloadService.Money:
                    return "money";
                case BatchRequestPayloadService.Money2:
                    return "money2";
                case BatchRequestPayloadService.News:
                    return "news";
                case BatchRequestPayloadService.Quest:
                    return "quest";
                case BatchRequestPayloadService.Ranking:
                    return "ranking";
                case BatchRequestPayloadService.Ranking2:
                    return "ranking2";
                case BatchRequestPayloadService.Realtime:
                    return "realtime";
                case BatchRequestPayloadService.Schedule:
                    return "schedule";
                case BatchRequestPayloadService.Script:
                    return "script";
                case BatchRequestPayloadService.SeasonRating:
                    return "seasonRating";
                case BatchRequestPayloadService.SerialKey:
                    return "serialKey";
                case BatchRequestPayloadService.Showcase:
                    return "showcase";
                case BatchRequestPayloadService.SkillTree:
                    return "skillTree";
                case BatchRequestPayloadService.Stamina:
                    return "stamina";
                case BatchRequestPayloadService.StateMachine:
                    return "stateMachine";
                case BatchRequestPayloadService.Version:
                    return "version";
            }
            return "unknown";
        }

        public static BatchRequestPayloadService New(string value) {
            switch (value) {
                case "account":
                    return BatchRequestPayloadService.Account;
                case "adReward":
                    return BatchRequestPayloadService.AdReward;
                case "auth":
                    return BatchRequestPayloadService.Auth;
                case "buff":
                    return BatchRequestPayloadService.Buff;
                case "chat":
                    return BatchRequestPayloadService.Chat;
                case "datastore":
                    return BatchRequestPayloadService.Datastore;
                case "deploy":
                    return BatchRequestPayloadService.Deploy;
                case "dictionary":
                    return BatchRequestPayloadService.Dictionary;
                case "distributor":
                    return BatchRequestPayloadService.Distributor;
                case "enchant":
                    return BatchRequestPayloadService.Enchant;
                case "enhance":
                    return BatchRequestPayloadService.Enhance;
                case "exchange":
                    return BatchRequestPayloadService.Exchange;
                case "experience":
                    return BatchRequestPayloadService.Experience;
                case "formation":
                    return BatchRequestPayloadService.Formation;
                case "friend":
                    return BatchRequestPayloadService.Friend;
                case "gateway":
                    return BatchRequestPayloadService.Gateway;
                case "grade":
                    return BatchRequestPayloadService.Grade;
                case "guard":
                    return BatchRequestPayloadService.Guard;
                case "guild":
                    return BatchRequestPayloadService.Guild;
                case "identifier":
                    return BatchRequestPayloadService.Identifier;
                case "idle":
                    return BatchRequestPayloadService.Idle;
                case "inbox":
                    return BatchRequestPayloadService.Inbox;
                case "inventory":
                    return BatchRequestPayloadService.Inventory;
                case "jobQueue":
                    return BatchRequestPayloadService.JobQueue;
                case "key":
                    return BatchRequestPayloadService.Key;
                case "limit":
                    return BatchRequestPayloadService.Limit;
                case "lock":
                    return BatchRequestPayloadService.Lock;
                case "log":
                    return BatchRequestPayloadService.Log;
                case "loginReward":
                    return BatchRequestPayloadService.LoginReward;
                case "lottery":
                    return BatchRequestPayloadService.Lottery;
                case "matchmaking":
                    return BatchRequestPayloadService.Matchmaking;
                case "megaField":
                    return BatchRequestPayloadService.MegaField;
                case "mission":
                    return BatchRequestPayloadService.Mission;
                case "money":
                    return BatchRequestPayloadService.Money;
                case "money2":
                    return BatchRequestPayloadService.Money2;
                case "news":
                    return BatchRequestPayloadService.News;
                case "quest":
                    return BatchRequestPayloadService.Quest;
                case "ranking":
                    return BatchRequestPayloadService.Ranking;
                case "ranking2":
                    return BatchRequestPayloadService.Ranking2;
                case "realtime":
                    return BatchRequestPayloadService.Realtime;
                case "schedule":
                    return BatchRequestPayloadService.Schedule;
                case "script":
                    return BatchRequestPayloadService.Script;
                case "seasonRating":
                    return BatchRequestPayloadService.SeasonRating;
                case "serialKey":
                    return BatchRequestPayloadService.SerialKey;
                case "showcase":
                    return BatchRequestPayloadService.Showcase;
                case "skillTree":
                    return BatchRequestPayloadService.SkillTree;
                case "stamina":
                    return BatchRequestPayloadService.Stamina;
                case "stateMachine":
                    return BatchRequestPayloadService.StateMachine;
                case "version":
                    return BatchRequestPayloadService.Version;
            }
            return BatchRequestPayloadService.Account;
        }
    }
}
