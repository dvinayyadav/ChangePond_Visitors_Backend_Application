using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ChangePond_Visitors_Backend_Application.Data;
using ChangePond_Visitors_Backend_Application.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using ChangePond_Visitors_Backend_Application.RequestDtos;
using ChangePond_Visitors_Backend_Application.ResponseDtos;
using Host = ChangePond_Visitors_Backend_Application.Entities.Host;

namespace ChangePond_Visitors_Backend_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HostsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public HostsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/hosts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HostResponseDto>>> GetHosts()
        {
            var hosts = await _context.Hosts.ToListAsync();

            var hostDtos = hosts.Select(h => new HostResponseDto
            {
                HostID = h.HostID,
                Name = h.Name,
                Email = h.Email,
                ContactNumber = h.ContactNumber,
                Department = h.Department
            }).ToList();

            return Ok(hostDtos);
        }

        // GET: api/hosts/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<HostResponseDto>> GetHost(int id)
        {
            var host = await _context.Hosts.FindAsync(id);

            if (host == null)
            {
                return NotFound();
            }

            var hostDto = new HostResponseDto
            {
                HostID = host.HostID,
                Name = host.Name,
                Email = host.Email,
                ContactNumber = host.ContactNumber,
                Department = host.Department
            };

            return Ok(hostDto);
        }

        // POST: api/hosts
        [HttpPost]
        public async Task<ActionResult<HostResponseDto>> CreateHost(HostRequestDto hostDto)
        {
            var host = new Host
            {
                Name = hostDto.Name,
                Email = hostDto.Email,
                ContactNumber = hostDto.ContactNumber,
                Department = hostDto.Department
            };

            _context.Hosts.Add(host);
            await _context.SaveChangesAsync();

            var responseDto = new HostResponseDto
            {
                HostID = host.HostID,
                Name = host.Name,
                Email = host.Email,
                ContactNumber = host.ContactNumber,
                Department = host.Department
            };

            return CreatedAtAction(nameof(GetHost), new { id = host.HostID }, responseDto);
        }

        //PUT: api/hosts/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHost(int id, HostRequestDto hostDto)
        {
            var host = await _context.Hosts.FindAsync(id);
            if (host == null)
            {
                return NotFound();
            }

            host.Name = hostDto.Name;
            host.Email = hostDto.Email;
            host.ContactNumber = hostDto.ContactNumber;
            host.Department = hostDto.Department;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/hosts/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHost(int id)
        {
            var host = await _context.Hosts.FindAsync(id);
            if (host == null)
            {
                return NotFound();
            }

            _context.Hosts.Remove(host);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
