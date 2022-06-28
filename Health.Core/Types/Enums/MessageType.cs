namespace Health.Core.Types.Enums
{
    public enum MessageTypeEnum
    {
        Success = 0,
        General = 1,
        RequiredHeaderMissing = 2,

        Unauthorized = 3,
        AccessTokenExpired = 4,
        //BadCredentials = 5,
        UserAlreadyExists = 6,
        NoSuchUser = 7,
        MemberAlreadyExists = 8,
        ManagerAlreadyExists = 12,
        EmailNotExsist = 10,
        //EmailNotValid = 10,

        BadInput = 11,
        RequiredDataMissing = 13,
        CustomerDidntFinishRegistration = 14,
        MemberIsDisabled = 15,
        UserNotApprove = 17,
        BadOtp = 19,

        ERPServicesFailure = 1000,
        CreditGuardFailure = 1001,
        OTAKeyFailure = 1002,

        //2100-2199 - time windows errors
        MismatchOrdersWindowsToAvilableWindows = 2101,
        WindowsOverlapEachOther = 2102,

    }
}
