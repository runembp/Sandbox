using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;

namespace DTL.Entities
{
    [EntityLogicalName(EntityLogicalName)]
    public class ProductEntity : BaseEntity
    {
        public const string EntityLogicalName = "product";
        private const string EntityId = "productid";

        public const string FieldProductCode = "new_productcode";

        [AttributeLogicalName(FieldProductCode)]
        public string ProductCode
        {
            get => Get<string>();
            set => Set(value);
        }
    }
}