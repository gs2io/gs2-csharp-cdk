using Gs2Cdk.Core.Model;

namespace Gs2Cdk.Core.Func
{
    public class GetAttr : IFunc
    {
        
        private readonly string _key;

        public GetAttr(
            CdkResource resource,
            string path,
            string key
        ) {
            if (key != null) {
                this._key = key;
            } else {
                this._key = resource.ResourceName + "." + path;
            }
        }

        public string Str() {
            return "!GetAttr " + this._key;
        }

        public static GetAttr Region() {
            return new GetAttr(
                null,
                null,
                "Gs2::Region"
            );
        }

        public static GetAttr OwnerId() {
            return new GetAttr(
                null,
                null,
                "Gs2::OwnerId"
            );
        }
    }
}