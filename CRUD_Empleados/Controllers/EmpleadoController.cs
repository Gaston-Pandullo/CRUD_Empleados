using Microsoft.AspNetCore.Mvc;
using CRUD_Empleados.Data;
using CRUD_Empleados.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Empleados.Controllers
{
    public class EmpleadoController : Controller
    {
        private readonly AppDbContext _dbContext;
        public EmpleadoController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public async Task<IActionResult> Lista()
        {
            List<Empleado> listaEmplados = await _dbContext.Empleados.ToListAsync();
            return View(listaEmplados);
        }
        [HttpGet]
        public IActionResult Nuevo()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Nuevo(Empleado empleado)
        {
            await _dbContext.Empleados.AddAsync(empleado);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Lista));
        }
    }
}
