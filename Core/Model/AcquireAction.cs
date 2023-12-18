using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Gs2Cdk.Core.Model
{
    public abstract class AcquireAction
    {
        public abstract string Action();
        public abstract Dictionary<string, object> Request();

        public Dictionary<string, object> Properties() {
            return new Dictionary<string, object>() {
                {"action", this.Action()},
                {"request", this.Request()},
            };
        }

        public static AcquireAction FromProperties(
            Dictionary<string, object> properties
        ) {
            var acquireActionTypes = Assembly
                .GetAssembly(typeof(AcquireAction))
                .GetTypes()
                .Where(t => t.IsSubclassOf(typeof(AcquireAction)) && !t.IsAbstract)
                .ToList();

            foreach (var consumeActionType in acquireActionTypes) {
                var method = consumeActionType.GetMethod("StaticAction");
                if (method?.IsStatic ?? false) {
                    var action = method.Invoke(null, new object[]{}) as string;
                    if (action == properties["action"] as string) {
                        var method2 = consumeActionType.GetMethod("FromProperties");
                        return method2?.Invoke(null, new object[] {properties["request"] as Dictionary<string, object>}) as AcquireAction;
                    }
                }
            }
            return null;
        }
    }
}