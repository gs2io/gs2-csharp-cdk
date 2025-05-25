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


namespace Gs2Cdk.Gs2Freeze.Model.Enums
{
    
    public enum StageStatus {
        Active,
        Updating,
        UpdateFailed
    }

    public static class StageStatusExt
    {
        public static string Str(this StageStatus self) {
            switch (self) {
                case StageStatus.Active:
                    return "Active";
                case StageStatus.Updating:
                    return "Updating";
                case StageStatus.UpdateFailed:
                    return "UpdateFailed";
            }
            return "unknown";
        }

        public static StageStatus New(string value) {
            switch (value) {
                case "Active":
                    return StageStatus.Active;
                case "Updating":
                    return StageStatus.Updating;
                case "UpdateFailed":
                    return StageStatus.UpdateFailed;
            }
            return StageStatus.Active;
        }
    }
}
