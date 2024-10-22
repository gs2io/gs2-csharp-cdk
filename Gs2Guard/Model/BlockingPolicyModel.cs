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
using System;
using System.Collections.Generic;
using System.Linq;

using Gs2Cdk.Core.Model;
using Gs2Cdk.Gs2Guard.Model;
using Gs2Cdk.Gs2Guard.Model.Enums;
using Gs2Cdk.Gs2Guard.Model.Options;

namespace Gs2Cdk.Gs2Guard.Model
{
    public class BlockingPolicyModel {
        private string[] passServices;
        private BlockingPolicyModelDefaultRestriction? defaultRestriction;
        private BlockingPolicyModelLocationDetection? locationDetection;
        private BlockingPolicyModelAnonymousIpDetection? anonymousIpDetection;
        private BlockingPolicyModelHostingProviderIpDetection? hostingProviderIpDetection;
        private BlockingPolicyModelReputationIpDetection? reputationIpDetection;
        private BlockingPolicyModelIpAddressesDetection? ipAddressesDetection;
        private string[] locations;
        private BlockingPolicyModelLocationRestriction? locationRestriction;
        private BlockingPolicyModelAnonymousIpRestriction? anonymousIpRestriction;
        private BlockingPolicyModelHostingProviderIpRestriction? hostingProviderIpRestriction;
        private BlockingPolicyModelReputationIpRestriction? reputationIpRestriction;
        private string[] ipAddresses;
        private BlockingPolicyModelIpAddressRestriction? ipAddressRestriction;

        public BlockingPolicyModel(
            string[] passServices,
            BlockingPolicyModelDefaultRestriction defaultRestriction,
            BlockingPolicyModelLocationDetection locationDetection,
            BlockingPolicyModelAnonymousIpDetection anonymousIpDetection,
            BlockingPolicyModelHostingProviderIpDetection hostingProviderIpDetection,
            BlockingPolicyModelReputationIpDetection reputationIpDetection,
            BlockingPolicyModelIpAddressesDetection ipAddressesDetection,
            BlockingPolicyModelOptions options = null
        ){
            this.passServices = passServices;
            this.defaultRestriction = defaultRestriction;
            this.locationDetection = locationDetection;
            this.anonymousIpDetection = anonymousIpDetection;
            this.hostingProviderIpDetection = hostingProviderIpDetection;
            this.reputationIpDetection = reputationIpDetection;
            this.ipAddressesDetection = ipAddressesDetection;
            this.locations = options?.locations;
            this.locationRestriction = options?.locationRestriction;
            this.anonymousIpRestriction = options?.anonymousIpRestriction;
            this.hostingProviderIpRestriction = options?.hostingProviderIpRestriction;
            this.reputationIpRestriction = options?.reputationIpRestriction;
            this.ipAddresses = options?.ipAddresses;
            this.ipAddressRestriction = options?.ipAddressRestriction;
        }

        public static BlockingPolicyModel LocationDetectionIsEnable(
            string[] passServices,
            BlockingPolicyModelDefaultRestriction defaultRestriction,
            BlockingPolicyModelAnonymousIpDetection anonymousIpDetection,
            BlockingPolicyModelHostingProviderIpDetection hostingProviderIpDetection,
            BlockingPolicyModelReputationIpDetection reputationIpDetection,
            BlockingPolicyModelIpAddressesDetection ipAddressesDetection,
            string[] locations,
            BlockingPolicyModelLocationRestriction locationRestriction,
            BlockingPolicyModelLocationDetectionIsEnableOptions options = null
        ){
            return (new BlockingPolicyModel(
                passServices,
                defaultRestriction,
                BlockingPolicyModelLocationDetection.Enable,
                anonymousIpDetection,
                hostingProviderIpDetection,
                reputationIpDetection,
                ipAddressesDetection,
                new BlockingPolicyModelOptions {
                    locations = locations,
                    locationRestriction = locationRestriction,
                    ipAddresses = options?.ipAddresses,
                }
            ));
        }

        public static BlockingPolicyModel LocationDetectionIsDisable(
            string[] passServices,
            BlockingPolicyModelDefaultRestriction defaultRestriction,
            BlockingPolicyModelAnonymousIpDetection anonymousIpDetection,
            BlockingPolicyModelHostingProviderIpDetection hostingProviderIpDetection,
            BlockingPolicyModelReputationIpDetection reputationIpDetection,
            BlockingPolicyModelIpAddressesDetection ipAddressesDetection,
            BlockingPolicyModelLocationDetectionIsDisableOptions options = null
        ){
            return (new BlockingPolicyModel(
                passServices,
                defaultRestriction,
                BlockingPolicyModelLocationDetection.Disable,
                anonymousIpDetection,
                hostingProviderIpDetection,
                reputationIpDetection,
                ipAddressesDetection,
                new BlockingPolicyModelOptions {
                    ipAddresses = options?.ipAddresses,
                }
            ));
        }

        public static BlockingPolicyModel AnonymousIpDetectionIsEnable(
            string[] passServices,
            BlockingPolicyModelDefaultRestriction defaultRestriction,
            BlockingPolicyModelLocationDetection locationDetection,
            BlockingPolicyModelHostingProviderIpDetection hostingProviderIpDetection,
            BlockingPolicyModelReputationIpDetection reputationIpDetection,
            BlockingPolicyModelIpAddressesDetection ipAddressesDetection,
            BlockingPolicyModelAnonymousIpRestriction anonymousIpRestriction,
            BlockingPolicyModelAnonymousIpDetectionIsEnableOptions options = null
        ){
            return (new BlockingPolicyModel(
                passServices,
                defaultRestriction,
                locationDetection,
                BlockingPolicyModelAnonymousIpDetection.Enable,
                hostingProviderIpDetection,
                reputationIpDetection,
                ipAddressesDetection,
                new BlockingPolicyModelOptions {
                    anonymousIpRestriction = anonymousIpRestriction,
                    ipAddresses = options?.ipAddresses,
                }
            ));
        }

        public static BlockingPolicyModel AnonymousIpDetectionIsDisable(
            string[] passServices,
            BlockingPolicyModelDefaultRestriction defaultRestriction,
            BlockingPolicyModelLocationDetection locationDetection,
            BlockingPolicyModelHostingProviderIpDetection hostingProviderIpDetection,
            BlockingPolicyModelReputationIpDetection reputationIpDetection,
            BlockingPolicyModelIpAddressesDetection ipAddressesDetection,
            BlockingPolicyModelAnonymousIpDetectionIsDisableOptions options = null
        ){
            return (new BlockingPolicyModel(
                passServices,
                defaultRestriction,
                locationDetection,
                BlockingPolicyModelAnonymousIpDetection.Disable,
                hostingProviderIpDetection,
                reputationIpDetection,
                ipAddressesDetection,
                new BlockingPolicyModelOptions {
                    ipAddresses = options?.ipAddresses,
                }
            ));
        }

        public static BlockingPolicyModel HostingProviderIpDetectionIsEnable(
            string[] passServices,
            BlockingPolicyModelDefaultRestriction defaultRestriction,
            BlockingPolicyModelLocationDetection locationDetection,
            BlockingPolicyModelAnonymousIpDetection anonymousIpDetection,
            BlockingPolicyModelReputationIpDetection reputationIpDetection,
            BlockingPolicyModelIpAddressesDetection ipAddressesDetection,
            BlockingPolicyModelHostingProviderIpRestriction hostingProviderIpRestriction,
            BlockingPolicyModelHostingProviderIpDetectionIsEnableOptions options = null
        ){
            return (new BlockingPolicyModel(
                passServices,
                defaultRestriction,
                locationDetection,
                anonymousIpDetection,
                BlockingPolicyModelHostingProviderIpDetection.Enable,
                reputationIpDetection,
                ipAddressesDetection,
                new BlockingPolicyModelOptions {
                    hostingProviderIpRestriction = hostingProviderIpRestriction,
                    ipAddresses = options?.ipAddresses,
                }
            ));
        }

        public static BlockingPolicyModel HostingProviderIpDetectionIsDisable(
            string[] passServices,
            BlockingPolicyModelDefaultRestriction defaultRestriction,
            BlockingPolicyModelLocationDetection locationDetection,
            BlockingPolicyModelAnonymousIpDetection anonymousIpDetection,
            BlockingPolicyModelReputationIpDetection reputationIpDetection,
            BlockingPolicyModelIpAddressesDetection ipAddressesDetection,
            BlockingPolicyModelHostingProviderIpDetectionIsDisableOptions options = null
        ){
            return (new BlockingPolicyModel(
                passServices,
                defaultRestriction,
                locationDetection,
                anonymousIpDetection,
                BlockingPolicyModelHostingProviderIpDetection.Disable,
                reputationIpDetection,
                ipAddressesDetection,
                new BlockingPolicyModelOptions {
                    ipAddresses = options?.ipAddresses,
                }
            ));
        }

        public static BlockingPolicyModel ReputationIpDetectionIsEnable(
            string[] passServices,
            BlockingPolicyModelDefaultRestriction defaultRestriction,
            BlockingPolicyModelLocationDetection locationDetection,
            BlockingPolicyModelAnonymousIpDetection anonymousIpDetection,
            BlockingPolicyModelHostingProviderIpDetection hostingProviderIpDetection,
            BlockingPolicyModelIpAddressesDetection ipAddressesDetection,
            BlockingPolicyModelReputationIpRestriction reputationIpRestriction,
            BlockingPolicyModelReputationIpDetectionIsEnableOptions options = null
        ){
            return (new BlockingPolicyModel(
                passServices,
                defaultRestriction,
                locationDetection,
                anonymousIpDetection,
                hostingProviderIpDetection,
                BlockingPolicyModelReputationIpDetection.Enable,
                ipAddressesDetection,
                new BlockingPolicyModelOptions {
                    reputationIpRestriction = reputationIpRestriction,
                    ipAddresses = options?.ipAddresses,
                }
            ));
        }

        public static BlockingPolicyModel ReputationIpDetectionIsDisable(
            string[] passServices,
            BlockingPolicyModelDefaultRestriction defaultRestriction,
            BlockingPolicyModelLocationDetection locationDetection,
            BlockingPolicyModelAnonymousIpDetection anonymousIpDetection,
            BlockingPolicyModelHostingProviderIpDetection hostingProviderIpDetection,
            BlockingPolicyModelIpAddressesDetection ipAddressesDetection,
            BlockingPolicyModelReputationIpDetectionIsDisableOptions options = null
        ){
            return (new BlockingPolicyModel(
                passServices,
                defaultRestriction,
                locationDetection,
                anonymousIpDetection,
                hostingProviderIpDetection,
                BlockingPolicyModelReputationIpDetection.Disable,
                ipAddressesDetection,
                new BlockingPolicyModelOptions {
                    ipAddresses = options?.ipAddresses,
                }
            ));
        }

        public static BlockingPolicyModel IpAddressesDetectionIsEnable(
            string[] passServices,
            BlockingPolicyModelDefaultRestriction defaultRestriction,
            BlockingPolicyModelLocationDetection locationDetection,
            BlockingPolicyModelAnonymousIpDetection anonymousIpDetection,
            BlockingPolicyModelHostingProviderIpDetection hostingProviderIpDetection,
            BlockingPolicyModelReputationIpDetection reputationIpDetection,
            BlockingPolicyModelIpAddressRestriction ipAddressRestriction,
            BlockingPolicyModelIpAddressesDetectionIsEnableOptions options = null
        ){
            return (new BlockingPolicyModel(
                passServices,
                defaultRestriction,
                locationDetection,
                anonymousIpDetection,
                hostingProviderIpDetection,
                reputationIpDetection,
                BlockingPolicyModelIpAddressesDetection.Enable,
                new BlockingPolicyModelOptions {
                    ipAddressRestriction = ipAddressRestriction,
                    ipAddresses = options?.ipAddresses,
                }
            ));
        }

        public static BlockingPolicyModel IpAddressesDetectionIsDisable(
            string[] passServices,
            BlockingPolicyModelDefaultRestriction defaultRestriction,
            BlockingPolicyModelLocationDetection locationDetection,
            BlockingPolicyModelAnonymousIpDetection anonymousIpDetection,
            BlockingPolicyModelHostingProviderIpDetection hostingProviderIpDetection,
            BlockingPolicyModelReputationIpDetection reputationIpDetection,
            BlockingPolicyModelIpAddressesDetectionIsDisableOptions options = null
        ){
            return (new BlockingPolicyModel(
                passServices,
                defaultRestriction,
                locationDetection,
                anonymousIpDetection,
                hostingProviderIpDetection,
                reputationIpDetection,
                BlockingPolicyModelIpAddressesDetection.Disable,
                new BlockingPolicyModelOptions {
                    ipAddresses = options?.ipAddresses,
                }
            ));
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.passServices != null) {
                properties["passServices"] = this.passServices;
            }
            if (this.defaultRestriction != null) {
                properties["defaultRestriction"] = this.defaultRestriction.Value.Str(
                );
            }
            if (this.locationDetection != null) {
                properties["locationDetection"] = this.locationDetection.Value.Str(
                );
            }
            if (this.locations != null) {
                properties["locations"] = this.locations;
            }
            if (this.locationRestriction != null) {
                properties["locationRestriction"] = this.locationRestriction.Value.Str(
                );
            }
            if (this.anonymousIpDetection != null) {
                properties["anonymousIpDetection"] = this.anonymousIpDetection.Value.Str(
                );
            }
            if (this.anonymousIpRestriction != null) {
                properties["anonymousIpRestriction"] = this.anonymousIpRestriction.Value.Str(
                );
            }
            if (this.hostingProviderIpDetection != null) {
                properties["hostingProviderIpDetection"] = this.hostingProviderIpDetection.Value.Str(
                );
            }
            if (this.hostingProviderIpRestriction != null) {
                properties["hostingProviderIpRestriction"] = this.hostingProviderIpRestriction.Value.Str(
                );
            }
            if (this.reputationIpDetection != null) {
                properties["reputationIpDetection"] = this.reputationIpDetection.Value.Str(
                );
            }
            if (this.reputationIpRestriction != null) {
                properties["reputationIpRestriction"] = this.reputationIpRestriction.Value.Str(
                );
            }
            if (this.ipAddressesDetection != null) {
                properties["ipAddressesDetection"] = this.ipAddressesDetection.Value.Str(
                );
            }
            if (this.ipAddresses != null) {
                properties["ipAddresses"] = this.ipAddresses;
            }
            if (this.ipAddressRestriction != null) {
                properties["ipAddressRestriction"] = this.ipAddressRestriction.Value.Str(
                );
            }

            return properties;
        }

        public static BlockingPolicyModel FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new BlockingPolicyModel(
                properties.TryGetValue("passServices", out var passServices) ? new Func<string[]>(() =>
                {
                    return passServices switch {
                        string[] v => v.ToArray(),
                        List<string> v => v.ToArray(),
                        object[] v => v.Select(v2 => v2?.ToString()).ToArray(),
                        { } v => new []{ v.ToString() },
                        _ => null
                    };
                })() : null,
                properties.TryGetValue("defaultRestriction", out var defaultRestriction) ? new Func<BlockingPolicyModelDefaultRestriction>(() =>
                {
                    return defaultRestriction switch {
                        BlockingPolicyModelDefaultRestriction e => e,
                        string s => BlockingPolicyModelDefaultRestrictionExt.New(s),
                        _ => BlockingPolicyModelDefaultRestriction.Allow
                    };
                })() : default,
                properties.TryGetValue("locationDetection", out var locationDetection) ? new Func<BlockingPolicyModelLocationDetection>(() =>
                {
                    return locationDetection switch {
                        BlockingPolicyModelLocationDetection e => e,
                        string s => BlockingPolicyModelLocationDetectionExt.New(s),
                        _ => BlockingPolicyModelLocationDetection.Enable
                    };
                })() : default,
                properties.TryGetValue("anonymousIpDetection", out var anonymousIpDetection) ? new Func<BlockingPolicyModelAnonymousIpDetection>(() =>
                {
                    return anonymousIpDetection switch {
                        BlockingPolicyModelAnonymousIpDetection e => e,
                        string s => BlockingPolicyModelAnonymousIpDetectionExt.New(s),
                        _ => BlockingPolicyModelAnonymousIpDetection.Enable
                    };
                })() : default,
                properties.TryGetValue("hostingProviderIpDetection", out var hostingProviderIpDetection) ? new Func<BlockingPolicyModelHostingProviderIpDetection>(() =>
                {
                    return hostingProviderIpDetection switch {
                        BlockingPolicyModelHostingProviderIpDetection e => e,
                        string s => BlockingPolicyModelHostingProviderIpDetectionExt.New(s),
                        _ => BlockingPolicyModelHostingProviderIpDetection.Enable
                    };
                })() : default,
                properties.TryGetValue("reputationIpDetection", out var reputationIpDetection) ? new Func<BlockingPolicyModelReputationIpDetection>(() =>
                {
                    return reputationIpDetection switch {
                        BlockingPolicyModelReputationIpDetection e => e,
                        string s => BlockingPolicyModelReputationIpDetectionExt.New(s),
                        _ => BlockingPolicyModelReputationIpDetection.Enable
                    };
                })() : default,
                properties.TryGetValue("ipAddressesDetection", out var ipAddressesDetection) ? new Func<BlockingPolicyModelIpAddressesDetection>(() =>
                {
                    return ipAddressesDetection switch {
                        BlockingPolicyModelIpAddressesDetection e => e,
                        string s => BlockingPolicyModelIpAddressesDetectionExt.New(s),
                        _ => BlockingPolicyModelIpAddressesDetection.Enable
                    };
                })() : default,
                new BlockingPolicyModelOptions {
                    locations = properties.TryGetValue("locations", out var locations) ? new Func<string[]>(() =>
                    {
                        return locations switch {
                            string[] v => v.ToArray(),
                            List<string> v => v.ToArray(),
                            _ => null
                        };
                    })() : null,
                    locationRestriction = properties.TryGetValue("locationRestriction", out var locationRestriction) ? BlockingPolicyModelLocationRestrictionExt.New(locationRestriction as string) : BlockingPolicyModelLocationRestriction.Allow,
                    anonymousIpRestriction = properties.TryGetValue("anonymousIpRestriction", out var anonymousIpRestriction) ? BlockingPolicyModelAnonymousIpRestrictionExt.New(anonymousIpRestriction as string) : BlockingPolicyModelAnonymousIpRestriction.Deny,
                    hostingProviderIpRestriction = properties.TryGetValue("hostingProviderIpRestriction", out var hostingProviderIpRestriction) ? BlockingPolicyModelHostingProviderIpRestrictionExt.New(hostingProviderIpRestriction as string) : BlockingPolicyModelHostingProviderIpRestriction.Deny,
                    reputationIpRestriction = properties.TryGetValue("reputationIpRestriction", out var reputationIpRestriction) ? BlockingPolicyModelReputationIpRestrictionExt.New(reputationIpRestriction as string) : BlockingPolicyModelReputationIpRestriction.Deny,
                    ipAddresses = properties.TryGetValue("ipAddresses", out var ipAddresses) ? new Func<string[]>(() =>
                    {
                        return ipAddresses switch {
                            string[] v => v.ToArray(),
                            List<string> v => v.ToArray(),
                            _ => null
                        };
                    })() : null,
                    ipAddressRestriction = properties.TryGetValue("ipAddressRestriction", out var ipAddressRestriction) ? BlockingPolicyModelIpAddressRestrictionExt.New(ipAddressRestriction as string) : BlockingPolicyModelIpAddressRestriction.Allow
                }
            );

            return model;
        }
    }
}
