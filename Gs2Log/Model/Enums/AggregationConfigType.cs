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


namespace Gs2Cdk.Gs2Log.Model.Enums
{
    
    public enum AggregationConfigType {
        Count,
        Unique,
        Sum,
        Avg,
        Max,
        Min,
        P90,
        P95,
        P99
    }

    public static class AggregationConfigTypeExt
    {
        public static string Str(this AggregationConfigType self) {
            switch (self) {
                case AggregationConfigType.Count:
                    return "count";
                case AggregationConfigType.Unique:
                    return "unique";
                case AggregationConfigType.Sum:
                    return "sum";
                case AggregationConfigType.Avg:
                    return "avg";
                case AggregationConfigType.Max:
                    return "max";
                case AggregationConfigType.Min:
                    return "min";
                case AggregationConfigType.P90:
                    return "p90";
                case AggregationConfigType.P95:
                    return "p95";
                case AggregationConfigType.P99:
                    return "p99";
            }
            return "unknown";
        }

        public static AggregationConfigType? New(string value) {
            switch (value) {
                case "count":
                    return AggregationConfigType.Count;
                case "unique":
                    return AggregationConfigType.Unique;
                case "sum":
                    return AggregationConfigType.Sum;
                case "avg":
                    return AggregationConfigType.Avg;
                case "max":
                    return AggregationConfigType.Max;
                case "min":
                    return AggregationConfigType.Min;
                case "p90":
                    return AggregationConfigType.P90;
                case "p95":
                    return AggregationConfigType.P95;
                case "p99":
                    return AggregationConfigType.P99;
            }
            return null;
        }
    }
}
