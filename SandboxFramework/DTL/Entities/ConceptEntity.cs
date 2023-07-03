using System.Reflection;
using Microsoft.Xrm.Sdk.Client;

namespace DTL.Entities
{
    [EntityLogicalName(EntityLogicalName)]
    public class ConceptEntity : BaseEntity
    {
        public ConceptEntity() 
        {
            LogicalName = typeof(ConceptEntity).GetCustomAttribute<EntityLogicalNameAttribute>().LogicalName;
        }
    
        public const string EntityLogicalName = "new_aftale";
        public const string EntityId = "new_aftaleid";
        public const string FieldConceptAftaleNummer = "new_conceptaftalenummerlkp";
        public const string FieldPensionSchemeParty = "new_pensionschemeparty";
    }
}