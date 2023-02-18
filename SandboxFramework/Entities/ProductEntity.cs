using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTL.Entities
{
    [Table(LogicalName)]
    public class ProductEntity
    {
        private const string LogicalName = "product";

        private const string FieldProductCode = "new_productcode";
        private const string FieldProductId = "productid";

        [Column(FieldProductId)]
        public Guid Id { get; set; }
        
        [Column(FieldProductCode)]
        public string ProductCode { get; set; }
    }
}