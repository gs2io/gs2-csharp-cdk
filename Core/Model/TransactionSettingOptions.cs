using System.Collections.Generic;

namespace Gs2Cdk.Core.Model
{
    public class TransactionSettingOptions
    {
        public bool? enableAtomicCommit;
        public bool? transactionUseDistributor;
        public bool? acquireActionUseJobQueue;
        public string distributorNamespaceId;
        public string queueNamespaceId;
    }
}