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
 *
 * deny overwrite
 */
using System.Collections.Generic;
using System.Linq;

using Gs2Cdk.Core.Model;
using Gs2Cdk.Gs2Schedule.Model;
using Gs2Cdk.Gs2Schedule.Model.Enums;

namespace Gs2Cdk.Gs2Schedule.Model.Options
{
    public class EventOptions {
        public EventRepeatType? repeatType;
        public string metadata;
        public long? absoluteBegin;
        public string absoluteBeginString;
        public long? absoluteEnd;
        public string absoluteEndString;
        public string relativeTriggerName;
        public int? repeatBeginDayOfMonth;
        public string repeatBeginDayOfMonthString;
        public int? repeatEndDayOfMonth;
        public string repeatEndDayOfMonthString;
        public EventRepeatBeginDayOfWeek? repeatBeginDayOfWeek;
        public EventRepeatEndDayOfWeek? repeatEndDayOfWeek;
        public int? repeatBeginHour;
        public string repeatBeginHourString;
        public int? repeatEndHour;
        public string repeatEndHourString;
    }
}
