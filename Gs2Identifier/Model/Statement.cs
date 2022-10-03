using System.Collections.Generic;

namespace Gs2Cdk.Gs2Identifier.Model
{
    public class Statement
    {
        private readonly string _effect;
        private readonly string[] _actions;

        public Statement(
            string effect,
            string[] actions
        )
        {
            this._effect = effect;
            this._actions = actions;
        }

        public static Statement Allow(
            string[] actions
        ) {
            return new Statement(
                "Allow",
                actions
            );
        }

        public static Statement AllowAll() {
            return new Statement(
                "Allow",
                new string[]{"*"}
            );
        }

        public static Statement Deny(
            string[] actions
        ) {
            return new Statement(
                "Deny",
                actions
            );
        }

        public static Statement DenyAll() {
            return new Statement(
                "Deny",
                new string[]{"*"}
            );
        }

        public Dictionary<string, object> Properties() {
            return new Dictionary<string, object>() {
                {"Effect", _effect},
                {"Actions", _actions},
                {"Resources", new string[]{"*"}},
            };
        }
    }
}