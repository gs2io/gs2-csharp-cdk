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
    
    public enum ReceiptStore {
        AppleAppStore,
        GooglePlay,
        Fake
    }

    public static class ReceiptStoreExt
    {
        public static string Str(this ReceiptStore self) {
            switch (self) {
                case ReceiptStore.AppleAppStore:
                    return "AppleAppStore";
                case ReceiptStore.GooglePlay:
                    return "GooglePlay";
                case ReceiptStore.Fake:
                    return "fake";
            }
            return "unknown";
        }

        public static ReceiptStore New(string value) {
            switch (value) {
                case "AppleAppStore":
                    return ReceiptStore.AppleAppStore;
                case "GooglePlay":
                    return ReceiptStore.GooglePlay;
                case "fake":
                    return ReceiptStore.Fake;
            }
            return ReceiptStore.AppleAppStore;
        }
    }
}
