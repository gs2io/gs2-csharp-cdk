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
    
    public enum SubscribeTransactionStore {
        AppleAppStore,
        GooglePlay,
        Fake
    }

    public static class SubscribeTransactionStoreExt
    {
        public static string Str(this SubscribeTransactionStore self) {
            switch (self) {
                case SubscribeTransactionStore.AppleAppStore:
                    return "AppleAppStore";
                case SubscribeTransactionStore.GooglePlay:
                    return "GooglePlay";
                case SubscribeTransactionStore.Fake:
                    return "fake";
            }
            return "unknown";
        }

        public static SubscribeTransactionStore New(string value) {
            switch (value) {
                case "AppleAppStore":
                    return SubscribeTransactionStore.AppleAppStore;
                case "GooglePlay":
                    return SubscribeTransactionStore.GooglePlay;
                case "fake":
                    return SubscribeTransactionStore.Fake;
            }
            return SubscribeTransactionStore.AppleAppStore;
        }
    }
}
