using Project_ComData.DataModel;
using Project_ComData.Models;
using System.Web.Mvc;
using System.Linq;
using Newtonsoft.Json;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Project_ComData.Controllers
{

    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UserController : Controller
    {
       

        public JsonResult RegisterUser([FromBody]User u)
        {
            var repo = new UserRepo();
            if (repo.ValidateRegister(u))
            {
                return Json(repo.Register(u));
            }
            return Json(false);
        }


        public JsonResult LoginUser([FromBody]User u)
        {
            var repo = new UserRepo();
            if (repo.Validate(u))
            {
                return Json(repo.Login(u));
            }
            return Json(false);
        }

        public JsonResult GetUsers()
        {
            var repo = new UserRepo().GetAll();
            return Json(repo, JsonRequestBehavior.AllowGet);
        }
        [System.Web.Http.HttpPost]
        public JsonResult EditUser([FromBody]User u)
        {
            var repo = new UserRepo();
            if (repo.ValidateRegister(u))
            {
                return Json(repo.EditUser(u));
            }
            return Json(false);
        }
        public void DeleteUser([FromBody]User u)
        {
            var repo = new UserRepo();
            repo.DeleteUser(u);

        }
    }
}
