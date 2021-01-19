using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CRUD.Models;
using System.Web.Mvc;
using CRUD.Models.ViewModels;

namespace CRUD.Controllers
{
    public class usersController : Controller
    {
        // GET: users
        public ActionResult Index()
        {
            List<listuserViewModel> lst;
            using (PCRUDEntities db = new PCRUDEntities())
            {
                lst = (from d in db.users
                       select new listuserViewModel
                       {
                           id = d.id,
                           email = d.email,
                           password = d.password
                       }).ToList();
            }



            return View(lst);
        }
         public ActionResult Nuevo()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Nuevo(UserViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using(PCRUDEntities db = new PCRUDEntities())
                    {
                        var ouser = new users();
                        ouser.email = model.email;
                        ouser.password = model.password;

                        db.users.Add(ouser);
                        db.SaveChanges();
                    }
                    return Redirect("~/users/index");
                }

                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ActionResult Editar(int id)
        {
            UserViewModel model = new UserViewModel();
            using (PCRUDEntities db= new PCRUDEntities())
            {
                var ouser = db.users.Find(id);
                model.email = ouser.email;
                model.password = ouser.password;
                model.id = ouser.id;
            }
                return View();
        }
        [HttpPost]
        public ActionResult Editar(UserViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (PCRUDEntities db = new PCRUDEntities())
                    {
                        var ouser = db.users.Find(model.id);
                        ouser.email = model.email;
                        ouser.password = model.password;

                        db.Entry(ouser).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    return Redirect("~/users/index");
                }

                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            
            using (PCRUDEntities db = new PCRUDEntities())
            {
                
                var ouser = db.users.Find(id);
                db.users.Remove(ouser);
                    db.SaveChanges();
            }
            return Redirect("~/users/index");
        }

    }
}