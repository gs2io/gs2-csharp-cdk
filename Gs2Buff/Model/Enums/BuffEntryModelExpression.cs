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
    
    public enum BuffEntryModelExpression {
        RateAdd,
        Mul,
        ValueAdd
    }

    public static class BuffEntryModelExpressionExt
    {
        public static string Str(this BuffEntryModelExpression self) {
            switch (self) {
                case BuffEntryModelExpression.RateAdd:
                    return "rate_add";
                case BuffEntryModelExpression.Mul:
                    return "mul";
                case BuffEntryModelExpression.ValueAdd:
                    return "value_add";
            }
            return "unknown";
        }

        public static BuffEntryModelExpression New(string value) {
            switch (value) {
                case "rate_add":
                    return BuffEntryModelExpression.RateAdd;
                case "mul":
                    return BuffEntryModelExpression.Mul;
                case "value_add":
                    return BuffEntryModelExpression.ValueAdd;
            }
            return BuffEntryModelExpression.RateAdd;
        }
    }
}
