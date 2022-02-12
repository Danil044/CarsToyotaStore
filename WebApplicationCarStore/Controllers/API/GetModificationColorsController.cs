using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationCarStore.Data;
using WebApplicationCarStore.Data.Entities;

namespace WebApplicationCarStore.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetModificationColorsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GetModificationColorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Color>>> Get(Guid id)
        {
            /*
            var selecColor = _context.ModificationColors
                 .Include(col => col.Color)
                 .Where(mc => mc.ModificationId == id);
            */

            var selecColor = _context.Colors.SelectMany(
                color => color.ModificationColors,
                (c, mc) => new { Color = c, ModColor = mc })
                .Where(a => a.ModColor.ModificationId == id)
                .Select(a => a.Color);
            

            return await selecColor.ToListAsync();
        }
    }
}
