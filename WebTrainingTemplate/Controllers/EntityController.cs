using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebTrainingTemplate.Web.ViewModels;

namespace WebTrainingTemplate.Web.Controllers
{
    public class EntityController : Controller
    {
        /// <summary>
        /// Template for Entity Controller with the basic actions
        /// Use the IEntityManager to access data
        /// </summary>

        private const int nrOfItemsOnPage = 10;

       // private readonly IEntityManager EntityManager;
        private readonly IHtmlHelper htmlHelper;

        public EntityController(/*IEntityManager EntityManager,*/ IHtmlHelper htmlHelper)
        {
           // this.EntityManager = EntityManager;
            this.htmlHelper = htmlHelper;
        }

        [Route("Entity/List/{page?}")]
        public IActionResult List(int page = 1, string info = "")
        {
            EntityListViewModel EntityListViewModel = new EntityListViewModel();
           // EntityListViewModel.Entities = EntityManager.GetRange(nrOfItems, page, info);
           // EntityListViewModel.NrOfPages = (int)Math.Ceiling((decimal)EntityManager.GetNumberOfEntitys(info) / nrOfItems);
            EntityListViewModel.CurrentPage = page;

            ViewBag.info = info;

            return View(EntityListViewModel);
        }

        public IActionResult Create()
        {
            EntityCreateViewModel EntityCreateViewModel = new EntityCreateViewModel();

            return View(EntityCreateViewModel);
        }

        [HttpPost]
        public IActionResult Insert(EntityCreateViewModel EntityViewModel)
        {
            var Entity = EntityViewModel.Entity;
            if (ModelState.IsValid)
            {
              //  int EntityId = EntityManager.Insert(Entity);
               // return RedirectToAction("Details", new { id = EntityId });
            }

            return RedirectToAction("Insert");
        }

        public IActionResult Details(int id)
        {
            EntityDetailsViewModel EntityDetailsViewModel = new EntityDetailsViewModel();
           // EntityDetailsViewModel.Entity = EntityManager.GetById(id);

            if (EntityDetailsViewModel.Entity == null)
            {
                return RedirectToAction("PageNotFound");
            }

            return View(EntityDetailsViewModel);
        }

        public IActionResult Delete(int id)
        {
           // EntityManager.Delete(id);
            return RedirectToAction("List");
        }

        public IActionResult Update(int id)
        {
            EntityUpdateViewModel EntityUpdateViewModel = new EntityUpdateViewModel();
           // EntityUpdateViewModel.Entity = EntityManager.GetById(id);

            if (EntityUpdateViewModel.Entity == null)
            {
                return RedirectToAction("PageNotFound");
            }

            return View(EntityUpdateViewModel);
        }

        [HttpPost]
        public IActionResult Update(EntityUpdateViewModel EntityUpdateViewModel)
        {
            var Entity = EntityUpdateViewModel.Entity;

            if (ModelState.IsValid)
            {
               // var EntityId = EntityManager.Update(Entity);
               // return RedirectToAction("Details", new { id = EntityId });
            }

            return View(EntityUpdateViewModel);
        }

        public IActionResult PageNotFound()
        {
            return View("_PageNotFound");
        }
    }
}
