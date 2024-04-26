namespace Gs2Cdk.Gs2Buff.Model.Enums
{
    public enum BuffTargetModelTargetModelName
    {
        Gs2InventoryInventoryModel
    }

    public static class BuffTargetModelTargetModelNameExt
    {
        public static string Str(this BuffTargetModelTargetModelName self) {
            switch (self) {
                case BuffTargetModelTargetModelName.Gs2InventoryInventoryModel:
                    return "Gs2Inventory:InventoryModel";
            }
            return "unknown";
        }

        public static BuffTargetModelTargetModelName New(string value) {
            switch (value) {
                case "Gs2Inventory:InventoryModel":
                    return BuffTargetModelTargetModelName.Gs2InventoryInventoryModel;
            }
            return BuffTargetModelTargetModelName.Gs2InventoryInventoryModel;
        }
    }
}
