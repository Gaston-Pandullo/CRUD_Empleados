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
        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            Empleado empleado = await _dbContext.Empleados.FirstAsync(e => e.Id == id);
            return View(empleado);
        }
        [HttpPost]
        public async Task<IActionResult> Editar(Empleado empleado)
        {
            _dbContext.Empleados.Update(empleado);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Lista));
        }

        [HttpGet]
        public async Task<IActionResult> Eliminar(int id)
        {
            Empleado empleado = await _dbContext.Empleados.FirstAsync(e => e.Id == id);
            _dbContext.Empleados.Remove(empleado);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Lista));
        }
    }
}
