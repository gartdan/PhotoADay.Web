using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using PhotoADay.Data;
using System.IO;

namespace PhotoADay.Web.Controllers
{
    [HandleError]
    [Authorize]
    public class PhotoController : Controller
    {
        private IPhotoRepository _repository;

        public PhotoController(IPhotoRepository repository)
        {
            this._repository = repository;
        }

        public ActionResult Index()
        {
            var photos = _repository.GetAll().ToList();
            return View(photos);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Upload(Photo photo, HttpPostedFileBase file)
        {
            if (ModelState.IsValid) {
                if (file != null && file.ContentLength > 0) {
                    photo.Href = SaveFile(file);
                    photo.ContentLength = file.ContentLength;
                    photo.ContentType = file.ContentType;
                    photo.User = this.User.Identity.Name;
                    photo.DateAdded = DateTime.UtcNow;
                    photo.FileName = file.FileName;
                    _repository.Add(photo);

                }
            }
            else {
                return View(photo);
            }
            return RedirectToAction("Index");
        }

        public string SaveFile(HttpPostedFileBase file)
        {
            var directory = Server.MapPath(Constants.FileUploadRootDir + "/" + this.User.Identity.Name);
            var fileName = Path.GetFileName(file.FileName);
            var virtualPath = Constants.FileUploadRootDir + "/" + this.User.Identity.Name + "/" + fileName;
            if(!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            
            var path = Path.Combine(directory, fileName);
            file.SaveAs(path);
            return virtualPath;

        }

        public ActionResult Edit(int id)
        {
            return View();
        }

        


    }
}
