using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    public class ActivitesController: BaseApiController
    {
        private readonly DataContext _context;
        public ActivitesController(DataContext context)
        {
            _context=context;
        }

        [HttpGet("GetActivityList")] //api/acitivities
        public async Task<IActionResult> GetActivityList()
        {
            var list=await _context.Activities.ToListAsync();
            return Ok(list);
        }

        [HttpGet("GetActivityById")]
        public async Task<IActionResult> GetActivityById(Guid Id)
        {
            var item=await _context.Activities.FirstOrDefaultAsync(x=>x.Id==Id);
            return Ok(item);
        }


        
    }
}