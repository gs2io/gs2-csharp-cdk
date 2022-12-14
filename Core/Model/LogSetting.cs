using System.Collections.Generic;

namespace Gs2Cdk.Core.Model
{
    public class LogSetting
    {
        private readonly string _loggingNamespaceId;

        public LogSetting(
            string loggingNamespaceId
        ) {
            this._loggingNamespaceId = loggingNamespaceId;
        }

        public Dictionary<string, object> Properties() {
            return new Dictionary<string, object>() {
                {"LoggingNamespaceId", _loggingNamespaceId},
            };
        }
    }
}