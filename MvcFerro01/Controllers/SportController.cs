using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using X.PagedList.Extensions;
using MvcFerro.Servicios.Interfaces;
using MvcFerro01.Entidades;
using MvcFerro01.ViewModels.Sport.SportListVm;
using MvcFerro01.ViewModels.Sport.SportEditVm;
using EFCore3.Servicios.Servicios;
using MvcFerro01.ViewModels.Brand.BrandDetailsVm;
using MvcFerro01.ViewModels.Shoe.ShoeListVm;
using MvcFerro01.ViewModels.Sport.SportDetailsVm;

namespace MvcFerro01.Controllers
{
    public class SportController : Controller
    {
        private readonly IServicioSports? service;
        private readonly IServicioShoes? serviceshoe;

        private readonly IMapper? _mapper;
        public SportController(IServicioSports? BService,IServicioShoes s,
            IMapper mapper)
        {
            serviceshoe = s;
            service = BService;
            _mapper = mapper;
        }

        public IActionResult Index(int? page, string? searchTerm = null, bool viewAll = false, int pageSize = 10)
        {

            int pageNumber = page ?? 1;
            ViewBag.currentPageSize = pageSize;
            IEnumerable<Sports>? brand;
            if (!viewAll)
            {
                if (!string.IsNullOrEmpty(searchTerm))
                {
                    brand = service?
                        .GetAll(orderBy: o => o.OrderBy(c => c.SportName),
                            filter: c => c.SportName.Contains(searchTerm));
                          //  || c.BrandName!.Contains(searchTerm));
                    ViewBag.currentSearchTerm = searchTerm;
                }
                else
                {
                    brand = service?
                        .GetAll(orderBy: o => o.OrderBy(c => c.SportName));

                }

            }
            else
            {
                brand = service?
                    .GetAll(orderBy: o => o.OrderBy(c => c.SportName));

            }
                 var SportVm = _mapper?.Map<List<SportListVm>>(brand)
                    .ToPagedList(pageNumber, pageSize);


               return View(SportVm);




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
            SportEditVm sportvm;
            if (id == null || id == 0)
            {
                sportvm = new SportEditVm();
            }
            else
            {
                try
                {
                    Sports? spr = service.GetSportsPorId(id.Value);
                    if (spr == null)
                    {
                        return NotFound();
                    }
                    sportvm = _mapper.Map<SportEditVm>(spr);
                    return View(sportvm);
                }
                catch (Exception ex)
                {
                    // Log the exception (ex) here as needed
                    return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving the record.");
                }

            }
            return View(sportvm);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult UpSert(SportEditVm mar)
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
                Sports marc = _mapper.Map<Sports>(mar);

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
            Sports? sport= service?.GetSportsPorId(id.Value);
            if (sport is null)
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
                service.Borrar(sport);
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
            Sports? sport = service?.GetSportsPorId(id.Value);
            SportDetailsVm sportv = new SportDetailsVm();

            sportv.SportId = sport.SportId;
            sportv.SportName = sport.SportName;
            sportv.Active = sport.Active;

            if (sport is null)
            {
                return NotFound();
            }
            var currentPage = page ?? 1;
            int pageSize = 10;
            SportDetailsVm SportVm = _mapper!.Map<SportDetailsVm>(sportv);
            var S = serviceshoe!.GetAll(

                filter: p => p.SportId == SportVm.SportId,
                propertiesNames: "Sport");
            SportVm.Shoes = _mapper!.Map<List<ShoeListVm>>(S).ToPagedList(currentPage, pageSize);
            return View(SportVm);
        }

    }
}
