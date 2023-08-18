using IdentityService.Domain.Entities;
using Juqianxie.JWT;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Domain
{
    public class IdDomainService
    {
        private readonly IIdRepository repository;
        private readonly ITokenService tokenService;
        private readonly IOptions<JWTOptions> optJWT;
        private readonly IDataProtectionProvider protector;
        public IdDomainService(IIdRepository repository,
                  ITokenService tokenService, IOptions<JWTOptions> optJWT, IDataProtectionProvider protector)
        {
            this.repository = repository;
            this.tokenService = tokenService;
            this.optJWT = optJWT;
            this.protector = protector;
        }
        private async Task<SignInResult> CheckUserNameAndPwdAsync(string userName, string password)
        {
            var user = await repository.FindByNameAsync(userName);
            if (user == null)
            {
                return SignInResult.Failed;
            }
            //CheckPasswordSignInAsync会对于多次重复失败进行账号禁用
            var result = await repository.CheckForSignInAsync(user, password, true);
            return result;
        }
        private async Task<SignInResult> CheckPhoneNumAndPwdAsync(string phoneNum, string password)
        {
            var user = await repository.FindByPhoneNumberAsync(phoneNum);
            if (user == null)
            {
                return SignInResult.Failed;
            }
            var result = await repository.CheckForSignInAsync(user, password, true);
            return result;
        }
        public async Task<(SignInResult Result, string? Token)> RegisterByHospitalNumberAsync(string hospitalNumber, string username,string password) 
        {
            (IdentityResult checkResult, User? user) = await repository.RegisterByHospitalNumberAsync(hospitalNumber,username 
                , password);
            if (checkResult.Succeeded)
            {
                string token = await BuildTokenAsync(user);
                return (SignInResult.Success, token);
            }
            else
            {
                return (SignInResult.Failed, null);
            }
        }
        //<(SignInResult Result, string? Token)>  元组的语法
        public async Task<(SignInResult Result, string? Token)> LoginByPhoneAndPwdAsync(string phoneNum, string password)
        {
            var checkResult = await CheckPhoneNumAndPwdAsync(phoneNum, password);
            if (checkResult.Succeeded)
            {
                var user = await repository.FindByPhoneNumberAsync(phoneNum);
                string token = await BuildTokenAsync(user);
                return (SignInResult.Success, token);
            }
            else
            {
                return (checkResult, null);
            }
        }

        public async Task<(SignInResult Result, string? Token)> LoginByUserNameAndPwdAsync(string userName, string password)
        {
            var checkResult = await CheckUserNameAndPwdAsync(userName, password);
            if (checkResult.Succeeded)
            {
                var user = await repository.FindByNameAsync(userName);
                string token = await BuildTokenAsync(user);
                return (SignInResult.Success, token);
            }
            else
            {
                return (checkResult, null);
            }
        }
        public async Task<(SignInResult Result, string? Token)> LoginByHospitalNumberAndPwdAsync(string hospitalNumber, string password)
        {
            var checkResult = await CheckHospitalNumberAndPwdAsync(hospitalNumber, password);
            if (checkResult.Succeeded)
            {
                var user = await repository.FindByHospitalNumberAsync(hospitalNumber);
                string token = await BuildTokenAsync(user);
                return (SignInResult.Success, token);
            }
            else
            {
                return (checkResult, null);
            }
        }

        public async Task<(SignInResult Result, string? Token)> LoginByIDAndPwdAsync(long ID, string password)
        {
            var checkResult = await CheckIDAndPwdAsync(ID, password);
            if (checkResult.Succeeded)
            {
                var user = await repository.FindByIdAsync(ID);
                string token = await BuildTokenAsync(user);
                return (SignInResult.Success, token);
            }
            else
            {
                return (checkResult, null);
            }
        }
        private async Task<SignInResult> CheckIDAndPwdAsync(long ID, string password)
        {
            var user = await repository.FindByIdAsync(ID);
            if (user == null)
            {
                return SignInResult.Failed;
            }
            //CheckPasswordSignInAsync会对于多次重复失败进行账号禁用
            var result = await repository.CheckForSignInAsync(user, password, true);
            return result;
        }

        private async Task<SignInResult> CheckHospitalNumberAndPwdAsync(string hospitalNumber, string password)
        {
            var user = await repository.FindByHospitalNumberAsync(hospitalNumber);
            if (user == null)
            {
                return SignInResult.Failed;
            }
            //CheckPasswordSignInAsync会对于多次重复失败进行账号禁用
            var result = await repository.CheckForSignInAsync(user, password, true);
            return result;
        }
        private async Task<string> BuildTokenAsync(User user)
        {
            var roles = await repository.GetRolesAsync(user);
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
            foreach (string role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            return tokenService.BuildToken(claims, optJWT.Value);
        }

        public Task<IdentityResult> ChangePasswordAsync(long id, string password, string password2)
        {
            return repository.ChangePasswordAsync(id, password, password2);
        }
    }
}
