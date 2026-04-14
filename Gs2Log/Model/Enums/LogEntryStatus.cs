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
    
    public enum LogEntryStatus {
        Ok,
        Info,
        Notice,
        Error,
        Warn,
        Emag
    }

    public static class LogEntryStatusExt
    {
        public static string Str(this LogEntryStatus self) {
            switch (self) {
                case LogEntryStatus.Ok:
                    return "ok";
                case LogEntryStatus.Info:
                    return "info";
                case LogEntryStatus.Notice:
                    return "notice";
                case LogEntryStatus.Error:
                    return "error";
                case LogEntryStatus.Warn:
                    return "warn";
                case LogEntryStatus.Emag:
                    return "emag";
            }
            return "unknown";
        }

        public static LogEntryStatus New(string value) {
            switch (value) {
                case "ok":
                    return LogEntryStatus.Ok;
                case "info":
                    return LogEntryStatus.Info;
                case "notice":
                    return LogEntryStatus.Notice;
                case "error":
                    return LogEntryStatus.Error;
                case "warn":
                    return LogEntryStatus.Warn;
                case "emag":
                    return LogEntryStatus.Emag;
            }
            return LogEntryStatus.Ok;
        }
    }
}
