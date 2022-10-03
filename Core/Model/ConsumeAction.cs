using System.Collections.Generic;

namespace Gs2Cdk.Core.Model
{
    public class ConsumeAction
    {
        private readonly string _action;
        private readonly Dictionary<string, object> _request;

        public ConsumeAction(
            string action,
            Dictionary<string, object> request
        ) {
            this._action = action;
            this._request = request;
        }

        public Dictionary<string, object> Properties() {
            return new Dictionary<string, object>() {
                {"action", this._action},
                {"request", this._request},
            };
        }
    }
}