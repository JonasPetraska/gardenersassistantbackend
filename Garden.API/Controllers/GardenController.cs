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
using Common.Models;

namespace Garden.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = IdentityServerAuthenticationDefaults.AuthenticationScheme)]
    public class GardenController : ControllerBase
    {
        private ApplicationDbContext _context { get; }

        public GardenController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                return Ok(await _context.Gardens.ToListAsync());
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
                return Ok(await _context.Gardens.FindAsync(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post(Common.Models.Garden garden)
        {
            try
            {
                var added = await _context.Gardens.AddAsync(garden);
                if(added.Entity != null)
                {
                    if(await _context.SaveChangesAsync() > 0)
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
        public async Task<ActionResult> Put(Common.Models.Garden garden)
        {
            try
            {
                var entity = await _context.Gardens.FindAsync(garden.Id);
                if (entity != null)
                {
                    _context.Entry(entity).CurrentValues.SetValues(garden);
                    if (await _context.SaveChangesAsync() > 0)
                    {
                        return Ok(garden);
                    }
                    return Ok(garden);
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
                var entity = await _context.Gardens.FindAsync(id);
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