using Microsoft.AspNetCore.Mvc;
using System.Net.Sockets;
using System.Text;
using WebApplication1.Models;
using WebApplication1.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpPost, Route("cell")]
        public Task<Board?> PostCell([FromBody] List<List<string?>> board)
        {
            return new Processor().Process(board);
        }

    }
}
