namespace Gs2Cdk.Gs2Buff.Model.Enums
{
    public enum BuffTargetActionTargetActionName
    {
        Gs2InventoryAcquireItemSetByUserId
    }

    public static class BuffTargetActionTargetActionNameExt
    {
        public static string Str(this BuffTargetActionTargetActionName self) {
            switch (self) {
                case BuffTargetActionTargetActionName.Gs2InventoryAcquireItemSetByUserId:
                    return "Gs2Inventory:AcquireItemSetByUserId";
            }
            return "unknown";
        }

        public static BuffTargetActionTargetActionName New(string value) {
            switch (value) {
                case "Gs2Inventory:AcquireItemSetByUserId":
                    return BuffTargetActionTargetActionName.Gs2InventoryAcquireItemSetByUserId;
            }
            return BuffTargetActionTargetActionName.Gs2InventoryAcquireItemSetByUserId;
        }
    }
}
