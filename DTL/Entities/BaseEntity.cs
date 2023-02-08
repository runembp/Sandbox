using System.ComponentModel.DataAnnotations.Schema;

namespace DTL.Entities;

public class BaseEntity
{
    public const string FieldStateCode = "statecode";
    public const string FieldStatusCode = "statuscode";
    public const string FieldModifiedOn = "modifiedon";
    
    [Column(FieldModifiedOn)]
    public DateTime? ModifiedOn { get; set; }


}