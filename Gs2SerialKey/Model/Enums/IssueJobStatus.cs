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


namespace Gs2Cdk.Gs2SerialKey.Model.Enums
{
    
    public enum IssueJobStatus {
        Processing,
        Complete
    }

    public static class IssueJobStatusExt
    {
        public static string Str(this IssueJobStatus self) {
            switch (self) {
                case IssueJobStatus.Processing:
                    return "PROCESSING";
                case IssueJobStatus.Complete:
                    return "COMPLETE";
            }
            return "unknown";
        }

        public static IssueJobStatus New(string value) {
            switch (value) {
                case "PROCESSING":
                    return IssueJobStatus.Processing;
                case "COMPLETE":
                    return IssueJobStatus.Complete;
            }
            return IssueJobStatus.Processing;
        }
    }
}
