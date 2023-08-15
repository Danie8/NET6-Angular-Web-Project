using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NET6_Angular_Web_Project.Models;
using NET6_Angular_Web_Project.Data;
using log4net;

namespace NET6_Angular_Web_Project.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private static readonly ILog log = LogManager.GetLogger("Debug");

        public UsersController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpPost("RegisterUser")]
        public async Task<IActionResult> RegisterUser(User model)
        {
            if (ModelState.IsValid)
            {
                model.FechaCreacion = DateTime.Now;
                // Aquí puedes añadir la lógica para registrar el usuario en la base de datos
                _context.Users.Add(model);
                await _context.SaveChangesAsync();

                log.Info($"Registro Exitoso. Usuario: {model.UserName}, Email: {model.Email}");

                return Ok(); // Devuelve un código de estado HTTP 200 para indicar que el registro fue exitoso
            }
            else
            {
                // Log de modelo no válido
                log.Warn("El modelo no es válido al intentar registrar el usuario");


                return BadRequest(ModelState); // Devuelve un código de estado HTTP 400 si el modelo no es válido
            }
        }
    }
}
