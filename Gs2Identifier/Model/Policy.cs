using System.Collections.Generic;
using System.Linq;

namespace Gs2Cdk.Gs2Identifier.Model
{
    public class Policy
    {
        private readonly string _version = "2016-04-01";
        private readonly Statement[] _statements;

        public  Policy(
            Statement[] statements
        ) {
            this._statements = statements;
        }

        public Dictionary<string, object> Properties() {
            return new Dictionary<string, object>() {
                {"Version", _version},
                {"Statements", _statements.Select(v => v.Properties()).ToArray()},
            };
        }

    }
}