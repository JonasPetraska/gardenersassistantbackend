using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Models;
using IdentityServer.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IdentityServer.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PermissionsController : ControllerBase
    {
        private ApplicationDbContext _context{ get; }

        public PermissionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                return Ok(await _context.Permissions.ToListAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        public async Task<ActionResult> Get(int id)
        {
            try
            {
                return Ok(await _context.Permissions.FindAsync(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post(Permission permission)
        {
            try
            {
                var inserted = await _context.Permissions.AddAsync(permission);
                if(inserted.Entity != null)
                {
                    if(await _context.SaveChangesAsync() > 0)
                    {
                        return Ok(inserted.Entity);
                    }
                    return BadRequest();
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut]
        public async Task<ActionResult> Put(Permission permission)
        {
            try
            {
                var permissionFound = await _context.Permissions.FindAsync(permission.Id);
                if(permissionFound != null)
                {
                    _context.Entry<Permission>(permissionFound).CurrentValues.SetValues(permission);
                    if (await _context.SaveChangesAsync() > 0)
                    {
                        return Ok(permission);
                    }
                    return Ok(permission);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var permission = await _context.Permissions.FindAsync(id);
                if(permission != null)
                {
                    var removed = _context.Permissions.Remove(permission);
                    if(removed.Entity != null)
                    {
                        return Ok(removed);
                    }
                    return BadRequest();
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