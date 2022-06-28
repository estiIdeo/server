namespace Health.Core.Types.Application
{
    public static class DefaultPermissions
    {
        #region AdminPermissions
        public static readonly ApplicationPermission AccessAdminPanel = new ApplicationPermission { Id = 1, Name = "Access admin area", SystemName = "AccessAdminPanel", Category = "Standard" };
        #endregion
        #region PlatformPermissions
        public static readonly ApplicationPermission AccessPlatformSettings = new ApplicationPermission { Id = 2, Name = "Access Platform Settings", SystemName = "AccessPlatformSettings", Category = "Platform" };
        public static readonly ApplicationPermission EditPlatformSettings = new ApplicationPermission { Id = 3, Name = "Edit Platform Settings", SystemName = "EditPlatformSettings", Category = "Platform" };
        public static readonly ApplicationPermission AccessPlatformReporting = new ApplicationPermission { Id = 4, Name = "Access Platform Reporting", SystemName = "AccessPlatformReporting", Category = "Platform" };

        public static readonly ApplicationPermission AccessUsers = new ApplicationPermission { Id = 5, Name = "Access Users", SystemName = "AccessUsers", Category = "Users" };
        public static readonly ApplicationPermission EditUsers = new ApplicationPermission { Id = 6, Name = "Edit Users", SystemName = "EditUsers", Category = "Users" };
        public static readonly ApplicationPermission CreateUsers = new ApplicationPermission { Id = 7, Name = "Create Users", SystemName = "CreateUsers", Category = "Users" };
        public static readonly ApplicationPermission DeleteUsers = new ApplicationPermission { Id = 8, Name = "Delete Users", SystemName = "DeleteUsers", Category = "Users" };

        public static readonly ApplicationPermission AccessPlatformMaintenance = new ApplicationPermission { Id = 9, Name = "Access Platform Maintenance", SystemName = "AccessPlatformMaintenance", Category = "Users" };
        public static readonly ApplicationPermission AccessLocalizationManagment = new ApplicationPermission { Id = 10, Name = "Access Localization Managment", SystemName = "AccessLocalizationManagment", Category = "Users" };

        public static readonly ApplicationPermission AccessAgencies = new ApplicationPermission { Id = 11, Name = "Access Agencies", SystemName = "AccessAgencies", Category = "Agencies" };
        public static readonly ApplicationPermission CreateAgencies = new ApplicationPermission { Id = 12, Name = "Create Agencies", SystemName = "CreateAgencies", Category = "Agencies" };
        public static readonly ApplicationPermission EditAgencies = new ApplicationPermission { Id = 13, Name = "Edit Agencies", SystemName = "EditAgencies", Category = "Agencies" };
        public static readonly ApplicationPermission DeleteAgencies = new ApplicationPermission { Id = 14, Name = "Delete Agencies", SystemName = "DeleteAgencies", Category = "Agencies" };

        public static readonly ApplicationPermission AccessPlatformCommunications = new ApplicationPermission { Id = 15, Name = "Access Platform Communications", SystemName = "AccessPlatformCommunications", Category = "Platform" };

        public static readonly ApplicationPermission AccessPlatformCarModelConfiguration = new ApplicationPermission { Id = 16, Name = "Access Platform Car Model Configuration", SystemName = "AccessPlatformCarModelConfiguration", Category = "CarModelConfiguration" };
        public static readonly ApplicationPermission EditPlatformCarModelConfiguration = new ApplicationPermission { Id = 17, Name = "Edit Platform Car Model Configuration", SystemName = "EditPlatformCarModelConfiguration", Category = "CarModelConfiguration" };
        public static readonly ApplicationPermission CreatePlatformCarModelConfiguration = new ApplicationPermission { Id = 18, Name = "Create Platform Car Model Configuration", SystemName = "CreatePlatformCarModelConfiguration", Category = "CarModelConfiguration" };
        public static readonly ApplicationPermission DeletePlatformCarModelConfiguration = new ApplicationPermission { Id = 19, Name = "Delete Platform Car Model Configuration", SystemName = "DeletePlatformCarModelConfiguration", Category = "CarModelConfiguration" };

        public static readonly ApplicationPermission AccessAgencyFleet = new ApplicationPermission { Id = 20, Name = "Access Agency Fleet", SystemName = "AccessAgencyFleet", Category = "Agencies" };
        public static readonly ApplicationPermission EditAgencyFleet = new ApplicationPermission { Id = 21, Name = "Edit Agency Fleet", SystemName = "EditAgencyFleet", Category = "Agencies" };
        public static readonly ApplicationPermission CreateAgencyFleet = new ApplicationPermission { Id = 22, Name = "Create Agency Fleet", SystemName = "CreateAgencyFleet", Category = "Agencies" };
        public static readonly ApplicationPermission DeleteAgencyFleet = new ApplicationPermission { Id = 23, Name = "Delete Agency Fleet", SystemName = "DeleteAgencyFleet", Category = "Agencies" };
        public static readonly ApplicationPermission AccessAgencyFleetServices = new ApplicationPermission { Id = 24, Name = "Access Agency Fleet Services", SystemName = "AccessAgencyFleetServices", Category = "Agencies" };
        public static readonly ApplicationPermission EditAgencyFleetServices = new ApplicationPermission { Id = 25, Name = "Edit Agency Fleet Services", SystemName = "EditAgencyFleetServices", Category = "Agencies" };
        public static readonly ApplicationPermission CreateAgencyFleetServices = new ApplicationPermission { Id = 26, Name = "Create Agency Fleet Services", SystemName = "CreateAgencyFleetServices", Category = "Agencies" };
        public static readonly ApplicationPermission DeleteAgencyFleetServices = new ApplicationPermission { Id = 27, Name = "Delete Agency Fleet Services", SystemName = "DeleteAgencyFleetServices", Category = "Agencies" };
        public static readonly ApplicationPermission AccessAgencyFleetParkings = new ApplicationPermission { Id = 28, Name = "Access Agency Fleet Parkings", SystemName = "AccessAgencyFleetParkings", Category = "Agencies" };
        public static readonly ApplicationPermission EditAgencyFleetParkings = new ApplicationPermission { Id = 29, Name = "Edit Agency Fleet Parkings", SystemName = "EditAgencyFleetParkings", Category = "Agencies" };
        public static readonly ApplicationPermission CreateAgencyFleetParkings = new ApplicationPermission { Id = 30, Name = "Create Agency Fleet Parkings", SystemName = "CreateAgencyFleetParkings", Category = "Agencies" };
        public static readonly ApplicationPermission DeleteAgencyFleetParkings = new ApplicationPermission { Id = 31, Name = "Delete Agency Fleet Parkings", SystemName = "DeleteAgencyFleetParkings", Category = "Agencies" };
        public static readonly ApplicationPermission AccessAgencyFleetSegments = new ApplicationPermission { Id = 32, Name = "Access Agency Fleet Segments", SystemName = "AccessAgencyFleetSegments", Category = "Agencies" };
        public static readonly ApplicationPermission EditAgencyFleetSegments = new ApplicationPermission { Id = 33, Name = "Edit Agency Fleet Segments", SystemName = "EditAgencyFleetSegments", Category = "Agencies" };
        public static readonly ApplicationPermission CreateAgencyFleetSegments = new ApplicationPermission { Id = 34, Name = "Create Agency Fleet Segments", SystemName = "CreateAgencyFleetSegments", Category = "Agencies" };
        public static readonly ApplicationPermission DeleteAgencyFleetSegments = new ApplicationPermission { Id = 35, Name = "Delete Agency Fleet Segments", SystemName = "DeleteAgencyFleetSegments", Category = "Agencies" };
        public static readonly ApplicationPermission AccessAgencyFleetInventories = new ApplicationPermission { Id = 36, Name = "Access Agency Fleet Inventories", SystemName = "AccessAgencyFleetInventories", Category = "Agencies" };
        public static readonly ApplicationPermission EditAgencyFleetInventories = new ApplicationPermission { Id = 37, Name = "Edit Agency Fleet Inventories", SystemName = "EditAgencyFleetInventories", Category = "Agencies" };
        public static readonly ApplicationPermission CreateAgencyFleetInventories = new ApplicationPermission { Id = 38, Name = "Create Agency Fleet Inventories", SystemName = "CreateAgencyFleetInventories", Category = "Agencies" };
        public static readonly ApplicationPermission DeleteAgencyFleetInventories = new ApplicationPermission { Id = 39, Name = "Delete Agency Fleet Inventories", SystemName = "DeleteAgencyFleetInventories", Category = "Agencies" };

        public static readonly ApplicationPermission AccessAgencyVehicleOnBoarding = new ApplicationPermission { Id = 40, Name = "Access Agency Vehicle OnBoarding", SystemName = "AccessAgencyVehicleOnBoarding", Category = "Agencies" };
        public static readonly ApplicationPermission AccessAgencyVehicles = new ApplicationPermission { Id = 41, Name = "Access Agency Vehicles", SystemName = "AccessAgencyVehicles", Category = "Vehicles" };
        public static readonly ApplicationPermission EditAgencyVehicles = new ApplicationPermission { Id = 42, Name = "Edit Agency Vehicles", SystemName = "EditAgencyVehicles", Category = "Vehicles" };
        public static readonly ApplicationPermission CreateAgencyVehicles = new ApplicationPermission { Id = 43, Name = "Create Agency Vehicles", SystemName = "CreateAgencyVehicles", Category = "Vehicles" };
        public static readonly ApplicationPermission DeleteAgencyVehicles = new ApplicationPermission { Id = 44, Name = "Delete Agency Vehicles", SystemName = "DeleteAgencyVehicles", Category = "Vehicles" };

        public static readonly ApplicationPermission AccessLocalization = new ApplicationPermission { Id = 45, Name = "Access Localization", SystemName = "AccessLocalization", Category = "Localization" };
        public static readonly ApplicationPermission EditLocalization = new ApplicationPermission { Id = 46, Name = "Edit Localization", SystemName = "EditLocalization", Category = "Localization" };
        public static readonly ApplicationPermission CreateLocalization = new ApplicationPermission { Id = 47, Name = "Create Localization", SystemName = "CreateLocalization", Category = "Localization" };
        public static readonly ApplicationPermission DeleteLocalization = new ApplicationPermission { Id = 48, Name = "Delete Localization", SystemName = "DeleteLocalization", Category = "Localization" };

        public static readonly ApplicationPermission AccessSettings = new ApplicationPermission { Id = 49, Name = "Access Settings", SystemName = "AccessSettings", Category = "Configuration" };
        public static readonly ApplicationPermission EditSettings = new ApplicationPermission { Id = 50, Name = "Edit Settings", SystemName = "EditSettings", Category = "Configuration" };
        public static readonly ApplicationPermission CreateSettings = new ApplicationPermission { Id = 51, Name = "Create Settings", SystemName = "CreateSettings", Category = "Configuration" };
        public static readonly ApplicationPermission DeleteSettings = new ApplicationPermission { Id = 52, Name = "Delete Settings", SystemName = "DeleteSettings", Category = "Configuration" };

        public static readonly ApplicationPermission AccessRoles = new ApplicationPermission { Id = 53, Name = "Access Roles", SystemName = "AccessRoles", Category = "Configuration" };
        public static readonly ApplicationPermission EditRoles = new ApplicationPermission { Id = 54, Name = "Edit Roles", SystemName = "EditRoles", Category = "Configuration" };
        public static readonly ApplicationPermission CreateRoles = new ApplicationPermission { Id = 55, Name = "Create Roles", SystemName = "CreateRoles", Category = "Configuration" };
        public static readonly ApplicationPermission DeleteRoles = new ApplicationPermission { Id = 56, Name = "Delete Roles", SystemName = "DeleteRoles", Category = "Configuration" };

        public static readonly ApplicationPermission AccessAlerts = new ApplicationPermission { Id = 57, Name = "Access Alerts", SystemName = "AccessAlerts", Category = "Platform" };
        public static readonly ApplicationPermission EditAlerts = new ApplicationPermission { Id = 58, Name = "Edit Alerts", SystemName = "EditAlerts", Category = "Platform" };
        public static readonly ApplicationPermission CreateAlerts = new ApplicationPermission { Id = 59, Name = "Create Alerts", SystemName = "CreateAlerts", Category = "Platform" };
        public static readonly ApplicationPermission DeleteAlerts = new ApplicationPermission { Id = 60, Name = "Delete Alerts", SystemName = "DeleteAlerts", Category = "Platform" };

        public static readonly ApplicationPermission AccessTags = new ApplicationPermission { Id = 61, Name = "Access Tags", SystemName = "AccessTags", Category = "Platform" };
        public static readonly ApplicationPermission EditTags = new ApplicationPermission { Id = 62, Name = "Edit Tags", SystemName = "EditTags", Category = "Platform" };
        public static readonly ApplicationPermission CreateTags = new ApplicationPermission { Id = 63, Name = "Create Tags", SystemName = "CreateTags", Category = "Platform" };
        public static readonly ApplicationPermission DeleteTags = new ApplicationPermission { Id = 64, Name = "Delete Tags", SystemName = "DeleteTags", Category = "Platform" };

        public static readonly ApplicationPermission AccessBookings = new ApplicationPermission { Id = 65, Name = "Access Bookings", SystemName = "AccessBookings", Category = "Platform" };
        public static readonly ApplicationPermission EditBookings = new ApplicationPermission { Id = 66, Name = "Edit Bookings", SystemName = "EditBookings", Category = "Platform" };
        public static readonly ApplicationPermission CreateBookings = new ApplicationPermission { Id = 67, Name = "Create Bookings", SystemName = "CreateBookings", Category = "Platform" };
        public static readonly ApplicationPermission DeleteBookings = new ApplicationPermission { Id = 68, Name = "Delete Bookings", SystemName = "DeleteBookings", Category = "Platform" };

        public static readonly ApplicationPermission AccessInvoices = new ApplicationPermission { Id = 73, Name = "Access Invoices", SystemName = "AccessInvoices", Category = "Platform" };
        public static readonly ApplicationPermission EditInvoices = new ApplicationPermission { Id = 74, Name = "Edit Invoices", SystemName = "EditInvoices", Category = "Platform" };
        public static readonly ApplicationPermission CreateInvoices = new ApplicationPermission { Id = 75, Name = "Create Invoices", SystemName = "CreateInvoices", Category = "Platform" };
        public static readonly ApplicationPermission DeleteInvoices = new ApplicationPermission { Id = 76, Name = "Delete Invoices", SystemName = "DeleteInvoices", Category = "Platform" };

        public static readonly ApplicationPermission AccessCarActionsLog = new ApplicationPermission { Id = 77, Name = "Access Car Actions Log", SystemName = "AccessCarActionsLog", Category = "Vehicles" };

        public static readonly ApplicationPermission SendActionToAgencyCar = new ApplicationPermission { Id = 78, Name = "Send Action To Agency Car", SystemName = "SendActionToAgencyCar", Category = "Vehicles" };

        public static readonly ApplicationPermission AccessAgencyBankAccount = new ApplicationPermission { Id = 79, Name = "Access Agency Bank Account", SystemName = "AccessAgencyBankAccount", Category = "Agencies" };
        public static readonly ApplicationPermission EditAgencyBankAccount = new ApplicationPermission { Id = 80, Name = "Edit Agency Bank Account", SystemName = "EditAgencyBankAccount", Category = "Agencies" };
        public static readonly ApplicationPermission CreateAgencyBankAccount = new ApplicationPermission { Id = 81, Name = "Create Agency Bank Account", SystemName = "CreateAgencyBankAccount", Category = "Agencies" };
        public static readonly ApplicationPermission DeleteAgencyBankAccount = new ApplicationPermission { Id = 82, Name = "Delete Agency Bank Account", SystemName = "DeleteAgencyBankAccount", Category = "Agencies" };

        public static readonly ApplicationPermission AccessAgencyContacts = new ApplicationPermission { Id = 83, Name = "Access Agency Contacts", SystemName = "AccessAgencyContacts", Category = "Agencies" };
        public static readonly ApplicationPermission EditAgencyContacts = new ApplicationPermission { Id = 84, Name = "Edit Agency Contacts", SystemName = "EditAgencyContacts", Category = "Agencies" };
        public static readonly ApplicationPermission CreateAgencyContacts = new ApplicationPermission { Id = 85, Name = "Create Agency Contacts", SystemName = "CreateAgencyContacts", Category = "Agencies" };
        public static readonly ApplicationPermission DeleteAgencyContacts = new ApplicationPermission { Id = 86, Name = "Delete Agency Contacts", SystemName = "DeleteAgencyContacts", Category = "Agencies" };

        public static readonly ApplicationPermission AccessAgencyUsers = new ApplicationPermission { Id = 87, Name = "Access Agency Users", SystemName = "AccessAgencyUsers", Category = "Agencies" };
        public static readonly ApplicationPermission EditAgencyUsers = new ApplicationPermission { Id = 88, Name = "Edit Agency Userss", SystemName = "EditAgencyUsers", Category = "Agencies" };
        public static readonly ApplicationPermission CreateAgencyUsers = new ApplicationPermission { Id = 89, Name = "Create Agency Users", SystemName = "CreateAgencyUsers", Category = "Agencies" };
        public static readonly ApplicationPermission DeleteAgencyUsers = new ApplicationPermission { Id = 90, Name = "Delete Agency Users", SystemName = "DeleteAgencyUsers", Category = "Agencies" };

        public static readonly ApplicationPermission AccessPaymentPlans = new ApplicationPermission { Id = 91, Name = "Access Payment Plans", SystemName = "AccessPaymentPlans", Category = "Platform" };
        public static readonly ApplicationPermission EditPaymentPlans = new ApplicationPermission { Id = 92, Name = "Edit Payment Plans", SystemName = "EditPaymentPlans", Category = "Platform" };
        public static readonly ApplicationPermission CreatePaymentPlans = new ApplicationPermission { Id = 93, Name = "Create Payment Plans", SystemName = "CreatePaymentPlans", Category = "Platform" };
        public static readonly ApplicationPermission DeletePaymentPlans = new ApplicationPermission { Id = 94, Name = "Delete Payment Plans", SystemName = "DeletePaymentPlans", Category = "Platform" };

        public static readonly ApplicationPermission AccessAgencyB2BSubsriptions = new ApplicationPermission { Id = 95, Name = "Access Agency B2B Subsriptions", SystemName = "AccessAgencyB2BSubsriptions", Category = "Agencies" };
        public static readonly ApplicationPermission EditAgencyB2BSubsriptions = new ApplicationPermission { Id = 96, Name = "Edit Agency B2B Subsriptions", SystemName = "EditAgencyB2BSubsriptions", Category = "Agencies" };
        public static readonly ApplicationPermission CreateAgencyB2BSubsriptions = new ApplicationPermission { Id = 97, Name = "Create Agency B2B Subsriptions", SystemName = "CreateAgencyB2BSubsriptions", Category = "Agencies" };
        public static readonly ApplicationPermission DeleteAgencyB2BSubsriptions = new ApplicationPermission { Id = 98, Name = "Delete Agency B2B Subsriptions", SystemName = "DeleteAgencyB2BSubsriptions", Category = "Agencies" };

        public static readonly ApplicationPermission AccessAgencyB2CSubsriptions = new ApplicationPermission { Id = 99, Name = "Access Agency B2C Subsriptions", SystemName = "AccessAgencyB2CSubsriptions", Category = "Agencies" };
        public static readonly ApplicationPermission EditAgencyB2CSubsriptions = new ApplicationPermission { Id = 100, Name = "Edit Agency B2C Subsriptions", SystemName = "EditAgencyB2CSubsriptions", Category = "Agencies" };
        public static readonly ApplicationPermission CreateAgencyB2CSubsriptions = new ApplicationPermission { Id = 101, Name = "Create Agency B2C Subsriptions", SystemName = "CreateAgencyB2CSubsriptions", Category = "Agencies" };
        public static readonly ApplicationPermission DeleteAgencyB2CSubsriptions = new ApplicationPermission { Id = 102, Name = "Delete Agency B2C Subsriptions", SystemName = "DeleteAgencyB2CSubsriptions", Category = "Agencies" };

        public static readonly ApplicationPermission AccessAgencyAncillaries = new ApplicationPermission { Id = 103, Name = "Access Agency Ancillaries", SystemName = "AccessAgencyAncillaries", Category = "Agencies" };
        public static readonly ApplicationPermission EditAgencyAncillaries = new ApplicationPermission { Id = 104, Name = "Edit Agency Ancillaries", SystemName = "EditAgencyAncillaries", Category = "Agencies" };
        public static readonly ApplicationPermission CreateAgencyAncillaries = new ApplicationPermission { Id = 105, Name = "Create Agency Ancillaries", SystemName = "CreateAgencyAncillaries", Category = "Agencies" };
        public static readonly ApplicationPermission DeleteAgencyAncillaries = new ApplicationPermission { Id = 106, Name = "Delete Agency Ancillaries", SystemName = "DeleteAgencyAncillaries", Category = "Agencies" };

        public static readonly ApplicationPermission AccessAgencyAncillaryGroups = new ApplicationPermission { Id = 107, Name = "Access Agency Ancillary Groups", SystemName = "AccessAgencyAncillaryGroups", Category = "Agencies" };
        public static readonly ApplicationPermission EditAgencyAncillaryGroups = new ApplicationPermission { Id = 108, Name = "Edit Agency Ancillary Groups", SystemName = "EditAgencyAncillaryGroups", Category = "Agencies" };
        public static readonly ApplicationPermission CreateAgencyAncillaryGroups = new ApplicationPermission { Id = 109, Name = "Create Agency Ancillary Groups", SystemName = "CreateAgencyAncillaryGroups", Category = "Agencies" };
        public static readonly ApplicationPermission DeleteAgencyAncillaryGroups = new ApplicationPermission { Id = 110, Name = "Delete Agency Ancillary Groups", SystemName = "DeleteAgencyAncillaryGroups", Category = "Agencies" };

        public static readonly ApplicationPermission AccessAgencyDiscounts = new ApplicationPermission { Id = 111, Name = "Access Agency Discounts", SystemName = "AccessAgencyDiscounts", Category = "Agencies" };
        public static readonly ApplicationPermission EditAgencyDiscounts = new ApplicationPermission { Id = 112, Name = "Edit Agency Discounts", SystemName = "EditAgencyDiscounts", Category = "Agencies" };
        public static readonly ApplicationPermission CreateAgencyDiscounts = new ApplicationPermission { Id = 113, Name = "Create Agency Discounts", SystemName = "CreateAgencyDiscounts", Category = "Agencies" };
        public static readonly ApplicationPermission DeleteAgencyDiscounts = new ApplicationPermission { Id = 114, Name = "Delete Agency Discounts", SystemName = "DeleteAgencyDiscounts", Category = "Agencies" };

        public static readonly ApplicationPermission AccessAgencyCharges = new ApplicationPermission { Id = 115, Name = "Access Agency Charges", SystemName = "AccessAgencyCharges", Category = "Agencies" };
        public static readonly ApplicationPermission EditAgencyCharges = new ApplicationPermission { Id = 116, Name = "Edit Agency Charges", SystemName = "EditAgencyCharges", Category = "Agencies" };
        public static readonly ApplicationPermission DeleteAgencyCharges = new ApplicationPermission { Id = 117, Name = "Delete Agency Charges", SystemName = "DeleteAgencyCharges", Category = "Agencies" };
        public static readonly ApplicationPermission CreateAgencyCharges = new ApplicationPermission { Id = 210, Name = "Create Agency Charges", SystemName = "CreateAgencyCharges", Category = "Agencies" };

        public static readonly ApplicationPermission CreateAgencyCoupons = new ApplicationPermission { Id = 200, Name = "Create Agency Coupon", SystemName = "CreateAgencyCoupons", Category = "Agencies" };
        public static readonly ApplicationPermission AccessAgencyCoupons = new ApplicationPermission { Id = 201, Name = "Access Agency Coupon", SystemName = "AccessAgencyCoupons", Category = "Agencies" };
        public static readonly ApplicationPermission EditAgencyCoupons = new ApplicationPermission { Id = 202, Name = "Edit Agency Coupon", SystemName = "EditAgencyCoupons", Category = "Agencies" };
        public static readonly ApplicationPermission DeleteAgencyCoupons = new ApplicationPermission { Id = 203, Name = "Delete Agency Coupon", SystemName = "DeleteAgencyCoupons", Category = "Agencies" };


        public static readonly ApplicationPermission AccessVehicleDamages = new ApplicationPermission { Id = 118, Name = "Access Vehicle Damages", SystemName = "AccessVehicleDamages", Category = "Vehicles" };
        public static readonly ApplicationPermission EditVehicleDamages = new ApplicationPermission { Id = 119, Name = "Edit Vehicle Damages", SystemName = "EditVehicleDamages", Category = "Vehicles" };
        public static readonly ApplicationPermission CreateVehicleDamages = new ApplicationPermission { Id = 120, Name = "Create Vehicle Damages", SystemName = "CreateVehicleDamages", Category = "Vehicles" };
        public static readonly ApplicationPermission DeleteVehicleDamages = new ApplicationPermission { Id = 121, Name = "Delete Vehicle Damages", SystemName = "DeleteVehicleDamages", Category = "Vehicles" };

        public static readonly ApplicationPermission AccessVehicleAccidents = new ApplicationPermission { Id = 122, Name = "Access Vehicle Accidents", SystemName = "AccessVehicleAccidents", Category = "Vehicles" };
        public static readonly ApplicationPermission EditVehicleAccidents = new ApplicationPermission { Id = 123, Name = "Edit Vehicle Accidents", SystemName = "EditVehicleAccidents", Category = "Vehicles" };
        public static readonly ApplicationPermission CreateVehicleAccidents = new ApplicationPermission { Id = 124, Name = "Create Vehicle Accidents", SystemName = "CreateVehicleAccidents", Category = "Vehicles" };
        public static readonly ApplicationPermission DeleteVehicleAccidents = new ApplicationPermission { Id = 125, Name = "Delete Vehicle Accidents", SystemName = "DeleteVehicleAccidents", Category = "Vehicles" };

        public static readonly ApplicationPermission AccessAgencyPrices = new ApplicationPermission { Id = 126, Name = "Access Agency Prices", SystemName = "AccessAgencyPrices", Category = "Agencies" };
        public static readonly ApplicationPermission EditAgencyPrices = new ApplicationPermission { Id = 127, Name = "Edit Agency Prices", SystemName = "EditAgencyPrices", Category = "Agencies" };
        public static readonly ApplicationPermission CreateAgencyPrices = new ApplicationPermission { Id = 128, Name = "Create Agency Prices", SystemName = "CreateAgencyPrices", Category = "Agencies" };
        public static readonly ApplicationPermission DeleteAgencyPrices = new ApplicationPermission { Id = 129, Name = "Delete Agency Prices", SystemName = "DeleteAgencyPrices", Category = "Agencies" };

        public static readonly ApplicationPermission AccessAgencyPriceCars = new ApplicationPermission { Id = 130, Name = "Access Agency Price Cars", SystemName = "AccessAgencyPriceCars", Category = "Agencies" };
        public static readonly ApplicationPermission EditAgencyPriceCars = new ApplicationPermission { Id = 131, Name = "Edit Agency Price Cars", SystemName = "EditAgencyPriceCars", Category = "Agencies" };
        public static readonly ApplicationPermission CreateAgencyPriceCars = new ApplicationPermission { Id = 132, Name = "Create Agency Price Cars", SystemName = "CreateAgencyPriceCars", Category = "Agencies" };
        public static readonly ApplicationPermission DeleteAgencyPriceCars = new ApplicationPermission { Id = 133, Name = "Delete Agency Price Cars", SystemName = "DeleteAgencyPriceCars", Category = "Agencies" };

        public static readonly ApplicationPermission AccessVehicleClassTypes = new ApplicationPermission { Id = 134, Name = "Access Vehicle Class Types", SystemName = "AccessVehicleClassTypes", Category = "Agencies" };
        public static readonly ApplicationPermission EditVehicleClassTypes = new ApplicationPermission { Id = 135, Name = "Edit Vehicle Class Types", SystemName = "EditVehicleClassTypes", Category = "Agencies" };
        public static readonly ApplicationPermission CreateVehicleClassTypes = new ApplicationPermission { Id = 136, Name = "Create Vehicle Class Types", SystemName = "CreateVehicleClassTypes", Category = "Agencies" };
        public static readonly ApplicationPermission DeleteVehicleClassTypes = new ApplicationPermission { Id = 137, Name = "Delete Vehicle Class Types", SystemName = "DeleteVehicleClassTypes", Category = "Agencies" };

        public static readonly ApplicationPermission AccessVehicleClassGroups = new ApplicationPermission { Id = 138, Name = "Access Vehicle Class Groups", SystemName = "AccessVehicleClassGroups", Category = "Agencies" };
        public static readonly ApplicationPermission EditVehicleClassGroups = new ApplicationPermission { Id = 139, Name = "Edit Vehicle Class Groups", SystemName = "EditVehicleClassGroups", Category = "Agencies" };
        public static readonly ApplicationPermission CreateVehicleClassGroups = new ApplicationPermission { Id = 140, Name = "Create Vehicle Class Groups", SystemName = "CreateVehicleClassGroups", Category = "Agencies" };
        public static readonly ApplicationPermission DeleteVehicleClassGroups = new ApplicationPermission { Id = 141, Name = "Delete Vehicle Class Groups", SystemName = "DeleteVehicleClassGroups", Category = "Agencies" };

        public static readonly ApplicationPermission AccessCarSynthesis = new ApplicationPermission { Id = 142, Name = "Access Car Synthesis", SystemName = "AccessCarSynthesis", Category = "Vehicles" };
        public static readonly ApplicationPermission EditCarSynthesis = new ApplicationPermission { Id = 143, Name = "Edit Car Synthesis", SystemName = "EditCarSynthesis", Category = "Vehicles" };
        public static readonly ApplicationPermission CreateCarSynthesis = new ApplicationPermission { Id = 144, Name = "Create Car Synthesiss", SystemName = "CreateCarSynthesis", Category = "Vehicles" };
        public static readonly ApplicationPermission DeleteCarSynthesis = new ApplicationPermission { Id = 145, Name = "Delete Car Synthesis", SystemName = "DeleteCarSynthesis", Category = "Vehicles" };

        public static readonly ApplicationPermission AccessOrders = new ApplicationPermission { Id = 146, Name = "Access Orders", SystemName = "AccessOrders", Category = "Platform" };
        public static readonly ApplicationPermission EditOrders = new ApplicationPermission { Id = 147, Name = "Edit Orders", SystemName = "EditOrders", Category = "Platform" };
        public static readonly ApplicationPermission CreateOrders = new ApplicationPermission { Id = 148, Name = "Create Orders", SystemName = "CreateOrders", Category = "Platform" };
        public static readonly ApplicationPermission DeleteOrders = new ApplicationPermission { Id = 149, Name = "Delete Orders", SystemName = "DeleteOrders", Category = "Platform" };

        public static readonly ApplicationPermission AccessNotes = new ApplicationPermission { Id = 150, Name = "Access Notes", SystemName = "AccessNotes", Category = "Platform" };
        public static readonly ApplicationPermission EditNotes = new ApplicationPermission { Id = 151, Name = "Edit Notes", SystemName = "EditNotes", Category = "Platform" };
        public static readonly ApplicationPermission CreateNotes = new ApplicationPermission { Id = 152, Name = "Create Notes", SystemName = "CreateNotes", Category = "Platform" };
        public static readonly ApplicationPermission DeleteNotes = new ApplicationPermission { Id = 153, Name = "Delete Notes", SystemName = "DeleteNotes", Category = "Platform" };

        public static readonly ApplicationPermission AccessPaymentMethods = new ApplicationPermission { Id = 154, Name = "Access Payment Methods", SystemName = "AccessPaymentMethods", Category = "Customers" };
        public static readonly ApplicationPermission EditPaymentMethods = new ApplicationPermission { Id = 155, Name = "Edit Payment Methods", SystemName = "EditPaymentMethods", Category = "Customers" };
        public static readonly ApplicationPermission CreatePaymentMethods = new ApplicationPermission { Id = 156, Name = "Create Payment Methods", SystemName = "CreatePaymentMethods", Category = "Customers" };
        public static readonly ApplicationPermission DeletePaymentMethods = new ApplicationPermission { Id = 157, Name = "Delete Payment Methods", SystemName = "DeletePaymentMethods", Category = "Customers" };

        public static readonly ApplicationPermission AccessCustomers = new ApplicationPermission { Id = 158, Name = "Access Customers", SystemName = "AccessCustomers", Category = "Customers" };
        public static readonly ApplicationPermission EditCustomers = new ApplicationPermission { Id = 159, Name = "Edit Customerss", SystemName = "EditCustomers", Category = "Customers" };
        public static readonly ApplicationPermission CreateCustomers = new ApplicationPermission { Id = 160, Name = "Create Customers", SystemName = "CreateCustomers", Category = "Customers" };
        public static readonly ApplicationPermission DeleteCustomers = new ApplicationPermission { Id = 161, Name = "Delete Customers", SystemName = "DeleteCustomers", Category = "Customers" };

        public static readonly ApplicationPermission CustomerSubscriptionApproval = new ApplicationPermission { Id = 162, Name = "Customer Subscription Approval", SystemName = "CustomerSubscriptionApproval", Category = "Customers" };
        public static readonly ApplicationPermission CustomerSubscriptionChange = new ApplicationPermission { Id = 163, Name = "Customer Subscription Change", SystemName = "CustomerSubscriptionChange", Category = "Customers" };

        public static readonly ApplicationPermission RefundOrder = new ApplicationPermission { Id = 164, Name = "Refund Order", SystemName = "RefundOrder", Category = "Platform" };
        public static readonly ApplicationPermission OrderExtraCharge = new ApplicationPermission { Id = 165, Name = "Order Extra Charge", SystemName = "OrderExtraCharge", Category = "Platform" };

        public static readonly ApplicationPermission AccessDashboards = new ApplicationPermission { Id = 167, Name = "Access Dashboards", SystemName = "AccessDashboards", Category = "Platform" };

        public static readonly ApplicationPermission EditAgencyVehicleTags = new ApplicationPermission { Id = 168, Name = "Edit Agency Vehicle Tags", SystemName = "EditAgencyVehicleTags", Category = "Vehicles" };

        public static readonly ApplicationPermission EditCustomerTags = new ApplicationPermission { Id = 169, Name = "Edit Customer Tags", SystemName = "EditCustomerTags", Category = "Customers" };

        public static readonly ApplicationPermission AccessVehicleMediaItems = new ApplicationPermission { Id = 170, Name = "Access Vehicle Media Items", SystemName = "AccessVehicleMediaItems", Category = "Vehicles" };
        public static readonly ApplicationPermission EditVehicleMediaItems = new ApplicationPermission { Id = 171, Name = "Edit Vehicle Media Items", SystemName = "EditVehicleMediaItems", Category = "Vehicles" };
        public static readonly ApplicationPermission CreateVehicleMediaItems = new ApplicationPermission { Id = 172, Name = "Create Vehicle Media Items", SystemName = "CreateVehicleMediaItems", Category = "Vehicles" };
        public static readonly ApplicationPermission DeleteVehicleMediaItems = new ApplicationPermission { Id = 173, Name = "Delete Vehicle Media Items", SystemName = "DeleteVehicleMediaItems", Category = "Vehicles" };

        public static readonly ApplicationPermission AssignCarZone = new ApplicationPermission { Id = 174, Name = "Assign Car Zone", SystemName = "AssignCarZone", Category = "Vehicles" };

        public static readonly ApplicationPermission LockCustomer = new ApplicationPermission { Id = 175, Name = "Lock Customer", SystemName = "LockCustomer", Category = "Customers" };
        public static readonly ApplicationPermission UnlockCustomer = new ApplicationPermission { Id = 176, Name = "Unlock Customer", SystemName = "UnlockCustomer", Category = "Customers" };

        public static readonly ApplicationPermission AccessLogActivities = new ApplicationPermission { Id = 177, Name = "Access Log Activities", SystemName = "AccessLogActivities", Category = "Configuration" };

        public static readonly ApplicationPermission ExtendOrder = new ApplicationPermission { Id = 178, Name = "Extend Order", SystemName = "ExtendOrder", Category = "Platform" };
        public static readonly ApplicationPermission FinalizeOrder = new ApplicationPermission { Id = 179, Name = "Finalize Order", SystemName = "FinalizeOrder", Category = "Platform" };

        public static readonly ApplicationPermission AccessCustomerAccidents = new ApplicationPermission { Id = 180, Name = "Access Customer Accidents", SystemName = "AccessCustomerAccident", Category = "Customers" };
        public static readonly ApplicationPermission EditCustomerAccidents = new ApplicationPermission { Id = 181, Name = "Edit Customer Accidents", SystemName = "EditCustomerAccidents", Category = "Customers" };
        public static readonly ApplicationPermission CreateCustomerAccidents = new ApplicationPermission { Id = 182, Name = "Create Customer Accidents", SystemName = "CreateCustomerAccidents", Category = "Customers" };
        public static readonly ApplicationPermission DeleteCustomerAccidents = new ApplicationPermission { Id = 183, Name = "Delete Customer Accidents", SystemName = "DeleteCustomerAccidents", Category = "Customers" };

        public static readonly ApplicationPermission CreateCustomerCoupons = new ApplicationPermission { Id = 196, Name = "Create Customer Coupon", SystemName = "CreateCustomerCoupons", Category = "Customers" };
        public static readonly ApplicationPermission AccessCustomerCoupons = new ApplicationPermission { Id = 197, Name = "Access Customer Coupon", SystemName = "AccessCustomerCoupons", Category = "Customers" };
        public static readonly ApplicationPermission EditCustomerCoupons = new ApplicationPermission { Id = 198, Name = "Edit Customer Coupon", SystemName = "EditCustomerCoupons", Category = "Customers" };
        public static readonly ApplicationPermission DeleteCustomerCoupons = new ApplicationPermission { Id = 199, Name = "Delete Customer Coupon", SystemName = "DeleteCustomerCoupons", Category = "Customers" };


        public static readonly ApplicationPermission AccessAgencyDocumentItems = new ApplicationPermission { Id = 184, Name = "Access Agency Document Items", SystemName = "AccessAgencyDocumentItems", Category = "Agencies" };
        public static readonly ApplicationPermission EditAgencyDocumentItems = new ApplicationPermission { Id = 185, Name = "Edit Agency Document Items", SystemName = "EditAgencyDocumentItems", Category = "Agencies" };
        public static readonly ApplicationPermission CreateAgencyDocumentItems = new ApplicationPermission { Id = 186, Name = "Create Agency Document Items", SystemName = "CreateAgencyDocumentItems", Category = "Agencies" };
        public static readonly ApplicationPermission DeleteAgencyDocumentItems = new ApplicationPermission { Id = 187, Name = "Delete Agency Document Items", SystemName = "DeleteAgencyDocumentItems", Category = "Agencies" };

        public static readonly ApplicationPermission AccessCarAvailability = new ApplicationPermission { Id = 188, Name = "Access Car Availability", SystemName = "AccessCarAvailability", Category = "Vehicles" };
        public static readonly ApplicationPermission EditCarAvailability = new ApplicationPermission { Id = 189, Name = "Edit Car Availability", SystemName = "EditCarAvailability", Category = "Vehicles" };
        public static readonly ApplicationPermission CreateCarAvailability = new ApplicationPermission { Id = 190, Name = "Create Car Availability", SystemName = "CreateCarAvailability", Category = "Vehicles" };
        public static readonly ApplicationPermission DeleteCarAvailability = new ApplicationPermission { Id = 191, Name = "Delete Car Availability", SystemName = "DeleteCarAvailability", Category = "Vehicles" };

        public static readonly ApplicationPermission OrderAdditionalDrivers = new ApplicationPermission { Id = 192, Name = "Order Additional Drivers", SystemName = "OrderAdditionalDrivers", Category = "Platform" };
        public static readonly ApplicationPermission AttachDriverToOrder = new ApplicationPermission { Id = 193, Name = "Attach Driver To Order", SystemName = "AttachDriverToOrder", Category = "Platform" };

        public static readonly ApplicationPermission AccessFleetCharges = new ApplicationPermission { Id = 194, Name = "Access Fleet Charges", SystemName = "AccessFleetCharges", Category = "Agencies" };

        public static readonly ApplicationPermission AccessFleetVehicles = new ApplicationPermission { Id = 195, Name = "Access Fleet Vehicles", SystemName = "AccessFleetVehicles", Category = "Agencies" };

        public static readonly ApplicationPermission AssignFleeetSubscriptions = new ApplicationPermission { Id = 204, Name = "Assign Fleet Subscriptions", SystemName = "AssignFleeetSubscriptions", Category = "Agencies" };
        public static readonly ApplicationPermission AssignFleeetDiscounts = new ApplicationPermission { Id = 205, Name = "Assign Fleet Discounts", SystemName = "AssignFleeetDiscounts", Category = "Agencies" };
        public static readonly ApplicationPermission AssignFleeetFixedDiscounts = new ApplicationPermission { Id = 206, Name = "Assign Fleet Fixed Discounts", SystemName = "AssignFleeetFixedDiscounts", Category = "Agencies" };
        public static readonly ApplicationPermission AssignFleeetCharges = new ApplicationPermission { Id = 207, Name = "Assign Fleet Charges", SystemName = "AssignFleeetCharges", Category = "Agencies" };
        public static readonly ApplicationPermission AssignFleeetAncillaries = new ApplicationPermission { Id = 208, Name = "Assign Fleet Ancillaries", SystemName = "AssignFleeetAncillaries", Category = "Agencies" };
        public static readonly ApplicationPermission AssignFleeetPrices = new ApplicationPermission { Id = 209, Name = "Assign Fleet Prices", SystemName = "AssignFleeetPrices", Category = "Agencies" };

        public static readonly ApplicationPermission AccessDynamicPrice = new ApplicationPermission { Id = 211, Name = "Access Dynamic Price", SystemName = "AccessDynamicPrice", Category = "Agencies" };
        public static readonly ApplicationPermission EditDynamicPrice = new ApplicationPermission { Id = 212, Name = "Edit Dynamic Price", SystemName = "EditDynamicPrice", Category = "Agencies" };
        public static readonly ApplicationPermission CreateDynamicPrice = new ApplicationPermission { Id = 213, Name = "Create Dynamic Price", SystemName = "CreateDynamicPrice", Category = "Agencies" };
        public static readonly ApplicationPermission DeleteDynamicPrice = new ApplicationPermission { Id = 214, Name = "Delete Dynamic Price", SystemName = "DeleteDynamicPrice", Category = "Agencies" };

        public static readonly ApplicationPermission AccessLeads = new ApplicationPermission { Id = 215, Name = "Access Leads", SystemName = "AccessLeads", Category = "Agencies" };
        public static readonly ApplicationPermission EditLeads = new ApplicationPermission { Id = 216, Name = "Edit Leads", SystemName = "EditLeads", Category = "Agencies" };
        public static readonly ApplicationPermission CreateLeads = new ApplicationPermission { Id = 217, Name = "Create Leads", SystemName = "CreateLeads", Category = "Agencies" };
        public static readonly ApplicationPermission DeleteLeads = new ApplicationPermission { Id = 218, Name = "Delete Leads", SystemName = "DeleteLeads", Category = "Agencies" };

        public static readonly ApplicationPermission AccessTemplates = new ApplicationPermission { Id = 219, Name = "Access Templates", SystemName = "AccessTemplates", Category = "Configuration" };
        public static readonly ApplicationPermission EditTemplates = new ApplicationPermission { Id = 220, Name = "Edit Templates", SystemName = "EditTemplates", Category = "Configuration" };
        public static readonly ApplicationPermission CreateTemplates = new ApplicationPermission { Id = 221, Name = "Create Templates", SystemName = "CreateTemplates", Category = "Configuration" };
        #endregion
    }
}
