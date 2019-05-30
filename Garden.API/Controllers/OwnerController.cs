using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Garden.API.Data;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Garden.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = IdentityServerAuthenticationDefaults.AuthenticationScheme)]
    public class OwnerController : ControllerBase
    {
        private ApplicationDbContext _context { get; }

        public OwnerController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                return Ok(await _context.Owners.ToListAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        public async Task<ActionResult> Get(string id)
        {
            try
            {
                return Ok(await _context.Owners.FindAsync(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post(Common.Models.Owner owner)
        {
            try
            {
                var added = await _context.Owners.AddAsync(owner);
                if (added.Entity != null)
                {
                    if (await _context.SaveChangesAsync() > 0)
                    {
                        return Ok(added.Entity);
                    }

                    return BadRequest();
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut]
        public async Task<ActionResult> Put(Common.Models.Owner owner)
        {
            try
            {
                var entity = await _context.Owners.FindAsync(owner.Id);
                if (entity != null)
                {
                    _context.Entry(entity).CurrentValues.SetValues(owner);
                    if (await _context.SaveChangesAsync() > 0)
                    {
                        return Ok(owner);
                    }
                    return Ok(owner);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(string id)
        {
            try
            {
                var entity = await _context.Owners.FindAsync(id);
                if (entity != null)
                {
                    var deleted = _context.Remove(entity);
                    if (await _context.SaveChangesAsync() > 0)
                    {
                        return Ok(deleted.Entity);
                    }
                    return BadRequest();
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}