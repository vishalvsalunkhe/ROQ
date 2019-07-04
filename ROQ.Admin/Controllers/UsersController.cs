using AutoMapper;
using ROQ.Admin.Helpers;
using ROQ.Common.Security;
using ROQ.Data.Entities;
using ROQ.Services.Interfaces;
using ROQ.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ROQ.Admin.Controllers
{
    public class UsersController : Controller
    {
        IUserService _IUserService;

        IMapper iMapper;
        public UsersController(IUserService iUserService)
        {
            _IUserService = iUserService;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Users, UsersVM>();
            });
            iMapper = config.CreateMapper();
        }
        public ActionResult Edit(int id)
        {
            //LogAction(this, "Information", $"Edit(id={id}) Accessed");

            //var authCookie = FormAutheticationHelper.GetUserDataFromCookie();
            //if (authCookie == null)
            //{
            //    //Logging.log(LogType.INFO, "UnauthorizedAccessException", authCookie);
            //    return RedirectToAction("login", "account");
            //}
            var model = _IUserService.Get(id);
            var modelVM = iMapper.Map<Users, UsersVM>(model);
            Dictionary<string, string> genders = CommonHelper.GetGenders();
            ViewBag.Genders = new SelectList(genders, "key", "value");
            return View("Create", modelVM);
        }
        // GET: Users
        public ActionResult Index()
        {
            try
            {
                var users = _IUserService.GetAll().ToList();
                // iMapper.Map<AuthorModel, AuthorDTO>(source);
                var usersVM = iMapper.Map<List<Users>, List<UsersVM>>(users);
                return View(usersVM);
            }
            catch (Exception)
            {
                throw;
            }

        }
        [HttpGet]
        public JsonResult Delete(long ID)
        {
            //LogAction(this, "Information", $"Delete(id={ID}) Accessed");

            //var authCookie = FormAutheticationHelper.GetUserDataFromCookie();
            //if (authCookie == null)
            //{
            //    //Logging.log(LogType.INFO, "UnauthorizedAccessException", authCookie);
            //    return Json(new { code = -1, Message = "You are not authorised.Try to login again" }, JsonRequestBehavior.AllowGet);

            //}
            try
            {
                var model = _IUserService.Get(ID);
                if (model != null)
                {
                    _IUserService.Delete((int)ID);
                    _IUserService.Save();
                }
            }
            catch (Exception ex)
            {

                return Json(new { code = -1, Message = "Something went wrong.Try again!!!" }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { code = 1, Message = "Record deleted Successfully." }, JsonRequestBehavior.AllowGet);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            Dictionary<string, string> genders = CommonHelper.GetGenders();
            ViewBag.Genders = new SelectList(genders, "key", "value");
            return View(new UsersVM { IsActive = true });
        }

        [HttpPost]
        public ActionResult InsertUpdate(UsersVM usersViewModel)
        {
            //LogAction(this, "Information", $"InsertUpdate() Accessed");
            long id = 0;
            //var authCookie = FormAutheticationHelper.GetUserDataFromCookie();
            //if (authCookie == null)
            //{
            //    //Logging.log(LogType.INFO, "UnauthorizedAccessException", authCookie);
            //    return RedirectToAction("login", "account");
            //}

            try
            {
                var countOfUsers = _IUserService.GetAll()?.Count(a => a.ID != usersViewModel.ID && a.UserName.Trim().Equals(usersViewModel.UserName.Trim(), StringComparison.InvariantCultureIgnoreCase)) ?? 0;
                if (countOfUsers > 0)
                {
                    return Json(new { code = -1, Message = $"Same User Name is already Exist {usersViewModel.UserName}" }, JsonRequestBehavior.AllowGet);
                }
                if (usersViewModel.ID > 0)
                    usersViewModel.ModifiedBy = 1;//.ToInt32(authCookie?.UserId);
                else
                {
                    usersViewModel.CreatedBy = 1;// Convert.ToInt32(authCookie?.UserId);
                    usersViewModel.Password = EncryptionDecryption.Encrypt("Password@123", true);//Create default password for intial
                }
                id = _IUserService.InsertUpdate(usersViewModel);
            }
            catch (Exception ex)
            {
                return Json(new { code = -1, Message = "Something went wrong.Try again!!!" }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { code = id, Message = "Changes has been saved Successfully" }, JsonRequestBehavior.AllowGet);
        }
    }
}
