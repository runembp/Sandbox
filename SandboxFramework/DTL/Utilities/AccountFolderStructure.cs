using System.Collections.Generic;
using System.IO;

namespace DTL.Utilities
{
    public static class AccountFolderStructure
    {
        // Salg
        private const string Sales = "Salg";

        private const string Sales_AdvisoryNote = "Raadgivningsnotat";
        private const string Sales_Lømo = "LOMO";
        private const string Sales_Legi = "LEGI";

        private const string Sales_StartupAndDailyOperation = "Opstart_og_daglig_drift";
        private const string Sales_StartupAndDailyOperation_InfoMaterial = "Info-materiale";
        private const string Sales_StartupAndDailyOperation_Korrespondance = "Korrespondance";
        private const string Sales_StartupAndDailyOperation_Employees = "Medarbejdere";
        private const string Sales_StartupAndDailyOperation_Startup = "Opstart";
        private const string Sales_StartupAndDailyOperation_Health = "Sundhed";
        private const string Sales_StartupAndDailyOperation_Agreement = "Overenskomst";
        private const string Sales_StartupAndDailyOperation_StatusMeetings = "Statusmoder";

        private const string Sales_CvrSupport = "CVR-Support";
        private const string Sales_CvrSupport_Prices = "Priser";
        private const string Sales_CvrSupport_Migrated = "Migreret";
        private const string Sales_CvrSupport_Discount = "Rabat";

        private const string Sales_OfferMaterial = "Tilbudsmateriale";
        private const string Sales_OfferMaterial_Presentations = "Oplaeg_og_praesentationer";
        private const string Sales_OfferMaterial_PriceFixation = "Prisfastsaettelse_Medarbejderlister";
        private const string Sales_OfferMaterial_Korrespondance = "Korrespondance";
        private const string Sales_OfferMaterial_CoreTeam = "Core_team";
        private const string Sales_OfferMaterial_BiddingMaterial = "Udbudsmateriale_og_fuldmagt";

        private const string Sales_Migrated = "Migreret";
        private const string Sales_Migrated_HistoricalMaterial = "Historisk_materiale";
        private const string Sales_Migrated_Migrated = "Migreret";

        // Customer Service
        private const string CustomerService = "Kundeservice";
        private const string CustomerService_CaseManagement = "Sagsbehandling";
        private const string CustomerService_SupplierChange = "Leverandorskifte";
        private const string CustomerService_ContractChanges = "Kontraktaendringer";
        private const string CustomerService_SpecialCompanyInfo = "Saerlig_firma-info";
        private const string CustomerService_Subsidy = "Tilskud";

        // Dispatches from Velliv
        private const string DispatchesFromVelliv = "Udsendelser_fra_Velliv";
        private const string DispatchesFromVelliv_RiscAccounting = "Risikoregnskab";
        private const string DispatchesFromVelliv_PriceRenewal = "Prisfornyelse";
        private const string DispatchesFromVelliv_AmpLetters = "AMP_Breve";
        private const string DispatchesFromVelliv_ProductChanges = "Produktaendringer";
        private const string DispatchesFromVelliv_NewsInfo = "Nyhedsinfo";
        private const string DispatchesFromVelliv_DispatchesFromVelliv = "Udsendelser_fra_Velliv";

        // Z Drive Folder Structure
        private const string TheAgreement = "Aftalen";
        private const string Implementation = "Implementering";
        private const string ZDrive_Korrespondance = "Korrespondance";
        private const string Legi = "LEGI";

        public static void SetUpAccountFolderStructure(string accountFolderPath)
        {
            CreateFoldersForSales(accountFolderPath);
            CreateFoldersForCustomerService(accountFolderPath);
            CreateFoldersForDispatchesFromVelliv(accountFolderPath);
        }

        public static void SetUpAccountFolderStructureOnZDrive(string accountFolderPath)
        {
            CreateFoldersForZDrive(accountFolderPath);
        }

        private static void CreateFoldersForSales(string accountFolderPath)
        {
            var salesFolderPath = Path.Combine(accountFolderPath, Sales);

            var advisoryNoteFolderPath = Path.Combine(salesFolderPath, Sales_AdvisoryNote);
            var lømoFolderPath = Path.Combine(salesFolderPath, Sales_Lømo);
            var legiFolderPath = Path.Combine(salesFolderPath, Sales_Legi);

            var startupAndDailyOperationFolderPath = Path.Combine(salesFolderPath, Sales_StartupAndDailyOperation);
            var startupAndDailyOperationSubFolders = new[]
            {
                Sales_StartupAndDailyOperation_InfoMaterial,
                Sales_StartupAndDailyOperation_Korrespondance,
                Sales_StartupAndDailyOperation_Employees,
                Sales_StartupAndDailyOperation_Startup,
                Sales_StartupAndDailyOperation_Health,
                Sales_StartupAndDailyOperation_Agreement,
                Sales_StartupAndDailyOperation_StatusMeetings
            };

            var cvrSupportFolderPath = Path.Combine(salesFolderPath, Sales_CvrSupport);
            var cvrSupportSubFolders = new[]
            {
                Sales_CvrSupport_Prices,
                Sales_CvrSupport_Migrated,
                Sales_CvrSupport_Discount
            };

            var offerMaterialFolderPath = Path.Combine(salesFolderPath, Sales_OfferMaterial);
            var offerMaterialSubFolders = new[]
            {
                Sales_OfferMaterial_Presentations,
                Sales_OfferMaterial_PriceFixation,
                Sales_OfferMaterial_Korrespondance,
                Sales_OfferMaterial_CoreTeam,
                Sales_OfferMaterial_BiddingMaterial
            };

            var migratedFolderPath = Path.Combine(salesFolderPath, Sales_Migrated);
            var migratedSubFolders = new[]
            {
                Sales_Migrated_HistoricalMaterial,
                Sales_Migrated_Migrated
            };

            CreateFolderAndSubFolders(advisoryNoteFolderPath, null);
            CreateFolderAndSubFolders(lømoFolderPath, null);
            CreateFolderAndSubFolders(legiFolderPath, null);

            CreateFolderAndSubFolders(startupAndDailyOperationFolderPath, startupAndDailyOperationSubFolders);
            CreateFolderAndSubFolders(cvrSupportFolderPath, cvrSupportSubFolders);
            CreateFolderAndSubFolders(offerMaterialFolderPath, offerMaterialSubFolders);
            CreateFolderAndSubFolders(migratedFolderPath, migratedSubFolders);
        }

        private static void CreateFoldersForCustomerService(string accountFolderPath)
        {
            var customerServiceFolderPath = Path.Combine(accountFolderPath, CustomerService);
            var customerServiceSubFolders = new[]
            {
                CustomerService_CaseManagement,
                CustomerService_SupplierChange,
                CustomerService_ContractChanges,
                CustomerService_SpecialCompanyInfo,
                CustomerService_Subsidy
            };

            CreateFolderAndSubFolders(customerServiceFolderPath, customerServiceSubFolders);
        }

        private static void CreateFoldersForDispatchesFromVelliv(string accountFolderPath)
        {
            var dispatchesFromVellivFolderPath = Path.Combine(accountFolderPath, DispatchesFromVelliv);
            var dispatchesFromVellivSubFolders = new[]
            {
                DispatchesFromVelliv_RiscAccounting,
                DispatchesFromVelliv_PriceRenewal,
                DispatchesFromVelliv_AmpLetters,
                DispatchesFromVelliv_ProductChanges,
                DispatchesFromVelliv_NewsInfo,
                DispatchesFromVelliv_DispatchesFromVelliv
            };

            CreateFolderAndSubFolders(dispatchesFromVellivFolderPath, dispatchesFromVellivSubFolders);
        }

        private static void CreateFolderAndSubFolders(string primaryFolder, IEnumerable<string> subFolders)
        {
            if (!Directory.Exists(primaryFolder))
            {
                Directory.CreateDirectory(primaryFolder);
            }

            if (subFolders == null)
            {
                return;
            }

            foreach (var subFolder in subFolders)
            {
                var subFolderPath = Path.Combine(primaryFolder, subFolder);

                if (!Directory.Exists(subFolderPath))
                {
                    Directory.CreateDirectory(subFolderPath);
                }
            }
        }

        private static void CreateFoldersForZDrive(string accountZDriveFolderPath)
        {
            var zDriveSubFolders = new[]
            {
                TheAgreement,
                Implementation,
                ZDrive_Korrespondance,
                Legi
            };

            CreateFolderAndSubFolders(accountZDriveFolderPath, zDriveSubFolders);
        }
    }
}