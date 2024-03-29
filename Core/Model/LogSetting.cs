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
            var properties = new Dictionary<string, object>();
            if (this._loggingNamespaceId != null) {
                properties["LoggingNamespaceId"] = this._loggingNamespaceId;
            }
            return properties;
        }
        
        public static LogSetting FromProperties(
            Dictionary<string, object> properties
        ) {
            var model = new LogSetting(
                properties.TryGetValue("loggingNamespaceId", out var loggingNamespaceId) ? (string)loggingNamespaceId : null
            );
            return model;
        }
    }
}