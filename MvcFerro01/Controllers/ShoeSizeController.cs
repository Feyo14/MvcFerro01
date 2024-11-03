using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using X.PagedList.Extensions;
using MvcFerro.Servicios.Interfaces;
using MvcFerro01.Entidades;
using Microsoft.AspNetCore.Mvc.Rendering;
using MvcFerro01.ViewModels.ShoeSize.ShoeSizeListVm;
using MvcFerro01.ViewModels.ShoeSize.ShoeSizeEditVm;


namespace MvcFerro01.Controllers
{
    public class ShoeSizeController : Controller
    {
        private readonly IServicioShoeSize? service;
        private readonly IServicioShoes? serviceB;
        private readonly IServicioSize? serviceS;


        private readonly IMapper? _mapper;
        public ShoeSizeController(IServicioShoeSize? BService, IServicioShoes b,IServicioSize S,
            IMapper mapper)
        {
            service = BService;
            _mapper = mapper;
            serviceB = b;
            serviceS = S;
    
        }

        public IActionResult Index(int? page, string? searchTerm = null, bool viewAll = false, int pageSize = 10)
        {

            int pageNumber = page ?? 1;
            ViewBag.currentPageSize = pageSize;
            IEnumerable<ShoeSize>? shoeS;
            if (!viewAll)
            {
                if (!string.IsNullOrEmpty(searchTerm))
                {
                    shoeS = service?
                        .GetAll(orderBy: o => o.OrderBy(c => c.Size),
                            filter: c => c.Size.sizeNumber.ToString().Contains(searchTerm),
                propertiesNames: "Shoe,Size");

                    //  || c.BrandName!.Contains(searchTerm));
                    ViewBag.currentSearchTerm = searchTerm;
                }
                else
                {
                    //    brand = service?
                    //      .GetAll(orderBy: o => o.OrderBy(c => c.Descripcion),
                    //                               filter: c => c.Model.Contains(searchTerm),
                    //
                    //      propertiesNames: "Brand,Genre,Sport");

                    shoeS = service?
                     .GetAll(propertiesNames: "Shoe,Size");                        
          //  propertiesNames: "Brand,Genre,Sport");


                }

            }
            else
            {
                shoeS = service?
                    .GetAll(orderBy: o => o.OrderBy(c => c.Size.sizeNumber), propertiesNames: "Shoe,Size");

            }
            

            var BrandVm = _mapper?.Map<List<ShoeSizeListVm>>(shoeS)
                    .ToPagedList(pageNumber, pageSize);


               return View(BrandVm);




            //  int pageNumber = page ?? 1;
            //    int pageSize = 10;
          //  var marca = service?.GetLista();//.ToPagedList(pageNumber, pageSize);
          //  ;
           // return View(marca);
        }
        
        public IActionResult UpSert1(int? id)
        {
            if (service == null || _mapper == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Dependencias no están configuradas correctamente");
            }
            ShoeSizeEditVm shoevm;
            if (id == null || id == 0)
            {
                shoevm = new ShoeSizeEditVm();
                shoevm.Shoe = serviceB!
                    .GetAll(orderBy: q => q.OrderBy(c => c.Descripcion))
                    .Select(c => new SelectListItem
                    {
                        Text = c.Descripcion,
                        Value = c.ShoeId.ToString()
                    }).ToList();
                shoevm.Size = serviceS!
                    .GetAll()
                    .Select(s => new SelectListItem
                    {
                        Text = s.sizeNumber.ToString(),
                        Value = s.SizeId.ToString()
                    }).ToList();
            }
            else
            {
                try
                {
                    ShoeSize? s = service!.Get(c => c.ShoeSizeId == id.Value,
                            propertiesNames: "Shoe,Size");
                    if (s == null)
                    {
                        return NotFound();
                    }
                    s.Shoe = null;
                   s.Size = null;
                    shoevm = _mapper!.Map<ShoeSizeEditVm>(s);

                    shoevm.Shoe = serviceB!
                        .GetAll(orderBy: q => q.OrderBy(c => c.Descripcion))
                        .Select(c => new SelectListItem
                        {
                            Text = c.Descripcion,
                            Value = c.BrandId.ToString()
                        }).ToList();
                    shoevm.Size = serviceS!
                        .GetAll()
                        .Select(s => new SelectListItem
                        {
                            Text = s.sizeNumber.ToString(),
                            Value = s.SizeId.ToString()
                        }).ToList();

                    return View(shoevm);
                }
                catch (Exception)
                {
                    // Log the exception (ex) here as needed
                    return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving the record.");
                }

            }
            shoevm.Shoe = serviceB
                .GetAll(orderBy: q => q.OrderBy(c => c.Descripcion))
                .Select(c => new SelectListItem
                {
                    Text = c.Descripcion,
                    Value = c.ShoeId.ToString()
                }).ToList();
            shoevm.Size = serviceS
                .GetAll(orderBy: q => q.OrderBy(c => c.sizeNumber.ToString()))
                .Select(s => new SelectListItem
                {
                    Text = s.sizeNumber.ToString(),
                    Value = s.SizeId.ToString()
                }).ToList();
         
            return View(shoevm);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult UpSert1(ShoeSizeEditVm shoVm)
        {
            if (!ModelState.IsValid)
            {
                shoVm.Shoe = serviceB!
                                   .GetAll(orderBy: q => q.OrderBy(c => c.Descripcion))
                                   .Select(c => new SelectListItem
                                   {
                                       Text = c.Descripcion,
                                       Value = c.ShoeId.ToString()
                                   }).ToList();
                shoVm.Size = serviceS!
                                  .GetAll(orderBy: q => q.OrderBy(c => c.sizeNumber.ToString()))
                                  .Select(c => new SelectListItem
                                  {
                                      Text = c.sizeNumber.ToString(),
                                      Value = c.SizeId.ToString()
                                  }).ToList();
           
                return View(shoVm);
            }

            if (service == null || _mapper == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Dependencias no están configuradas correctamente");
            }

            try
            {
                ShoeSize SVm = _mapper.Map<ShoeSize>(shoVm);

                if (service.existe(SVm))
                {
                    shoVm.Shoe = serviceB!
                                 .GetAll(orderBy: q => q.OrderBy(c => c.Descripcion))
                                 .Select(c => new SelectListItem
                                 {
                                     Text = c.Descripcion,
                                     Value = c.ShoeId.ToString()
                                 }).ToList();
                    shoVm.Size = serviceS!
                                      .GetAll(orderBy: q => q.OrderBy(c => c.sizeNumber.ToString()))
                                      .Select(c => new SelectListItem
                                      {
                                          Text = c.sizeNumber.ToString(),
                                          Value = c.SizeId.ToString()
                                      }).ToList();

                    return View(shoVm);
                }

                service.Agregar(SVm);
                TempData["success"] = "Record successfully added/edited";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                shoVm.Shoe = serviceB!
                              .GetAll(orderBy: q => q.OrderBy(c => c.Descripcion))
                              .Select(c => new SelectListItem
                              {
                                  Text = c.Descripcion,
                                  Value = c.ShoeId.ToString()
                              }).ToList();
                shoVm.Size = serviceS!
                                  .GetAll(orderBy: q => q.OrderBy(c => c.sizeNumber.ToString()))
                                  .Select(c => new SelectListItem
                                  {
                                      Text = c.sizeNumber.ToString(),
                                      Value = c.SizeId.ToString()
                                  }).ToList();
    
                // Log the exception (ex) here as needed
                ModelState.AddModelError(string.Empty, "An error occurred while editing the record.");
                return View(shoVm);
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
            ShoeSize? category= service?.GetShoeSizePorId(id.Value);
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
