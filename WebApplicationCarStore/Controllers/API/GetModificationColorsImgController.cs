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
    public class GetModificationColorsImgController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GetModificationColorsImgController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<ModificationColor>>> Get(Guid id)
        {
            var selecColor = _context.ModificationColors
                .Where(c => c.ModificationId == id);

            return await selecColor.ToListAsync();
        }
    }
}
