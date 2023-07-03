using System;
using System.Reflection;
using CsvHelper.Configuration.Attributes;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;

namespace SandboxFramework.Tools
{
    [EntityLogicalName(EntityLogicalName)]
    public class ContactEntity : BaseEntity
    {
        public ContactEntity()
        {
            LogicalName = typeof(ContactEntity).GetCustomAttribute<EntityLogicalNameAttribute>().LogicalName;
        }

        public const string EntityLogicalName = "contact";
        public const string FieldFfKey = "new_ffkey";
        public const string FieldCprNumber = "new_cprnumber";
        public const string FieldUnformattedCprNumber = "new_unformatedcpr";
        public const string FieldFirstName = "firstname";
        public const string FieldLastName = "lastname";
        public const string FieldFirstAndLastName = "new_firstlastname";
        public const string FieldJobTitle = "jobtitle";
        public const string FieldAddress1Line1 = "address1_line1";
        public const string FieldAddress1PostalCode = "address1_postalcode";
        public const string FieldAddress1City = "address1_city";
        public const string FieldAddress1Country = "address1_country";
        public const string FieldAddressTypeCode = "address1_addresstypecode";
        public const string FieldFloor = "new_floor";
        public const string FieldDoor = "new_door";
        public const string FieldPlace = "new_stednavn";
        public const string FieldAddressProtected = "new_addressprotected";
        public const string FieldEmailReflection = "new_emailreflection";
        public const string FieldCoName = "new_coname";
        public const string FieldFfKeyN16 = "new_ffkeyn16";
        public const string FieldEmailReflectionValidationNOk = "new_emailreflectionvalidationnok";
        public const string FieldDoNotBulkEmail = "donotbulkemail";
        public const string FieldDoNotSendMm = "donotsendmm";
        public const string FieldBirthDate = "birthdate";
        public const string FieldStaffMember = "new_staffmemberid";
        public const string FieldOrganizationalUnit = "new_organizationalunitid";
        public const string FieldSegmentation = "new_segmentationid";
        public const string FieldPalFritaget = "new_palfritaget";
        public const string FieldFamilyStatusCode = "familystatuscode";
        public const string FieldEmailDate = "new_emaildate";
        public const string FieldEmailSource = "new_emailsource";
        public const string FieldEmailMarketingDate = "new_emailmarketingdate";
        public const string FieldEmail = "new_email";
        public const string FieldEboks = "new_eboks";
        public const string FieldEboksSource = "new_ebokssource";
        public const string FieldEboksDate = "new_eboksdate";
        public const string FieldApp = "new_app";
        public const string FieldAppSource = "new_appsource";
        public const string FieldAppDate = "new_appdate";
        public const string FieldLetter = "new_letter";
        public const string FieldLetterSource = "new_lettersource";
        public const string FieldLetterDate = "new_letterdate";
        public const string FieldSms = "new_sms";
        public const string FieldSmsSource = "new_smssource";
        public const string FieldSmsDate = "new_smsdate";
        public const string FieldPhone = "new_phone";
        public const string FieldPhoneSource = "new_phonesource";
        public const string FieldPhoneDate = "new_phonedate";
        public const string FieldNetPension = "new_netpension";
        public const string FieldNetPensionSource = "new_netpensionsource";
        public const string FieldNetPensionDate = "new_netpensiondate";
        public const string FieldValueSegment = "new_valuesegment";
        public const string FieldTelephone1 = "telephone1";
        public const string FieldTelephone2 = "telephone2";
        public const string FieldMobilePhone = "mobilephone";
        public const string FieldEmailDocumented = "new_emaildocumented";
        public const string FieldEmailLastApproved = "new_emaillastapproved";
        
        //CsvHelper related
        public string CsvOrganizationUnitNumber { get; set; }
        
        [AttributeLogicalName(FieldFfKey)]
        public string FfKey
        {
            get => Get<string>();
            set => Set(value);
        }

        [AttributeLogicalName(FieldCprNumber)]
        public string CprNumber
        {
            get => Get<string>();
            set => Set(value);
        }

        [AttributeLogicalName(FieldUnformattedCprNumber)]
        public string UnformattedCprNumber
        {
            get => Get<string>();
            set => Set(value);
        }

        [AttributeLogicalName(FieldFirstName)]
        public string FirstName
        {
            get => Get<string>();
            set => Set(value);
        }

        [AttributeLogicalName(FieldLastName)]
        public string LastName
        {
            get => Get<string>();
            set => Set(value);
        }

        [AttributeLogicalName(FieldFirstAndLastName)]
        public string FirstAndLastName
        {
            get => Get<string>();
            set => Set(value);
        }

        [AttributeLogicalName(FieldJobTitle)]
        public string JobTitle
        {
            get => Get<string>();
            set => Set(value);
        }

        [AttributeLogicalName(FieldAddress1Line1)]
        public string Address1Line1
        {
            get => Get<string>();
            set => Set(value);
        }

        [AttributeLogicalName(FieldAddress1PostalCode)]
        public string Address1PostalCode
        {
            get => Get<string>();
            set => Set(value);
        }

        [AttributeLogicalName(FieldAddress1City)]
        public string Address1City
        {
            get => Get<string>();
            set => Set(value);
        }

        [AttributeLogicalName(FieldAddress1Country)]
        public string Address1Country
        {
            get => Get<string>();
            set => Set(value);
        }

        [AttributeLogicalName(FieldAddressTypeCode)]
        public OptionSetValue AddressTypeCode
        {
            get => Get<OptionSetValue>();
            set => Set(value);
        }

        [AttributeLogicalName(FieldFloor)]
        public string Floor
        {
            get => Get<string>();
            set => Set(value);
        }

        [AttributeLogicalName(FieldDoor)]
        public string Door
        {
            get => Get<string>();
            set => Set(value);
        }

        [AttributeLogicalName(FieldPlace)]
        public string Place
        {
            get => Get<string>();
            set => Set(value);
        }

        [AttributeLogicalName(FieldAddressProtected)]
        public bool? AddressProtected
        {
            get => Get<bool?>();
            set => Set(value);
        }

        [AttributeLogicalName(FieldEmailReflection)]
        public bool? EmailReflection
        {
            get => Get<bool?>();
            set => Set(value);
        }

        [AttributeLogicalName(FieldCoName)]
        public string CoName
        {
            get => Get<string>();
            set => Set(value);
        }

        [AttributeLogicalName(FieldFfKeyN16)]
        public string FfKeyN16
        {
            get => Get<string>();
            set => Set(value);
        }

        [AttributeLogicalName(FieldEmailReflectionValidationNOk)]
        public bool? EmailReflectionValidationNOk
        {
            get => Get<bool?>();
            set => Set(value);
        }

        [AttributeLogicalName(FieldDoNotBulkEmail)]
        public bool? DoNotBulkEmail
        {
            get => Get<bool?>();
            set => Set(value);
        }

        [AttributeLogicalName(FieldDoNotSendMm)]
        public bool? DoNotSendMm
        {
            get => Get<bool?>();
            set => Set(value);
        }

        [AttributeLogicalName(FieldBirthDate)]
        public DateTime? BirthDate
        {
            get => Get<DateTime?>();
            set => Set(value);
        }

        [AttributeLogicalName(FieldStaffMember)]
        public EntityReference StaffMember
        {
            get => Get<EntityReference>();
            set => Set(value);
        }

        [AttributeLogicalName(FieldOrganizationalUnit)]
        public EntityReference OrganizationalUnit
        {
            get => Get<EntityReference>();
            set => Set(value);
        }

        [AttributeLogicalName(FieldSegmentation)]
        public EntityReference Segmentation
        {
            get => Get<EntityReference>();
            set => Set(value);
        }

        [AttributeLogicalName(FieldPalFritaget)]
        public bool? PalFritaget
        {
            get => Get<bool?>();
            set => Set(value);
        }

        [AttributeLogicalName(FieldFamilyStatusCode)]
        public OptionSetValue FamilyStatusCode
        {
            get => Get<OptionSetValue>();
            set => Set(value);
        }

        [AttributeLogicalName(FieldEmailDate)]
        public DateTime? EmailDate
        {
            get => Get<DateTime?>();
            set => Set(value);
        }

        [AttributeLogicalName(FieldEmailSource)]
        public OptionSetValue EmailSource
        {
            get => Get<OptionSetValue>();
            set => Set(value);
        }

        [AttributeLogicalName(FieldEmailMarketingDate)]
        public DateTime? EmailMarketingDate
        {
            get => Get<DateTime?>();
            set => Set(value);
        }

        [AttributeLogicalName(FieldEmail)]
        public string Email
        {
            get => Get<string>();
            set => Set(value);
        }

        [AttributeLogicalName(FieldEboks)]
        public bool? Eboks
        {
            get => Get<bool?>();
            set => Set(value);
        }

        [AttributeLogicalName(FieldEboksSource)]
        public OptionSetValue EboksSource
        {
            get => Get<OptionSetValue>();
            set => Set(value);
        }

        [AttributeLogicalName(FieldEboksDate)]
        public DateTime? EboksDate
        {
            get => Get<DateTime?>();
            set => Set(value);
        }

        [AttributeLogicalName(FieldPhone)]
        public string Phone
        {
            get => Get<string>();
            set => Set(value);
        }

        [AttributeLogicalName(FieldPhoneSource)]
        public OptionSetValue PhoneSource
        {
            get => Get<OptionSetValue>();
            set => Set(value);
        }

        [AttributeLogicalName(FieldPhoneDate)]
        public DateTime? PhoneDate
        {
            get => Get<DateTime?>();
            set => Set(value);
        }

        [AttributeLogicalName(FieldMobilePhone)]
        public string MobilePhone
        {
            get => Get<string>();
            set => Set(value);
        }

        [AttributeLogicalName(FieldApp)]
        public bool? App
        {
            get => Get<bool?>();
            set => Set(value);
        }

        [AttributeLogicalName(FieldAppSource)]
        public OptionSetValue AppSource
        {
            get => Get<OptionSetValue>();
            set => Set(value);
        }

        [AttributeLogicalName(FieldAppDate)]
        public DateTime? AppDate
        {
            get => Get<DateTime?>();
            set => Set(value);
        }

        [AttributeLogicalName(FieldLetter)]
        public bool? Letter
        {
            get => Get<bool?>();
            set => Set(value);
        }

        [AttributeLogicalName(FieldLetterSource)]
        public OptionSetValue LetterSource
        {
            get => Get<OptionSetValue>();
            set => Set(value);
        }

        [AttributeLogicalName(FieldLetterDate)]
        public DateTime? LetterDate
        {
            get => Get<DateTime?>();
            set => Set(value);
        }

        [AttributeLogicalName(FieldSms)]
        public bool? Sms
        {
            get => Get<bool?>();
            set => Set(value);
        }

        [AttributeLogicalName(FieldSmsSource)]
        public OptionSetValue SmsSource
        {
            get => Get<OptionSetValue>();
            set => Set(value);
        }

        [AttributeLogicalName(FieldSmsDate)]
        public DateTime? SmsDate
        {
            get => Get<DateTime?>();
            set => Set(value);
        }

        [AttributeLogicalName(FieldNetPension)]
        public bool? NetPension
        {
            get => Get<bool?>();
            set => Set(value);
        }

        [AttributeLogicalName(FieldNetPensionSource)]
        public OptionSetValue NetPensionSource
        {
            get => Get<OptionSetValue>();
            set => Set(value);
        }

        [AttributeLogicalName(FieldNetPensionDate)]
        public DateTime? NetPensionDate
        {
            get => Get<DateTime?>();
            set => Set(value);
        }

        [AttributeLogicalName(FieldValueSegment)]
        public OptionSetValue ValueSegment
        {
            get => Get<OptionSetValue>();
            set => Set(value);
        }

        [AttributeLogicalName(FieldTelephone1)]
        public string Telephone1
        {
            get => Get<string>();
            set => Set(value);
        }

        [AttributeLogicalName(FieldTelephone2)]
        public string Telephone2
        {
            get => Get<string>();
            set => Set(value);
        }

        [AttributeLogicalName(FieldEmailDocumented)]
        public bool? EmailDocumented
        {
            get => Get<bool?>();
            set => Set(value);
        }
        
        [AttributeLogicalName(FieldEmailLastApproved)]
        public DateTime? EmailLastApproved
        {
            get => Get<DateTime?>();
            set => Set(value);
        }
    }
}