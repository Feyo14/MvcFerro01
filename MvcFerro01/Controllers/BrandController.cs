using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using X.PagedList.Extensions;
using EFCoresFerro.Web2.ViewModels.Brand.BrandListVm;
using EFCoresFerro.Web2.ViewModels.Brand.BrandEditVm;
using MvcFerro.Servicios.Interfaces;
using MvcFerro.Entidades;

namespace MvcFerro01.Controllers
{
    public class BrandController : Controller
    {
        private readonly IServicioBrands? service;
        private readonly IMapper? _mapper;
        public BrandController(IServicioBrands? BService,
            IMapper mapper)
        {
            service = BService;
            _mapper = mapper;
        }

        public IActionResult Index(int? page, string? searchTerm = null, bool viewAll = false, int pageSize = 10)
        {

            int pageNumber = page ?? 1;
            ViewBag.currentPageSize = pageSize;
            IEnumerable<Brand>? brand;
            if (!viewAll)
            {
                if (!string.IsNullOrEmpty(searchTerm))
                {
                    brand = service?
                        .GetAll(orderBy: o => o.OrderBy(c => c.BrandName),
                            filter: c => c.BrandName.Contains(searchTerm));
                          //  || c.BrandName!.Contains(searchTerm));
                    ViewBag.currentSearchTerm = searchTerm;
                }
                else
                {
                    brand = service?
                        .GetAll(orderBy: o => o.OrderBy(c => c.BrandName));

                }

            }
            else
            {
                brand = service?
                    .GetAll(orderBy: o => o.OrderBy(c => c.BrandName));

            }
                 var BrandVm = _mapper?.Map<List<BrandListVm>>(brand)
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
            BrandEditVm marcavm;
            if (id == null || id == 0)
            {
                marcavm = new BrandEditVm();
            }
            else
            {
                try
                {
                    Brand? marc = service.GetBrandsPorId(id.Value);
                    if (marc == null)
                    {
                        return NotFound();
                    }
                    marcavm = _mapper.Map<BrandEditVm>(marc);
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

        public IActionResult UpSert(BrandEditVm mar)
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
                Brand marc = _mapper.Map<Brand>(mar);

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
            Brand? category= service?.GetBrandsPorId(id.Value);
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
