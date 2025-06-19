using Dinet.Application.DTOs;
using Dinet.Application.Usecases;
using Dinet.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dinet.Web.Controllers
{
    public class MovInventarioController : Controller
    {
        private readonly GetMovInventarios _getMovInventarios;

        public MovInventarioController(GetMovInventarios getMovInventarios)
        {
            _getMovInventarios = getMovInventarios;
        }


        public async Task<ActionResult> Index()
        {
            // Opciones futuras para busquedas 
            DateTime? fechaInicio = new DateTime(2025, 01, 01); 
            DateTime? fechaFin = new DateTime(2025, 12, 31);  

            string tipoMovimiento = null;
            string nroDocumento = null;

            var inventariosDTO = await _getMovInventarios.ExecuteAsync(fechaInicio, fechaFin, tipoMovimiento, nroDocumento);

            ViewData["Title"] = "Movimiento de Inventarios";

            return View(inventariosDTO);  
        }
        public IActionResult Create()
        {

            //  queda pendiente por agregar fluent validation
            ViewData["Title"] = "Crear Movimiento de Inventario";
            return View(new MovInventarioDTO());
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(MovInventario movInventario)
        {
            //  queda pendiente por agregar fluent validation
            if (ModelState.IsValid)
            {
                var response = await _getMovInventarios.ExecuteInsertAsync(movInventario);
                if (!response)
                {

                }
                return RedirectToAction(nameof(Index));
            }
            return View(movInventario);
        
        }

        public async Task<ActionResult> Edit(string CodCia, string CompaniaVenta, string AlmacenVenta,string TipoMovimiento, string TipoDocumento, string NroDocumento, string CodItem2)
        {

            var inventarioDTO = await _getMovInventarios.ExecuteByIdAsync(CodCia, CompaniaVenta, AlmacenVenta, TipoMovimiento, TipoDocumento, NroDocumento, CodItem2);
            if (inventarioDTO == null)
            {
                return NotFound();
            }
            ViewData["Title"] = "Editar Movimiento de Inventario";
            return View(inventarioDTO);
        }

        [HttpPost]

        public async Task<IActionResult> Edit(MovInventarioDTO inventarioDTO)
        {
            //  queda pendiente por agregar fluent validation
            if (ModelState.IsValid)
            {
              
               var result = await _getMovInventarios.ExecuteUpdateAsync(inventarioDTO);

                if (result)
                {
                    return RedirectToAction(nameof(Index)); 
                }
                else
                {
                    ModelState.AddModelError("", "Error al actualizar el inventario.");
                }
            }

            return View(inventarioDTO); 
        }
        public async Task<ActionResult> Details(string CodCia, string CompaniaVenta, string AlmacenVenta, string TipoMovimiento, string TipoDocumento, string NroDocumento, string CodItem2)
        {

            //var inventarioDTO = await _getMovInventarios.ExecuteDeleteAsync(CodCia, CompaniaVenta, AlmacenVenta, TipoMovimiento, TipoDocumento, NroDocumento, CodItem2);
            //if (inventarioDTO == null)
            //{
            //    return NotFound();
            //}
            return View();
        }


        public IActionResult Delete(string CodCia, string CompaniaVenta, string AlmacenVenta, string TipoMovimiento, string TipoDocumento, string NroDocumento, string CodItem2)
        {
            // Lógica para eliminar el inventario por id
            if (string.IsNullOrEmpty(CodCia))
            {
                return NotFound();
            }
            var result = _getMovInventarios.ExecuteDeleteAsync(CodCia, CompaniaVenta, AlmacenVenta, TipoMovimiento, TipoDocumento, NroDocumento, CodItem2);

            return View(result);
        }
    }
}
