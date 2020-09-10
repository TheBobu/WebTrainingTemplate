using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebTrainingTemplate.DataProviders.Managers.Interfaces;
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

        private readonly IEntityManager _entityManager;
        private readonly IHtmlHelper _htmlHelper;

        public EntityController(IEntityManager entityManager, IHtmlHelper htmlHelper)
        {
            this._entityManager = entityManager;
            this._htmlHelper = htmlHelper;
        }

        [Route("Entity/List/{page?}")]
        public IActionResult List(int page = 1, string info = "")
        {
            EntityListViewModel EntityListViewModel = new EntityListViewModel();
            EntityListViewModel.Entities = _entityManager.GetRange(nrOfItemsOnPage, page, info);
            EntityListViewModel.NrOfPages = (int)Math.Ceiling((decimal)_entityManager.GetNumberOfEntities(info) / nrOfItemsOnPage);
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
                int EntityId = _entityManager.Create(Entity);
                return RedirectToAction("Details", new { id = EntityId });
            }

            return RedirectToAction("Insert");
        }

        public IActionResult Details(int id)
        {
            EntityDetailsViewModel EntityDetailsViewModel = new EntityDetailsViewModel();
            EntityDetailsViewModel.Entity = _entityManager.GetById(id);

            if (EntityDetailsViewModel.Entity == null)
            {
                return RedirectToAction("PageNotFound");
            }

            return View(EntityDetailsViewModel);
        }

        public IActionResult Delete(int id)
        {
            _entityManager.Delete(id);
            return RedirectToAction("List");
        }

        public IActionResult Update(int id)
        {
            EntityUpdateViewModel EntityUpdateViewModel = new EntityUpdateViewModel();
            EntityUpdateViewModel.Entity = _entityManager.GetById(id);

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
                var EntityId = _entityManager.Update(Entity);
                return RedirectToAction("Details", new { id = EntityId });
            }

            return View(EntityUpdateViewModel);
        }

        public IActionResult PageNotFound()
        {
            return View("_PageNotFound");
        }
    }
}
