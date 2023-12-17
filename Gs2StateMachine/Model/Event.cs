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
using Gs2Cdk.Gs2StateMachine.Model;
using Gs2Cdk.Gs2StateMachine.Model.Enums;
using Gs2Cdk.Gs2StateMachine.Model.Options;

namespace Gs2Cdk.Gs2StateMachine.Model
{
    public class Event {
        private EventEventType? eventType;
        private ChangeStateEvent changeStateEvent;
        private EmitEvent emitEvent;

        public Event(
            EventEventType eventType,
            EventOptions options = null
        ){
            this.eventType = eventType;
            this.changeStateEvent = options?.changeStateEvent;
            this.emitEvent = options?.emitEvent;
        }

        public static Event EventTypeIsChangeState(
            ChangeStateEvent changeStateEvent,
            EventEventTypeIsChangeStateOptions options = null
        ){
            return (new Event(
                EventEventType.ChangeState,
                new EventOptions {
                    changeStateEvent = changeStateEvent,
                }
            ));
        }

        public static Event EventTypeIsEmit(
            EmitEvent emitEvent,
            EventEventTypeIsEmitOptions options = null
        ){
            return (new Event(
                EventEventType.Emit,
                new EventOptions {
                    emitEvent = emitEvent,
                }
            ));
        }

        public Dictionary<string, object> Properties(
        ){
            var properties = new Dictionary<string, object>();

            if (this.eventType != null) {
                properties["eventType"] = this.eventType?.Str(
                );
            }
            if (this.changeStateEvent != null) {
                properties["changeStateEvent"] = this.changeStateEvent?.Properties(
                );
            }
            if (this.emitEvent != null) {
                properties["emitEvent"] = this.emitEvent?.Properties(
                );
            }

            return properties;
        }

        public static Event FromProperties(
            Dictionary<string, object> properties
        ){
            var model = new Event(
                new Func<EventEventType>(() =>
                {
                    return properties["eventType"] switch {
                        EventEventType e => e,
                        string s => EventEventTypeExt.New(s),
                        _ => EventEventType.ChangeState
                    };
                })(),
                new EventOptions {
                    changeStateEvent = properties.TryGetValue("changeStateEvent", out var changeStateEvent) ? new Func<ChangeStateEvent>(() =>
                    {
                        return changeStateEvent switch {
                            ChangeStateEvent v => v,
                            Dictionary<string, object> v => ChangeStateEvent.FromProperties(v),
                            _ => null
                        };
                    })() : null,
                    emitEvent = properties.TryGetValue("emitEvent", out var emitEvent) ? new Func<EmitEvent>(() =>
                    {
                        return emitEvent switch {
                            EmitEvent v => v,
                            Dictionary<string, object> v => EmitEvent.FromProperties(v),
                            _ => null
                        };
                    })() : null
                }
            );

            return model;
        }
    }
}
