using CommonInitializer;
using IdentityService.Domain;
using IdentityService.Infrastructure;
using IdentityService.WebAPI.Events;
using Juqianxie.ASPNETCore;
using Juqianxie.EventBus;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Linq;
using System.Reflection;

namespace IdentityService.WebAPI.Controllers.UserAdmin;

[Route("[controller]/[action]")]
[ApiController]
//[Authorize(Roles = "Admin")]
public class UserAdminController : ControllerBase
{
    private readonly IdUserManager userManager;
    private readonly IIdRepository repository;
    private readonly IEventBus eventBus;
    //private readonly IDataProtector protector;


    public UserAdminController(IdUserManager userManager, IEventBus eventBus, IIdRepository repository)//, IDataProtectionProvider provider)
    {
        this.userManager = userManager;
        this.eventBus = eventBus;
        this.repository = repository;
        //this.protector = provider.CreateProtector(GetType().FullName); ;
    }

    [HttpGet]
    public async Task<string> FindAllUsers()
    {
        var list = await userManager.Users.Select(u => UserDTO.Create(u)).ToArrayAsync();
        var json = JsonConvert.SerializeObject(list, new JsonSerializerSettings()
        {
            ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
        });
        //var pstring = protector.Protect(json);
        //var u= protector.Unprotect(pstring);
        return json;
    }
    [HttpGet]
    [ServiceFilter(typeof(ProtectAtribuild))]
    public async Task<UserDTO[]> FindAllUsers2()
    {
        var list = await userManager.Users.Select(u => UserDTO.Create(u)).ToArrayAsync();
 
        return list;//protector.Protect(str);
       
       
    }
    [HttpGet]
    [Route("{id}")]
    public async Task<UserDTO> FindById(Guid id)
    {
        var user = await userManager.FindByIdAsync(id.ToString());
        return UserDTO.Create(user);
    }

    //[Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<ActionResult> AddAdminUser(AddAdminUserRequest req)
    {
        (var result, var user, var password) = await repository
            .AddAdminUserAsync(req.UserName, req.PhoneNum);
        if (!result.Succeeded)
        {
            return BadRequest(result.Errors.SumErrors());
        }
        //生成的密码短信发给对方
        //可以同时或者选择性的把新增用户的密码短信/邮件/打印给用户
        //体现了领域事件对于代码“高内聚、低耦合”的追求
        var userCreatedEvent = new UserCreatedEvent(user.Id, req.UserName, password, req.PhoneNum);
        eventBus.Publish("IdentityService.User.Created", userCreatedEvent);
        return Ok();
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<ActionResult> DeleteAdminUser(long id)
    {
        await repository.RemoveUserAsync(id);
        return Ok();
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<ActionResult> UpdateAdminUser(long id, EditAdminUserRequest req)
    {
        var user = await repository.FindByIdAsync(id);
        if (user == null)
        {
            return NotFound("用户没找到");
        }
        user.PhoneNumber = req.PhoneNum;
        await userManager.UpdateAsync(user);
        return Ok();
    }

    [HttpPost]
    [Route("{id}")]
    public async Task<ActionResult> ResetAdminUserPassword(long id)
    {
        (var result, var user, var password) = await repository.ResetPasswordAsync(id);
        if (!result.Succeeded)
        {
            return BadRequest(result.Errors.SumErrors());
        }
        //生成的密码短信发给对方
        var eventData = new ResetPasswordEvent(user.Id, user.UserName, password, user.PhoneNumber);
        eventBus.Publish("IdentityService.User.PasswordReset", eventData);
        return Ok();
    }
}