using Gs2Cdk.Core.Model;

namespace Gs2Cdk.Core.Func
{
    public class GetAttr : IFunc
    {
        
        private readonly string _key;

        public GetAttr(
            CdkResource resource,
            string path
        ) {
            this._key = resource.ResourceName + "." + path;
        }

        public GetAttr(
            string key
        ) {
            this._key = key;
        }

        public override string ToString() {
            return "!GetAttr " + this._key;
        }

        public static GetAttr Region() {
            return new GetAttr(
                "Gs2::Region"
            );
        }

        public static GetAttr OwnerId() {
            return new GetAttr(
                "Gs2::OwnerId"
            );
        }
    }
}