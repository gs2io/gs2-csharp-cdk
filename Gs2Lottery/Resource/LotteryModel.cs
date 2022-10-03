/*
 * Copyright 2016 Game Server Services, Inc. or its affiliates. All Rights
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
using System;
using System.Collections.Generic;
using System.Linq;
using Gs2Cdk.Core.Func;
using Gs2Cdk.Core.Model;
using Gs2Cdk.Gs2Lottery.Model;
using Gs2Cdk.Gs2Lottery.Ref;

namespace Gs2Cdk.Gs2Lottery.Resource
{

    public static class LotteryModelModeExt
    {
        public static string ToString(this LotteryModel.Mode self)
        {
            switch (self) {
                case LotteryModel.Mode.Normal:
                    return "normal";
                case LotteryModel.Mode.Box:
                    return "box";
            }
            return "unknown";
        }
    }

    public static class LotteryModelMethodExt
    {
        public static string ToString(this LotteryModel.Method self)
        {
            switch (self) {
                case LotteryModel.Method.PrizeTable:
                    return "prize_table";
                case LotteryModel.Method.Script:
                    return "script";
            }
            return "unknown";
        }
    }

    public class LotteryModel {

        public enum Mode
        {
            Normal,
            Box
        }

        public enum Method
        {
            PrizeTable,
            Script
        }
	    private readonly string _name;
	    private readonly string _metadata;
	    private readonly Mode _mode;
	    private readonly Method _method;
	    private readonly string _prizeTableName;
	    private readonly string _choicePrizeTableScriptId;

        public LotteryModel(
                string name,
                Mode mode,
                Method method,
                string metadata = null,
                string prizeTableName = null,
                string choicePrizeTableScriptId = null
        )
        {
            this._name = name;
            this._metadata = metadata;
            this._mode = mode;
            this._method = method;
            this._prizeTableName = prizeTableName;
            this._choicePrizeTableScriptId = choicePrizeTableScriptId;
        }

        public Dictionary<string, object> Properties()
        {
            var properties = new Dictionary<string, object>();
            if (this._name != null) {
                properties["Name"] = this._name;
            }
            if (this._metadata != null) {
                properties["Metadata"] = this._metadata;
            }
            if (this._mode != null) {
                properties["Mode"] = this._mode.ToString();
            }
            if (this._method != null) {
                properties["Method"] = this._method.ToString();
            }
            if (this._prizeTableName != null) {
                properties["PrizeTableName"] = this._prizeTableName;
            }
            if (this._choicePrizeTableScriptId != null) {
                properties["ChoicePrizeTableScriptId"] = this._choicePrizeTableScriptId;
            }
            return properties;
        }

        public LotteryModelRef Ref(
                string namespaceName
        )
        {
            return new LotteryModelRef(
                namespaceName,
                this._name
            );
        }
    }
}
