﻿namespace IdentityService.Domain
{
    public record ResetPasswordEvent(long Id, string UserName, string Password, string PhoneNum);
}
