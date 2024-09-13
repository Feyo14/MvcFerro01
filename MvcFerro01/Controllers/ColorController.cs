using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using X.PagedList.Extensions;
using MvcFerro.Servicios.Interfaces;
using MvcFerro01.Entidades;
using MvcFerro01.ViewModels.Color.ColorListVm;
using MvcFerro01.ViewModels.Color.ColorEditVm;


namespace MvcFerro01.Controllers
{
    public class ColorController : Controller
    {
        private readonly IServicioColors? service;
        private readonly IMapper? _mapper;
        public ColorController(IServicioColors? BService,
            IMapper mapper)
        {
            service = BService;
            _mapper = mapper;
        }

        public IActionResult Index(int? page, string? searchTerm = null, bool viewAll = false, int pageSize = 10)
        {

            int pageNumber = page ?? 1;
            ViewBag.currentPageSize = pageSize;
            IEnumerable<Colors>? color;
            if (!viewAll)
            {
                if (!string.IsNullOrEmpty(searchTerm))
                {
                    color = service?
                        .GetAll(orderBy: o => o.OrderBy(c => c.ColorName),
                            filter: c => c.ColorName.Contains(searchTerm));
                          //  || c.BrandName!.Contains(searchTerm));
                    ViewBag.currentSearchTerm = searchTerm;
                }
                else
                {
                    color = service?
                        .GetAll(orderBy: o => o.OrderBy(c => c.ColorName));

                }

            }
            else
            {
                color = service?
                    .GetAll(orderBy: o => o.OrderBy(c => c.ColorName));

            }
                 var BrandVm = _mapper?.Map<List<ColorListVm>>(color)
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
            ColorEditVm colorvm;
            if (id == null || id == 0)
            {
                colorvm = new ColorEditVm();
            }
            else
            {
                try
                {
                    Colors? col = service.GetColorsPorId(id.Value);
                    if (col == null)
                    {
                        return NotFound();
                    }
                    colorvm = _mapper.Map<ColorEditVm>(col);
                    return View(colorvm);
                }
                catch (Exception ex)
                {
                    // Log the exception (ex) here as needed
                    return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving the record.");
                }

            }
            return View(colorvm);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult UpSert(ColorEditVm col)
        {
            if (!ModelState.IsValid)
            {
                return View(col);
            }

            if (service == null || _mapper == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Dependencias no están configuradas correctamente");
            }

            try
            {
                Colors color = _mapper.Map<Colors>(col);

                if (service.existe(color))
                {
                    ModelState.AddModelError(string.Empty, "Record already exist");
                    return View(col);
                }

                service.Agregar(color);
                TempData["success"] = "Record successfully added/edited";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                // Log the exception (ex) here as needed
                ModelState.AddModelError(string.Empty, "An error occurred while editing the record.");
                return View(col);
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
            Colors? color= service?.GetColorsPorId(id.Value);
            if (color is null)
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
                service.Borrar(color);
                return Json(new { success = true, message = "Record successfully deleted" });
            }
            catch (Exception)
            {

                return Json(new { success = false, message = "Couldn't delete record!!! " }); ;

            }
        }

    }
}
