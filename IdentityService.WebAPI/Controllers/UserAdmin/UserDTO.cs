﻿using IdentityService.Domain;
using IdentityService.Domain.Entities;

namespace IdentityService.WebAPI.Controllers.UserAdmin;
public record UserDTO(long Id, string UserName, string PhoneNumber, DateTime CreationTime)
{
    public static UserDTO Create(User user)
    {
        return new UserDTO(user.Id, user.UserName, user.PhoneNumber, user.CreationTime);
    }
}