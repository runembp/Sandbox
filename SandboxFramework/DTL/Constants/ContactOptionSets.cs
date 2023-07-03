using Microsoft.Xrm.Sdk;
// ReSharper disable InconsistentNaming

namespace DTL.Constants
{
    public class ContactOptionSets
    {
        public static readonly OptionSetValue StatusCode_PersonStatus_Normal = new OptionSetValue(1);
        public static readonly OptionSetValue StatusCode_PersonStatus_Disappeared = new OptionSetValue(200001);
        public static readonly OptionSetValue StatusCode_PersonStatus_Disappearance_Cancelled = new OptionSetValue(200002);
        public static readonly OptionSetValue StatusCode_PersonStatus_Dead = new OptionSetValue(200003);
        public static readonly OptionSetValue StatusCode_PersonStatus_Dead_Cancelled = new OptionSetValue(200004);
        public static readonly OptionSetValue StatusCode_PersonStatus_Incapacitated = new OptionSetValue(200005);
        public static readonly OptionSetValue StatusCode_PersonStatus_Incapacitated_Cancelled = new OptionSetValue(200006);
        public static readonly OptionSetValue StatusCode_PersonStatus_Emigrated = new OptionSetValue(200007);
        public static readonly OptionSetValue StatusCode_PersonStatus_Entered = new OptionSetValue(200008);
    }
}