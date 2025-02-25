using ChangePond_Visitors_Backend_Application.Converters;
using ChangePond_Visitors_Backend_Application.Data;
using ChangePond_Visitors_Backend_Application.Entities;
using ChangePond_Visitors_Backend_Application.RequestDtos;
using ChangePond_Visitors_Backend_Application.ResponseDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Host = ChangePond_Visitors_Backend_Application.Entities.Host;

namespace ChangePond_Visitors_Backend_Application.Controllers
{
    [Route("api/visitors")]
    [ApiController]
    public class VisitorController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public VisitorController(ApplicationDbContext context)
        {
            _context = context;
        }

        // 1️⃣ Create a new visitor
        [HttpPost]
        public async Task<ActionResult<VisitorResponseDto>> CreateVisitor([FromBody] VisitorRequestDto requestDto)
        {
            var visitor = requestDto.ToEntity();
            _context.Visitors.Add(visitor);
            await _context.SaveChangesAsync();

            var responseDto = visitor.ToDto();
            return CreatedAtAction(nameof(GetVisitorById), new { id = visitor.VisitorID }, responseDto);
        }

        // 2️⃣ Get all visitors
        [HttpGet]
        public async Task<ActionResult<List<VisitorResponseDto>>> GetAllVisitors()
        {
            var visitors = await _context.Visitors.Include(v => v.Host).ToListAsync();
            return visitors.Select(v => v.ToDto()).ToList();
        }

        // 3️⃣ Get a visitor by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<VisitorResponseDto>> GetVisitorById(int id)
        {
            var visitor = await _context.Visitors.Include(v => v.Host)
                                                 .FirstOrDefaultAsync(v => v.VisitorID == id);

            var host = await _context.Hosts.FindAsync(visitor.HostID);

            if (visitor == null)
                return NotFound(new { message = "Visitor not found" });

            return visitor.ToDto();
        }

        // 4️⃣ Update a visitor
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVisitor(int id, [FromBody] VisitorRequestDto requestDto)
        {
            var visitor = await _context.Visitors.FindAsync(id);
            if (visitor == null)
                return NotFound(new { message = "Visitor not found" });

            // Update fields
            visitor.Name = requestDto.Name;
            visitor.ContactNumber = requestDto.ContactNumber;
            visitor.Email = requestDto.Email;
            visitor.Purpose = requestDto.Purpose;
            visitor.HostID = requestDto.HostID;
            visitor.IDProof = requestDto.IDProof;

            await _context.SaveChangesAsync();
            return NoContent();  // 204 No Content
        }

        // 5️⃣ Delete a visitor
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVisitor(int id)
        {
            var visitor = await _context.Visitors.FindAsync(id);
            if (visitor == null)
                return NotFound(new { message = "Visitor not found" });

            _context.Visitors.Remove(visitor);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Visitor deleted successfully" });
        }
    }
}
