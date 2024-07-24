using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Gs2Cdk.Core.Model
{
    public abstract class VerifyAction : ConsumeAction
    {
        public new static VerifyAction FromProperties(
            Dictionary<string, object> properties
        ) {
            var consumeActionTypes = Assembly
                .GetAssembly(typeof(VerifyAction))
                .GetTypes()
                .Where(t => t.IsSubclassOf(typeof(VerifyAction)) && !t.IsAbstract)
                .ToList();

            foreach (var consumeActionType in consumeActionTypes) {
                var method = consumeActionType.GetMethod("StaticAction");
                if (method?.IsStatic ?? false) {
                    var action = method.Invoke(null, new object[]{}) as string;
                    if (action == properties["action"] as string) {
                        var method2 = consumeActionType.GetMethod("FromProperties");
                        return method2?.Invoke(null, new object[] {properties["request"] as Dictionary<string, object>}) as VerifyAction;
                    }
                }
            }
            return null;
        }
    }
}