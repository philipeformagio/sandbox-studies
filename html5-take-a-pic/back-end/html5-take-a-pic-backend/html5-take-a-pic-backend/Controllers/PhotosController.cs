using html5_take_a_pic_backend.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Drawing;
using System.IO;

namespace html5_take_a_pic_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotosController : ControllerBase
    {
        private IHostingEnvironment _env;
        public PhotosController(IHostingEnvironment env)
        {
            _env = env;
        }


        [HttpPost]
        [DisableRequestSizeLimit]
        public void Post([FromBody] Photo photo)
        {
            var photoName = DateTime.Now.ToString();

            var webRoot = _env.ContentRootPath;
            var PathWithFolderName = System.IO.Path.Combine(webRoot, "PhotosDirectory");

            byte[] bytes = Convert.FromBase64String(photo.Base64Image);

            Image image;
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                using (image = Image.FromStream(ms))
                {
                    image.Save(PathWithFolderName + "/ImageName.png");
                }
            }
        }
    }
}