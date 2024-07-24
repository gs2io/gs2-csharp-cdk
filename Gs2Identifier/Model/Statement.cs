using System.Collections.Generic;

namespace Gs2Cdk.Gs2Identifier.Model
{
    public class Statement
    {
        private readonly string _effect;
        private readonly string[] _actions;
        private readonly string[] _resources;

        public Statement(
            string effect,
            string[] actions,
            string[] resources = null
        )
        {
            this._effect = effect;
            this._actions = actions;
            this._resources = resources == null ? new string[]{"*"} : resources;
        }

        public static Statement Allow(
            string[] actions,
            string[] resources = null
        ) {
            return new Statement(
                "Allow",
                actions,
                resources
            );
        }

        public static Statement AllowAll() {
            return new Statement(
                "Allow",
                new string[]{"*"}
            );
        }

        public static Statement Deny(
            string[] actions,
            string[] resources = null
        ) {
            return new Statement(
                "Deny",
                actions,
                resources
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
                {"Resources", _resources},
            };
        }
    }
}