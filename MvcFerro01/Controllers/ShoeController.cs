using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using X.PagedList.Extensions;
using MvcFerro.Servicios.Interfaces;
using MvcFerro.Entidades;
using MvcFerro01.ViewModels.Shoe.ShoeEditVm;
namespace MvcFerro.Controllers
{
    public class ShoeController : Controller
    {
        private readonly IServicioShoes? service;
        private readonly IMapper? _mapper;
        public ShoeController(IServicioShoes? ShoeService,
            IMapper mapper)
        {
            service = ShoeService;
            _mapper = mapper;
        }

        public IActionResult Index(int? page)
        {
            int pageNumber = page ?? 1;
            int pageSize = 10;
            var shoe = service?.GetLista().ToPagedList(pageNumber, pageSize);
            ;
            return View(shoe);
        }
        
        public IActionResult UpSert(int? id)
        {
            if (service == null || _mapper == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Dependencias no están configuradas correctamente");
            }
        ShoeEditVm Shoe;
            if (id == null || id == 0)
            {
                Shoe = new ShoeEditVm();
            }
            else
            {
                try
                {
                    Shoes? shoe = service.GetShoePorId(id.Value);
                    if (shoe == null)
                    {
                        return NotFound();
                    }
                    Shoe = _mapper.Map<ShoeEditVm>(shoe);
                    return View(Shoe);
                }
                catch (Exception ex)
                {
                    // Log the exception (ex) here as needed
                    return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving the record.");
                }

            }
            return View(Shoe);

        }


        [HttpPost]
        public IActionResult UpSert(ShoeEditVm s)
        {
            if (!ModelState.IsValid)
            {
                return View(s);
            }

            if (service == null || _mapper == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Dependencias no están configuradas correctamente");
            }

            try
            {
                Shoes shoe = _mapper.Map<Shoes>(s);

                if (service.existe(shoe))
                {
                    ModelState.AddModelError(string.Empty, "Record already exist");
                    return View(s);
                }

                service.Agregar(shoe);
                TempData["success"] = "Record successfully added/edited";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                // Log the exception (ex) here as needed
                ModelState.AddModelError(string.Empty, "An error occurred while editing the record.");
                return View(s);
            }
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            if (id is null || id==0)
            {
                return NotFound();
            }
            Shoes? s= service?.GetShoePorId(id.Value);
            if (s is null)
            {
                return NotFound();
            }
            try
            {
                if (service == null || _mapper == null)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Dependencias no están configuradas correctamente");
                }

                if (service.existeShoeSize(s.ShoeId))
                {
                    return Json(new { success = false, message="Related Record... Delete Deny!!" }); ;
                }
                service.Borrar(s);
                return Json(new { success = true, message = "Record successfully deleted" });
            }
            catch (Exception)
            {

                return Json(new { success = false, message = "Couldn't delete record!!! " }); ;

            }
        }

    }
}
