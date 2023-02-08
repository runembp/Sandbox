using System.ComponentModel.DataAnnotations.Schema;

namespace DTL.Entities
{
    [Table(PluralLogicalName)]
    public class ContactRelationEntity
    {
        private const string PluralLogicalName = "new_contactrelationses";
        
        public const string LogicalName = "new_contactrelations";

        public const string FieldAccount = "new_accountnameid";
        public const string FieldAccountCeo = "new_accountceo";
        public const string FieldAccountCfo = "new_accountcfo";
        public const string FieldAccountPensionResponsible1 = "new_accountpensionresponsible1";
        public const string FieldAccountPensionResponsible2 = "new_accountpensionresponsible2";
        public const string FieldAccountVellivSundhedspartner = "new_accountvellivsundhedspartner";
        public const string FieldAccountPayrollAdministrator = "new_accountpayrolladministrator";
        public const string FieldAccountHrDirectorManager = "new_accounthrdirectorhrmanager";
        public const string FieldAccountAttRiskReport = "new_accountattriskreport";

        [Column(FieldAccountCfo)]
        public bool AccountCfo { get; set; }
    }
}