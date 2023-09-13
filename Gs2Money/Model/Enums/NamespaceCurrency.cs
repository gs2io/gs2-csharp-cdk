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


namespace Gs2Cdk.Gs2Money.Model.Enums
{
    
    public enum NamespaceCurrency {
        Jpy,
        Usd,
        Twd
    }

    public static class NamespaceCurrencyExt
    {
        public static string Str(this NamespaceCurrency self) {
            switch (self) {
                case NamespaceCurrency.Jpy:
                    return "JPY";
                case NamespaceCurrency.Usd:
                    return "USD";
                case NamespaceCurrency.Twd:
                    return "TWD";
            }
            return "unknown";
        }

        public static NamespaceCurrency New(string value) {
            switch (value) {
                case "JPY":
                    return NamespaceCurrency.Jpy;
                case "USD":
                    return NamespaceCurrency.Usd;
                case "TWD":
                    return NamespaceCurrency.Twd;
            }
            return NamespaceCurrency.Jpy;
        }
    }
}
