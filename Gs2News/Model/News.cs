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
using Gs2Cdk.Gs2News.Resource;

namespace Gs2Cdk.Gs2News.Model
{

    public class News
    {
	    private readonly string _section;
	    private readonly string _content;
	    private readonly string _title;
	    private readonly string _scheduleEventId;
	    private readonly long? _timestamp;
	    private readonly string _frontMatter;

        public News(
                string section,
                string content,
                string title,
                long? timestamp,
                string frontMatter,
                string scheduleEventId = null
        )
        {
            this._section = section;
            this._content = content;
            this._title = title;
            this._scheduleEventId = scheduleEventId;
            this._timestamp = timestamp;
            this._frontMatter = frontMatter;
        }

        public Dictionary<string, object> Properties() {
            var properties = new Dictionary<string, object>();
            if (this._section != null) {
                properties["Section"] = this._section;
            }
            if (this._content != null) {
                properties["Content"] = this._content;
            }
            if (this._title != null) {
                properties["Title"] = this._title;
            }
            if (this._scheduleEventId != null) {
                properties["ScheduleEventId"] = this._scheduleEventId;
            }
            if (this._timestamp != null) {
                properties["Timestamp"] = this._timestamp;
            }
            if (this._frontMatter != null) {
                properties["FrontMatter"] = this._frontMatter;
            }
            return properties;
        }
    }
}
