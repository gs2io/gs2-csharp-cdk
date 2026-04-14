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
    
    public enum FacetModelType {
        String,
        Double,
        Measure
    }

    public static class FacetModelTypeExt
    {
        public static string Str(this FacetModelType self) {
            switch (self) {
                case FacetModelType.String:
                    return "string";
                case FacetModelType.Double:
                    return "double";
                case FacetModelType.Measure:
                    return "measure";
            }
            return "unknown";
        }

        public static FacetModelType New(string value) {
            switch (value) {
                case "string":
                    return FacetModelType.String;
                case "double":
                    return FacetModelType.Double;
                case "measure":
                    return FacetModelType.Measure;
            }
            return FacetModelType.String;
        }
    }
}
