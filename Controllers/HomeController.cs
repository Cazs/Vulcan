using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Vulcan.Models;

namespace Vulcan.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Import()
        {
            return View();
        }

        /*[HttpPost]
        public ActionResult CreateForm(VulcanTransaction membervalues)
        {
            //Use Namespace called :  System.IO  
            string FileName = Path.GetFileNameWithoutExtension(membervalues.CsvFile.FileName);

            //To Get File Extension  
            string FileExtension = Path.GetExtension(membervalues.CsvFile.FileName);

            //Add Current Date To Attached File Name  
            FileName = DateTime.Now.ToString("yyyyMMdd") + "-" + FileName.Trim() + FileExtension;

            //Get Upload path from Web.Config file AppSettings.  
            /*string UploadPath = ConfigurationManager.AppSettings["UserImagePath"].ToString();

            //Its Create complete path to store in server.  
            membervalues.ImagePath = UploadPath + FileName;

            //To copy and save file into server.  
            membervalues.ImageFile.SaveAs(membervalues.ImagePath);


            //To save Club Member Contact Form Detail to database table.  
            var db = new ClubMemberDataClassesDataContext();

            tblMember _member = new tblMember();

            _member.ImagePath = membervalues.ImagePath;
            _member.MemberName = membervalues.Name;
            _member.PhoneNumber = membervalues.PhoneNumber;

            db.tblMembers.InsertOnSubmit(_member);
            db.SubmitChanges();*

            return View();
        }*/

        /*[HttpPost("UploadFiles")]
        public async Task<IActionResult> CreateForm(List<IFormFile> files)*/
        [HttpPost]
        public IActionResult CreateForm(IFormFile CsvFile)
        {
            long size = CsvFile.Length;
            System.Console.WriteLine("File Size: " + size);

            // full path to file in temp location
            /*var filePath = Path.GetTempFileName();

            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await formFile.CopyToAsync(stream);
                    }
                }
            }

            // process uploaded files
            // Don't rely on or trust the FileName property without validation.

            return Ok(new { count = files.Count, size, filePath });*/
            return View(); // View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}