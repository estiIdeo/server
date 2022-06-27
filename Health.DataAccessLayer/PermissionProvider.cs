using Health.Core;
using Health.Core.Framework.Account.Security;
using Health.Core.Interfaces.Providers;
using Health.Core.Types.Application;
using static Health.Core.Types.Application.DefaultPermissions;
namespace Health.DataAccessLayer
{
    public class PermissionProvider : IPermissionProvider
    {
        public IEnumerable<ApplicationPermission> GetPermissions()
        {
            return new[]
            {
                AccessAdminPanel,
                AccessPlatformSettings, EditPlatformSettings,
                AccessPlatformReporting,
                AccessUsers, EditUsers, CreateUsers, DeleteUsers,
                AccessPlatformMaintenance,
                AccessLocalizationManagment,
                AccessAgencies, CreateAgencies, EditAgencies, DeleteAgencies,
                AccessPlatformCommunications,
                AccessPlatformCarModelConfiguration, EditPlatformCarModelConfiguration, CreatePlatformCarModelConfiguration, DeletePlatformCarModelConfiguration,
                AccessAgencyFleet, EditAgencyFleet, CreateAgencyFleet, DeleteAgencyFleet,
                AccessAgencyFleetServices, EditAgencyFleetServices, CreateAgencyFleetServices, DeleteAgencyFleetServices,
                AccessAgencyFleetParkings, EditAgencyFleetParkings, CreateAgencyFleetParkings, DeleteAgencyFleetParkings,
                AccessAgencyFleetSegments, EditAgencyFleetSegments, CreateAgencyFleetSegments, DeleteAgencyFleetSegments,
                AccessAgencyFleetInventories, EditAgencyFleetInventories, CreateAgencyFleetInventories, DeleteAgencyFleetInventories,
                AccessAgencyVehicleOnBoarding,
                AccessAgencyVehicles, EditAgencyVehicles, CreateAgencyVehicles, DeleteAgencyVehicles,
                AccessVehicleMediaItems, EditVehicleMediaItems, CreateVehicleMediaItems, DeleteVehicleMediaItems,
                AccessVehicleDamages, EditVehicleDamages, CreateVehicleDamages, DeleteVehicleDamages,
                AccessVehicleAccidents,EditVehicleAccidents,CreateVehicleAccidents,DeleteVehicleAccidents,
                AccessLocalization, EditLocalization,CreateLocalization, DeleteLocalization,
                AccessSettings, EditSettings, CreateSettings, DeleteSettings,
                AccessRoles, EditRoles, CreateRoles, DeleteRoles,
                AccessAlerts, EditAlerts, CreateAlerts, DeleteAlerts,
                AccessTags, EditTags, CreateTags, DeleteTags,
                AccessBookings,EditBookings,CreateBookings,DeleteBookings,
                AccessInvoices,EditInvoices,CreateInvoices,DeleteInvoices,
                AccessCarActionsLog,
                SendActionToAgencyCar,
                AccessAgencyBankAccount,CreateAgencyBankAccount,EditAgencyBankAccount,DeleteAgencyBankAccount,
                AccessAgencyContacts,CreateAgencyContacts,EditAgencyContacts,DeleteAgencyContacts,
                AccessAgencyUsers,CreateAgencyUsers,EditAgencyUsers,DeleteAgencyUsers,
                AccessPaymentPlans,CreatePaymentPlans,EditPaymentPlans,DeletePaymentPlans,
                AccessAgencyB2BSubsriptions, CreateAgencyB2BSubsriptions, EditAgencyB2BSubsriptions, DeleteAgencyB2BSubsriptions,
                AccessAgencyB2CSubsriptions, CreateAgencyB2CSubsriptions, EditAgencyB2CSubsriptions, DeleteAgencyB2CSubsriptions,
                AccessAgencyAncillaries, CreateAgencyAncillaries, EditAgencyAncillaries, DeleteAgencyAncillaries,
                AccessAgencyAncillaryGroups, CreateAgencyAncillaryGroups, EditAgencyAncillaryGroups, DeleteAgencyAncillaryGroups,
                AccessAgencyDiscounts, CreateAgencyDiscounts, EditAgencyDiscounts, DeleteAgencyDiscounts,
                AccessAgencyCharges, CreateAgencyCharges, EditAgencyCharges, DeleteAgencyCharges,
                AccessAgencyPrices,CreateAgencyPrices,EditAgencyPrices,DeleteAgencyPrices,
                AccessAgencyPriceCars,CreateAgencyPriceCars,EditAgencyPriceCars,DeleteAgencyPriceCars,
                AccessVehicleClassTypes,CreateVehicleClassTypes,EditVehicleClassTypes,DeleteVehicleClassTypes,
                AccessVehicleClassGroups,CreateVehicleClassGroups,EditVehicleClassGroups,DeleteVehicleClassGroups,
                AccessCarSynthesis,CreateCarSynthesis,EditCarSynthesis,DeleteCarSynthesis,
                AccessOrders,CreateOrders,EditOrders,DeleteOrders,
                AccessNotes,CreateNotes,EditNotes,DeleteNotes,
                AccessPaymentMethods,CreatePaymentMethods,EditPaymentMethods,DeletePaymentMethods,
                AccessCustomers, EditCustomers, CreateCustomers, DeleteCustomers,
                CustomerSubscriptionApproval,
                CustomerSubscriptionChange,
                RefundOrder,
                OrderExtraCharge,
                AccessDashboards,
                EditAgencyVehicleTags,
                EditCustomerTags,
                AssignCarZone,
                LockCustomer,
                UnlockCustomer,
                AccessLogActivities,
                ExtendOrder,
                FinalizeOrder,
                AccessCustomerAccidents,EditCustomerAccidents,CreateCustomerAccidents,DeleteCustomerAccidents,
                AccessAgencyDocumentItems,EditAgencyDocumentItems,CreateAgencyDocumentItems,DeleteAgencyDocumentItems,
                AccessCarAvailability,EditCarAvailability,CreateCarAvailability,DeleteCarAvailability,
                OrderAdditionalDrivers,
                AttachDriverToOrder,
                AccessFleetCharges,
                AccessFleetVehicles,
                CreateAgencyCoupons, AccessAgencyCoupons, EditAgencyCoupons, DeleteAgencyCoupons,
                CreateCustomerCoupons, AccessCustomerCoupons, EditCustomerCoupons, DeleteCustomerCoupons,
                AssignFleeetSubscriptions, AssignFleeetDiscounts, AssignFleeetFixedDiscounts, AssignFleeetCharges, AssignFleeetAncillaries, AssignFleeetPrices,
                AccessDynamicPrice, EditDynamicPrice, CreateDynamicPrice, DeleteDynamicPrice,
                AccessLeads, EditLeads, CreateLeads, DeleteLeads,
                AccessTemplates, EditTemplates, CreateTemplates

            };
        }

        public IEnumerable<RoleApplicationPermissionLogicModel> GetDefaultPermissions()
        {
            return new[]
            {
                new RoleApplicationPermissionLogicModel
                {
                    RoleId = 1,
                    RoleName = Constants.Configuration.Identity.Roles.Admin,
                    Permissions = GetPermissions()
                },
                new RoleApplicationPermissionLogicModel
                {
                    RoleId = 2,
                    RoleName = Constants.Configuration.Identity.Roles.PartnerAdmin,
                    Permissions = new []
                    {
                        AccessAdminPanel,
                        AccessUsers, EditUsers, CreateUsers, DeleteUsers,
                        AccessAgencies,
                        AccessAgencyFleet, EditAgencyFleet, CreateAgencyFleet, DeleteAgencyFleet,
                        AccessAgencyFleetServices, EditAgencyFleetServices, CreateAgencyFleetServices, DeleteAgencyFleetServices,
                        AccessAgencyFleetParkings, EditAgencyFleetParkings, CreateAgencyFleetParkings, DeleteAgencyFleetParkings,
                        AccessAgencyFleetSegments, EditAgencyFleetSegments, CreateAgencyFleetSegments, DeleteAgencyFleetSegments,
                        AccessAgencyFleetInventories, EditAgencyFleetInventories, CreateAgencyFleetInventories, DeleteAgencyFleetInventories,
                        AccessAgencyVehicleOnBoarding,
                        AccessAgencyVehicles, EditAgencyVehicles, CreateAgencyVehicles, DeleteAgencyVehicles,
                        AccessVehicleMediaItems, EditVehicleMediaItems, CreateVehicleMediaItems, DeleteVehicleMediaItems,
                        AccessVehicleDamages, EditVehicleDamages, CreateVehicleDamages, DeleteVehicleDamages,
                        AccessVehicleAccidents,EditVehicleAccidents,CreateVehicleAccidents,DeleteVehicleAccidents,
                        AccessSettings, EditSettings, CreateSettings, DeleteSettings,
                        AccessRoles, EditRoles, CreateRoles, DeleteRoles,
                        AccessAlerts, EditAlerts, CreateAlerts, DeleteAlerts,
                        AccessTags, EditTags, CreateTags, DeleteTags,
                        AccessBookings,EditBookings,CreateBookings,DeleteBookings,
                        AccessInvoices, EditInvoices, CreateInvoices, DeleteInvoices,
                        AccessCarActionsLog,
                        SendActionToAgencyCar,
                        AccessAgencyBankAccount,CreateAgencyBankAccount,EditAgencyBankAccount,DeleteAgencyBankAccount,
                        AccessAgencyContacts, CreateAgencyContacts,EditAgencyContacts,DeleteAgencyContacts,
                        AccessAgencyUsers,CreateAgencyUsers,EditAgencyUsers,DeleteAgencyUsers,
                        AccessPaymentPlans,DeletePaymentPlans,
                        AccessAgencyB2BSubsriptions, CreateAgencyB2BSubsriptions, EditAgencyB2BSubsriptions, DeleteAgencyB2BSubsriptions,
                        AccessAgencyB2CSubsriptions, CreateAgencyB2CSubsriptions, EditAgencyB2CSubsriptions, DeleteAgencyB2CSubsriptions,
                        AccessAgencyAncillaries, CreateAgencyAncillaries, EditAgencyAncillaries, DeleteAgencyAncillaries,
                        AccessAgencyAncillaryGroups, CreateAgencyAncillaryGroups, EditAgencyAncillaryGroups, DeleteAgencyAncillaryGroups,
                        AccessAgencyDiscounts, CreateAgencyDiscounts, EditAgencyDiscounts, DeleteAgencyDiscounts,
                        AccessAgencyCharges, CreateAgencyCharges, EditAgencyCharges, DeleteAgencyCharges,
                        AccessAgencyPrices,CreateAgencyPrices,EditAgencyPrices,DeleteAgencyPrices,
                        AccessAgencyPriceCars,CreateAgencyPriceCars,EditAgencyPriceCars,DeleteAgencyPriceCars,
                        AccessVehicleClassTypes,CreateVehicleClassTypes,EditVehicleClassTypes,DeleteVehicleClassTypes,
                        AccessVehicleClassGroups,CreateVehicleClassGroups,EditVehicleClassGroups,DeleteVehicleClassGroups,
                        AccessCarSynthesis,CreateCarSynthesis,EditCarSynthesis,DeleteCarSynthesis,
                        AccessOrders,CreateOrders,EditOrders,DeleteOrders,
                        AccessNotes,CreateNotes,EditNotes,DeleteNotes,
                        AccessPaymentMethods,CreatePaymentMethods,EditPaymentMethods,DeletePaymentMethods,
                        AccessCustomers, EditCustomers, CreateCustomers, DeleteCustomers,
                        CustomerSubscriptionApproval,
                        CustomerSubscriptionChange,
                        RefundOrder,
                        OrderExtraCharge,
                        AccessDashboards,
                        EditAgencyVehicleTags,
                        EditCustomerTags,
                        AssignCarZone,
                        LockCustomer,
                        UnlockCustomer,
                        AccessLogActivities,
                        ExtendOrder,
                        FinalizeOrder,
                        AccessCustomerAccidents,EditCustomerAccidents,CreateCustomerAccidents,DeleteCustomerAccidents,
                        AccessAgencyDocumentItems,EditAgencyDocumentItems,CreateAgencyDocumentItems,DeleteAgencyDocumentItems,
                        AccessCarAvailability,EditCarAvailability,CreateCarAvailability,DeleteCarAvailability,
                        OrderAdditionalDrivers,
                        AttachDriverToOrder,
                        AccessFleetCharges,
                        AccessFleetVehicles,
                        AssignFleeetSubscriptions, AssignFleeetDiscounts, AssignFleeetFixedDiscounts, AssignFleeetCharges, AssignFleeetAncillaries, AssignFleeetPrices,
                        AccessDynamicPrice, EditDynamicPrice, CreateDynamicPrice, DeleteDynamicPrice,
                        AccessLeads, EditLeads, CreateLeads, DeleteLeads,
                        AccessTemplates, EditTemplates, CreateTemplates

                    }
                },

                new RoleApplicationPermissionLogicModel
                {
                    RoleId = 3,
                    RoleName = Constants.Configuration.Identity.Roles.Customer,
                    Permissions = new ApplicationPermission[]
                    {
                        CreateBookings,
                        AccessUsers,
                        AccessCustomers,
                    }
                }
            };
        }



    }
}
