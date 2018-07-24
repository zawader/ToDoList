using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Web;
using System.Web.Mvc;
using ToDoList.App.Interface;
using ToDoList.Domain.Entities;
using ToDoList.MVC.ModelsView;

namespace ToDoList.MVC.Controllers
{
    public class TarefasController : Controller
    {
        private readonly IToDoAppService _toDoAppService;
        public TarefasController(IToDoAppService toDoAppService)
        {
            _toDoAppService = toDoAppService;
        }

        public ActionResult Index()
        {
            var toDoViewModel = Mapper.Map<IEnumerable<ToDo>, IEnumerable<ToDoViewModel>>(_toDoAppService.GetAll());
            return View(toDoViewModel);
        }


        public PartialViewResult Criar()
        {
            return PartialView(new ToDoViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Criar(ToDoViewModel _toDoViewModel)
        {
            if(ModelState.IsValid)
            {
                var toDo = Mapper.Map<ToDoViewModel, ToDo>(_toDoViewModel);
                _toDoAppService.Add(toDo);
                return RedirectToAction("index");
            }

            return View();
        }

        public PartialViewResult Detalhes(int? id)
        {
            var toDoViewModel = Mapper.Map<ToDo, ToDoViewModel>(_toDoAppService.GetById(id.Value));
            return PartialView(toDoViewModel);
        }

        public PartialViewResult Editar(int? id)
        {
            var toDoViewModel = Mapper.Map<ToDo, ToDoViewModel>(_toDoAppService.GetById(id.Value));
            return PartialView(toDoViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(int? id, ToDoViewModel toDoViewModel)
        {
            if(ModelState.IsValid)
            {
                var toDo = Mapper.Map<ToDoViewModel, ToDo>(toDoViewModel);
                toDo.UpdateDate = DateTime.Now;
                _toDoAppService.Update(toDo);
                return RedirectToAction("index");
            }            

            return PartialView(toDoViewModel);
        }

        public PartialViewResult Deletar(int? id)
        {
            var toDoViewModel = Mapper.Map<ToDo, ToDoViewModel>(_toDoAppService.GetById(id.Value));
            return PartialView(toDoViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Deletar(int? id,string teste)
        {
            _toDoAppService.RemoveById(id.Value);
            return RedirectToAction("index");
        }

        public JsonResult GetAll(string searchPhrase,int current, int rowCount)
        {
            string chave = Request.Form.AllKeys.Where(k => k.StartsWith("sort")).First();
            var ordenacao = Request[chave];
            var campo = chave.Replace("sort[", String.Empty).Replace("]", String.Empty);

            var toDoList = _toDoAppService.GetAll().OrderBy(String.Format("{0} {1}", campo, ordenacao));

            if (!String.IsNullOrEmpty(searchPhrase.Trim()))
            {
                toDoList = toDoList.Where("Title.Contains(@0) OR Description.Contains(@0)", searchPhrase);
            }

            var resultado = new
            {
                rows = toDoList.Skip((current - 1) * rowCount).Take(rowCount),
                current = current,
                rowCount = rowCount,
                total = toDoList.Count()
            };
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
    }
}
