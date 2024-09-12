using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using X.PagedList.Extensions;
using MvcFerro.Servicios.Interfaces;
using MvcFerro.Entidades;
using MvcFerro01.ViewModels.Genre.GenreListVm;
using MvcFerro01.ViewModels.Genre.GenreEditVm;

namespace MvcFerro01.Controllers
{
    public class GenreController : Controller
    {
        private readonly IServicioGenre? service;
        private readonly IMapper? _mapper;
        public GenreController(IServicioGenre? BService,
            IMapper mapper)
        {
            service = BService;
            _mapper = mapper;
        }

        public IActionResult Index(int? page, string? searchTerm = null, bool viewAll = false, int pageSize = 10)
        {

            int pageNumber = page ?? 1;
            ViewBag.currentPageSize = pageSize;
            IEnumerable<Genre>? brand;
            if (!viewAll)
            {
                if (!string.IsNullOrEmpty(searchTerm))
                {
                    brand = service?
                        .GetAll(orderBy: o => o.OrderBy(c => c.GenreName),
                            filter: c => c.GenreName.Contains(searchTerm));
                          //  || c.BrandName!.Contains(searchTerm));
                    ViewBag.currentSearchTerm = searchTerm;
                }
                else
                {
                    brand = service?
                        .GetAll(orderBy: o => o.OrderBy(c => c.GenreName));

                }

            }
            else
            {
                brand = service?
                    .GetAll(orderBy: o => o.OrderBy(c => c.GenreName));

            }
                 var BrandVm = _mapper?.Map<List<GenreListVm>>(brand)
                    .ToPagedList(pageNumber, pageSize);


               return View(BrandVm);




            //  int pageNumber = page ?? 1;
            //    int pageSize = 10;
          //  var marca = service?.GetLista();//.ToPagedList(pageNumber, pageSize);
          //  ;
           // return View(marca);
        }
        
        public IActionResult UpSert(int? id)
        {
            if (service == null || _mapper == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Dependencias no están configuradas correctamente");
            }
            GenreEditVm marcavm;
            if (id == null || id == 0)
            {
                marcavm = new GenreEditVm();
            }
            else
            {
                try
                {
                    Genre? marc = service.GetGenrePorId(id.Value);
                    if (marc == null)
                    {
                        return NotFound();
                    }
                    marcavm = _mapper.Map<GenreEditVm>(marc);
                    return View(marcavm);
                }
                catch (Exception ex)
                {
                    // Log the exception (ex) here as needed
                    return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving the record.");
                }

            }
            return View(marcavm);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult UpSert(GenreEditVm mar)
        {
            if (!ModelState.IsValid)
            {
                return View(mar);
            }

            if (service == null || _mapper == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Dependencias no están configuradas correctamente");
            }

            try
            {
                Genre marc = _mapper.Map<Genre>(mar);

                if (service.existe(marc))
                {
                    ModelState.AddModelError(string.Empty, "Record already exist");
                    return View(mar);
                }

                service.Agregar(marc);
                TempData["success"] = "Record successfully added/edited";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                // Log the exception (ex) here as needed
                ModelState.AddModelError(string.Empty, "An error occurred while editing the record.");
                return View(mar);
            }
        }

        [HttpDelete]
        [ValidateAntiForgeryToken]

        public IActionResult Delete(int? id)
        {
            if (id is null || id==0)
            {
                return NotFound();
            }
            Genre? category= service?.GetGenrePorId(id.Value);
            if (category is null)
            {
                return NotFound();
            }
            try
            {
                if (service == null || _mapper == null)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Dependencias no están configuradas correctamente");
                }

               // if (service.estarelacionado(category.MarcaId))
                {
               //     return Json(new { success = false, message="Related Record... Delete Deny!!" }); ;
                }
                service.Borrar(category);
                return Json(new { success = true, message = "Record successfully deleted" });
            }
            catch (Exception)
            {

                return Json(new { success = false, message = "Couldn't delete record!!! " }); ;

            }
        }

    }
}
