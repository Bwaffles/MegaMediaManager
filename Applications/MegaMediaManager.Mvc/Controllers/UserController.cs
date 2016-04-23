using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Infrastructure;
using MegaMediaManager.DAL;
using MegaMediaManager.Model;
using MegaMediaManager.Mvc.Models;
using AutoMapper;
using System.Net;
using MegaMediaManager.Model.Repositories;
using System.Threading.Tasks;

namespace MegaMediaManager.Mvc.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserRepository UserRepository;
        
        /// <summary>
        /// Initializes a new instance of the UserController class.
        /// </summary>
        public UserController(IUserRepository userRepository, IUnitOfWorkFactory unitOfWorkFactory)
            : base(unitOfWorkFactory)
        {
            UserRepository = userRepository;
        }

        //
        // GET: /User/Details/5
        public async Task<ActionResult> Details(string userName)
        {
            if(string.IsNullOrEmpty(userName))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Invalid username");
            }
            User user = await UserRepository.FindByUserNameAsync(userName);
            if(user == null)
            {
                return HttpNotFound();
            }
            var data = new DisplayUser();
            Mapper.Map(user, data);
            return View(data);
        }

        //
        // GET: /User/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
