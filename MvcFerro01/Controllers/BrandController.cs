using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using X.PagedList.Extensions;
using MvcFerro.Servicios.Interfaces;
using MvcFerro01.Entidades;
using MvcFerro01.ViewModels.Brand.BrandListVm;
using MvcFerro01.ViewModels.Brand.BrandEditVm;
using MvcFerro01.ViewModels.Brand.BrandDetailsVm;
using MvcFerro01.ViewModels.Shoe.ShoeListVm;
using MvcFerro01.ViewModels.Brand.BrandDetail;

namespace MvcFerro01.Controllers
{
    public class BrandController : Controller
    {
        private readonly IServicioBrands? service;
        private readonly IServicioShoes? serviceshoes;

        private readonly IMapper? _mapper;
        public BrandController(IServicioBrands? BService, IServicioShoes s,
            IMapper mapper)
        {
            service = BService;
            serviceshoes = s;
            _mapper = mapper;
        }

        public IActionResult Index(int? page, string? searchTerm = null, bool viewAll = false, int pageSize = 10)
        {

            int pageNumber = page ?? 1;
            ViewBag.currentPageSize = pageSize;
            IEnumerable<Brands>? brand;
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
                    Brands? marc = service.GetBrandsPorId(id.Value);
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
                Brands marc = _mapper.Map<Brands>(mar);

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
            Brands? category= service?.GetBrandsPorId(id.Value);
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
        public IActionResult Details(int? id, int? page)
        {

            if (id is null || id == 0)
            {
                return NotFound();
            }
            Brands? brand = service?.GetBrandsPorId(id.Value);
            BrandDetailsVm marcavm= new BrandDetailsVm();

            marcavm.BrandId = brand.BrandId;
            marcavm.BrandName = brand.BrandName;
            marcavm.Active = brand.Active;

            if (brand is null)
            {
                return NotFound();
            }
            var currentPage = page ?? 1;
            int pageSize = 10;
            BrandDetailsVm  brandVm = _mapper!.Map<BrandDetailsVm>(marcavm);
            var S = serviceshoes!.GetAll(
                
                filter: p => p.BrandId == brandVm.BrandId,
                propertiesNames:"Brand");
            brandVm.Shoes = _mapper!.Map<List<ShoeListVm>>(S).ToPagedList(currentPage, pageSize);
            return View(brandVm);
        }

    }
}
