﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using X.PagedList.Extensions;
using MvcFerro.Servicios.Interfaces;
using MvcFerro01.Entidades;
using MvcFerro01.ViewModels.Shoe.ShoeListVm;
using MvcFerro01.ViewModels.Shoe.ShoeEditVm;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace MvcFerro01.Controllers
{
    public class ShoeController : Controller
    {
        private readonly IServicioShoes? service;
        private readonly IServicioBrands? serviceB;
        private readonly IServicioGenre? serviceG;
        private readonly IServicioSports? serviceS;

        private readonly IMapper? _mapper;
        public ShoeController(IServicioShoes? BService, IServicioBrands b, IServicioGenre g, IServicioSports s,
            IMapper mapper)
        {
            service = BService;
            _mapper = mapper;
            serviceB = b;
            serviceG = g;
            serviceS = s;
        }

        public IActionResult Index(int? page, string? searchTerm = null, bool viewAll = false, int pageSize = 10)
        {

            int pageNumber = page ?? 1;
            ViewBag.currentPageSize = pageSize;
            IEnumerable<Shoes>? shoe;
            if (!viewAll)
            {
                if (!string.IsNullOrEmpty(searchTerm))
                {
                    shoe = service?
                        .GetAll(orderBy: o => o.OrderBy(c => c.Descripcion),
                            filter: c => c.Model.Contains(searchTerm),
                propertiesNames: "Brand,Genre,Sport");

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

                    shoe = service?
                     .GetAll(propertiesNames: "Brand,Genre,Sport");                        
          //  propertiesNames: "Brand,Genre,Sport");


                }

            }
            else
            {
                shoe = service?
                    .GetAll(orderBy: o => o.OrderBy(c => c.Descripcion), propertiesNames: "Brand,Genre,Sport");

            }
                 var BrandVm = _mapper?.Map<List<ShoeListVm>>(shoe)
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
            ShoeEditVm shoevm;
            if (id == null || id == 0)
            {
                shoevm = new ShoeEditVm();
                shoevm.Brand = serviceB!
                    .GetAll(orderBy: q => q.OrderBy(c => c.BrandName))
                    .Select(c => new SelectListItem
                    {
                        Text = c.BrandName,
                        Value = c.BrandId.ToString()
                    }).ToList();
                shoevm.Genre = serviceG!
                    .GetAll()
                    .Select(s => new SelectListItem
                    {
                        Text = s.GenreName,
                        Value = s.GenreId.ToString()
                    }).ToList();
                shoevm.Sport = serviceS!
                   .GetAll()
                   .Select(s => new SelectListItem
                   {
                       Text = s.SportName,
                       Value = s.SportId.ToString()
                   }).ToList();
            }
            else
            {
                try
                {
                    Shoes? s = service!.Get(c => c.ShoeId == id.Value,
                            propertiesNames: "Brand,Genre,Sport");
                    if (s == null)
                    {
                        return NotFound();
                    }
                    s.Brand = null;
                   s.Genre = null;
                    s.Sport = null;
                    shoevm = _mapper!.Map<ShoeEditVm>(s);

                    shoevm.Brand = serviceB!
                        .GetAll(orderBy: q => q.OrderBy(c => c.BrandName))
                        .Select(c => new SelectListItem
                        {
                            Text = c.BrandName,
                            Value = c.BrandId.ToString()
                        }).ToList();
                    shoevm.Genre = serviceG!
                        .GetAll()
                        .Select(s => new SelectListItem
                        {
                            Text = s.GenreName,
                            Value = s.GenreId.ToString()
                        }).ToList();
                    shoevm.Sport = serviceS!
                       .GetAll()
                       .Select(s => new SelectListItem
                       {
                           Text = s.SportName,
                           Value = s.SportId.ToString()
                       }).ToList();

                    return View(shoevm);
                }
                catch (Exception)
                {
                    // Log the exception (ex) here as needed
                    return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving the record.");
                }

            }
            shoevm.Brand = serviceB
                .GetAll(orderBy: q => q.OrderBy(c => c.BrandName))
                .Select(c => new SelectListItem
                {
                    Text = c.BrandName,
                    Value = c.BrandId.ToString()
                }).ToList();
            shoevm.Genre = serviceG
                .GetAll(orderBy: q => q.OrderBy(c => c.GenreName))
                .Select(s => new SelectListItem
                {
                    Text = s.GenreName,
                    Value = s.GenreId.ToString()
                }).ToList();
            shoevm.Sport = serviceS
              .GetAll(orderBy: q => q.OrderBy(c => c.SportName))
              .Select(s => new SelectListItem
              {
                  Text = s.SportName,
                  Value = s.SportId.ToString()
              }).ToList();

            return View(shoevm);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult UpSert(ShoeEditVm shoVm)
        {
            if (!ModelState.IsValid)
            {
                shoVm.Brand = serviceB!
                                   .GetAll(orderBy: q => q.OrderBy(c => c.BrandName))
                                   .Select(c => new SelectListItem
                                   {
                                       Text = c.BrandName,
                                       Value = c.BrandId.ToString()
                                   }).ToList();
                shoVm.Genre = serviceG!
                                  .GetAll(orderBy: q => q.OrderBy(c => c.GenreName))
                                  .Select(c => new SelectListItem
                                  {
                                      Text = c.GenreName,
                                      Value = c.GenreId.ToString()
                                  }).ToList();
                shoVm.Sport = serviceS!
                                      .GetAll(orderBy: q => q.OrderBy(c => c.SportName))
                                      .Select(c => new SelectListItem
                                      {
                                          Text = c.SportName,
                                          Value = c.SportId.ToString()
                                      }).ToList();

                return View(shoVm);
            }

            if (service == null || _mapper == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Dependencias no están configuradas correctamente");
            }

            try
            {
                Shoes SVm = _mapper.Map<Shoes>(shoVm);

                if (service.existe(SVm))
                {
                    shoVm.Brand = serviceB!
                                 .GetAll(orderBy: q => q.OrderBy(c => c.BrandName))
                                 .Select(c => new SelectListItem
                                 {
                                     Text = c.BrandName,
                                     Value = c.BrandId.ToString()
                                 }).ToList();
                    shoVm.Genre = serviceG!
                                      .GetAll(orderBy: q => q.OrderBy(c => c.GenreName))
                                      .Select(c => new SelectListItem
                                      {
                                          Text = c.GenreName,
                                          Value = c.GenreId.ToString()
                                      }).ToList();
                    shoVm.Sport = serviceS!
                                          .GetAll(orderBy: q => q.OrderBy(c => c.SportName))
                                          .Select(c => new SelectListItem
                                          {
                                              Text = c.SportName,
                                              Value = c.SportId.ToString()
                                          }).ToList();

                    return View(shoVm);
                }

                service.Agregar(SVm);
                TempData["success"] = "Record successfully added/edited";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                shoVm.Brand = serviceB!
                              .GetAll(orderBy: q => q.OrderBy(c => c.BrandName))
                              .Select(c => new SelectListItem
                              {
                                  Text = c.BrandName,
                                  Value = c.BrandId.ToString()
                              }).ToList();
                shoVm.Genre = serviceG!
                                  .GetAll(orderBy: q => q.OrderBy(c => c.GenreName))
                                  .Select(c => new SelectListItem
                                  {
                                      Text = c.GenreName,
                                      Value = c.GenreId.ToString()
                                  }).ToList();
                shoVm.Sport = serviceS!
                                      .GetAll(orderBy: q => q.OrderBy(c => c.SportName))
                                      .Select(c => new SelectListItem
                                      {
                                          Text = c.SportName,
                                          Value = c.SportId.ToString()
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
            Shoes? category= service?.GetShoePorId(id.Value);
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
