using System.Collections.Generic;
using System.Linq;

namespace Gs2Cdk.Core.Func
{
    public class Join : IFunc
    {
        private readonly string _separator;
        private readonly string[] _values;

        public Join(
            string separator,
            string[] values
        ) {
            this._separator = separator;
            this._values = values;
        }

        public string Str() {
            return "!Join ['" + this._separator + "', [" + string.Join(",", this._values) + "]]";
        }

    }
}