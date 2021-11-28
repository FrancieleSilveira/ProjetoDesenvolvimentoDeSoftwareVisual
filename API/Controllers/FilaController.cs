using System.Linq;
using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/fila")]
    public class FilaController : ControllerBase
    {
         private readonly DataContext _context;

        public FilaController(DataContext context)
        {
            _context = context;
        }

    }
}