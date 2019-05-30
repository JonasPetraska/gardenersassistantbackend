using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer.Models;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityServer.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    [Authorize(AuthenticationSchemes = IdentityServerAuthenticationDefaults.AuthenticationScheme)]
    public class ProfileController : ControllerBase
    {
        private UserManager<ApplicationUser> _userManager { get; }

        public ProfileController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<ActionResult> GetUserById(string id)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(id);
                if(user != null)
                {
                    return Ok(user);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetUserByEmail(string email)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(email);
                if (user != null)
                {
                    return Ok(user);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetUserByUsername(string username)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(username);
                if (user != null)
                {
                    return Ok(user);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> CreateUser(ApplicationUser user)
        {
            try
            {
                user.EmailConfirmed = true;
                user.PhoneNumberConfirmed = true;

                var result = await _userManager.CreateAsync(user, user.PasswordHash);
                if (result.Succeeded)
                {
                    return Ok(user);
                }
                return BadRequest(result.Errors);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteUser(string userId)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(userId);
                if(user != null)
                {
                    var deleted = await _userManager.DeleteAsync(user);
                    if (deleted.Succeeded)
                    {
                        return Ok(user);
                    }
                    return BadRequest(deleted.Errors);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}