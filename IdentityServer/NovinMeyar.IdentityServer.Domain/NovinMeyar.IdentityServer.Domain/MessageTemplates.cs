namespace NovinMeyar.IdentityServer.Domain
{
    public class MessageTemplates
    {
        public static string
            RaisedError = "Raised error on {0} when executed action {2}. Error detail is {1}",
            DeactiveUser = "کاربر با موفقیت غیرفعال گردید",
            RemovedUser = "کاربر با موفقیت حذف گردید",
            IncorrectUserNameOrPassword = "نام کاربری یا رمز عبور اشتباه می باشد",
            IncorrectUserName = "نام کاربری اشتباه می باشد",
            ExpiredUser = "نام کاربری شما منقضی شده است",
            LoginSuccessfully = "عملیات ورود با موفقیت انجام شد",
            AccountLocked = "نام کاربری شما قفل شده است. با ادمین سیستم تماس حاصل فرمایید",
            AccountDeactivated = "نام کاربری شما غیرفعال شده است. با ادمین سیستم تماس حاصل فرمایید",
            CreateUserSuccessfully = "نام کاربری با موفقیت ایجاد گردید",
            ConfirmationUserSuccessfully = "نام کاربری شما با موفقیت تایید گردید",
            ConfirmationUserByAdminSuccessfully = "تایید کاربر با موفقیت انجام گردید",
            ChangedPasswordSuccessfully = "کلمه عبور با موفقیت تغییر یافت",
            ResetPasswordSuccessfully = "کلمه عبور شما با موفقیت بازنشانی گردید",
            AddClaimToUserSuccessfully = "کلیم مورد نظر به نام کاربری اضافه گردید",
            RemoveUserClaimSuccessfully = "کلیم مورد نظر با موفقیت حذف گردید",
            AddClaimsToUserSuccessfully = "کلیم های مورد نظر به نام کاربری اضافه گردیدند",
            RemoveUserClaimsSuccessfully = "کلیم های مورد نظر با موفقیت حذف گردیدند",
            AddUserToRoleSuccessfully = "نام کاربری به نقش مورد نظر اضافه گردید",
            RemoveUserFromRoleSuccessfully = "نقش مورد نظر از کاربر انتخابی گرفته شد",
            AddUserToRolesSuccessfully = "نام کاربری به نقش های مورد نظر اضافه گردید",
            RemoveUserFromRolesSuccessfully = "نقش های مورد نظر از کاربر انتخابی گرفته شد",
            InvalidRoleName = "نام نقش اشتباه می باشد";
    }
}
