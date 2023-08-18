using IdentityService.Domain;
using IdentityService.Domain.Entities;
using Juqianxie.ASPNETCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.OpenApi.Models;
using System.Diagnostics;
using System.Net;
using System.Security.Claims;

namespace IdentityService.WebAPI.Controllers.Login
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IIdRepository repository;
        private readonly IdDomainService idService;

        public LoginController(IdDomainService idService, IIdRepository repository)
        {
            this.idService = idService;
            this.repository = repository;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> CreateWorld()
        {
            if (await repository.FindByNameAsync("admin") != null)
            {
                return StatusCode((int)HttpStatusCode.Conflict, "已经初始化过了");

            }
            User user = new User("admin", "123456");

            var r = await repository.CreateAsync(user, "123456");
            Debug.Assert(r.Succeeded);
            var token = await repository.GenerateChangePhoneNumberTokenAsync(user, "18918999999");
            var cr = await repository.ChangePhoneNumAsync(user.Id, "18918999999", token);
            Debug.Assert(cr.Succeeded);
            r = await repository.AddToRoleAsync(user, "User");
            Debug.Assert(r.Succeeded);
            r = await repository.AddToRoleAsync(user, "Admin");
            Debug.Assert(r.Succeeded);
            return Ok();
        }
        [HttpPost]
        [UnitOfWork]
        [AllowAnonymous]
        public async Task<ActionResult> CreateWorldUsserdetel(Sex sex, int age, string HospitalNumber, DateTime OperationTime, DateTime DischargeTime, string SurgicalMethod, long userid)
        {

            UserDetails userDetails = new UserDetails(sex, age, HospitalNumber, OperationTime, DischargeTime, SurgicalMethod, userid);
            try
            {
                await repository.CreateUserdeteilsAsync(userDetails);
                return Ok();

            }
            catch (Exception ex)
            {

                return BadRequest("发生错误！" + ex.Message?.ToString());
            }

        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<UserResponse>> GetUserInfo()
        {
            string userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await repository.FindByIdAsync(int.Parse(userId));
            if (user == null)//可能用户注销了
            {
                return NotFound();
            }
            //出于安全考虑，不要机密信息传递到客户端
            //除非确认没问题，否则尽量不要直接把实体类对象返回给前端
            return new UserResponse(user.Id, user.PhoneNumber, user.CreationTime);
        }

        //书中的项目只提供根据用户名登录的功能，以及管理员增删改查，像用户主动注册、手机验证码登录等功能都不弄。

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<string?>> LoginByPhoneAndPwd(LoginByPhoneAndPwdRequest req)
        {
            //todo：要通过行为验证码、图形验证码等形式来防止暴力破解
            (var checkResult, string? token) = await idService.LoginByPhoneAndPwdAsync(req.PhoneNum, req.Password);
            if (checkResult.Succeeded)
            {
                return token;
            }
            else if (checkResult.IsLockedOut)
            {
                //尝试登录次数太多
                return StatusCode((int)HttpStatusCode.Locked, "此账号已经锁定");
            }
            else
            {
                string msg = "登录失败";
                return StatusCode((int)HttpStatusCode.BadRequest, msg);
            }
        }
        /// <summary>
        /// 通过住院号注册
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<LoginlongResponse>> LoginByHospitalNumberAndPwdAsync(
           LoginByHospitalNumberAndPwdRequest req)
        {
            (var checkResult, var token) = await idService.LoginByHospitalNumberAndPwdAsync(req.HospitalNumber, req.Password);

            if (checkResult.Succeeded)
            {
                var user = await repository.FindByHospitalNumberAsync(req.HospitalNumber);

                return new LoginlongResponse(token!, user.Id);
            }
            else if (checkResult.IsLockedOut)//尝试登录次数太多
                return StatusCode((int)HttpStatusCode.Locked, "用户已经被锁定");
            else
            {
                string msg = checkResult.ToString();
                return BadRequest("登录失败" + msg);
            }
        }

        /// <summary>
        /// 通过id注册
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<LoginResponse>> LoginByIDAndPwdAsync(
        LoginByShowIDAndPwdRequest req)
        {
            (var checkResult, var token) = await idService.LoginByIDAndPwdAsync(req.ID, req.Password);
            if (checkResult.Succeeded)
            {
                var user = await repository.FindByIdAsync(req.ID);
                if (user == null)
                {
                    return BadRequest("登录失败");
                }
                return new LoginResponse(token!, user.HospitalNumber);
            }
            else if (checkResult.IsLockedOut)//尝试登录次数太多
                return StatusCode((int)HttpStatusCode.Locked, "用户已经被锁定");
            else
            {
                string msg = checkResult.ToString();
                return BadRequest("登录失败" + msg);
            }
        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<string>> RegisterByHospitalNumberAsync(
           RegisterByHospitalNumberRequest req)
        {
            (var result, var token) = await idService.RegisterByHospitalNumberAsync(req.HospitalNumber, req.UserName, req.Password);
            if (result.Succeeded)
            {
                return token!;
            }
            else if (result.IsLockedOut)//尝试登录次数太多
                return StatusCode((int)HttpStatusCode.Locked, "用户已经被锁定");
            else
            {
                string msg = result.ToString();
                return BadRequest("注册失败" + msg);
            }
        }


        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<string>> LoginByUserNameAndPwd(
            LoginByUserNameAndPwdRequest req)
        {
            (var checkResult, var token) = await idService.LoginByUserNameAndPwdAsync(req.UserName, req.Password);
            if (checkResult.Succeeded) return token!;
            else if (checkResult.IsLockedOut)//尝试登录次数太多
                return StatusCode((int)HttpStatusCode.Locked, "用户已经被锁定");
            else
            {
                string msg = checkResult.ToString();
                return BadRequest("登录失败" + msg);
            }
        }

        [HttpPost]
        [Authorize(Roles = "User")]
        public async Task<ActionResult> ChangeMyPassword(ChangeMyPasswordRequest req)
        {
            var checkResult = await idService.ChangePasswordAsync(req.id, req.Password, req.Password2);
            if (!checkResult.Succeeded)
            {
                return BadRequest(@"修改失败!" + checkResult.Errors.FirstOrDefault());
            }
            return Ok();
        }
    }
}