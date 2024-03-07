using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using portfolio.dbcontext;
using portfolio.Models;
using System.ComponentModel.DataAnnotations;

namespace portfolio.Controllers
{
    
    public class Home : Controller
    {
        IWebHostEnvironment _webHostEnvironment;
        [BindProperty]
        public submitmodel submitmodel { get; set; } = new submitmodel();

        [Key]
        public int id { get; set; }



        private readonly dbcontextf _context;
        public Home(dbcontextf context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        [Authorize]
        public IActionResult about()
        {
            return View();
        }
       
        public IActionResult home()
        {
            return View();
        }
        [Authorize]
        public IActionResult project()
        {
            return View();
        }
        [Authorize]
        public IActionResult contact()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult contactupdate(submitmodel model)
        {
            if (ModelState.IsValid)
            {
                try
                {


                    _context.Update(model);
                    _context.SaveChanges();


                    return View("ContactConfirmation");

                }
                catch (Exception ex)
                {



                    Console.WriteLine(ex.Message);
                    return RedirectToAction("faildSubmit", new { errorMessage = ex.Message });
                }

            }
            return View("contact");

        }
    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult contact(submitmodel model)
        {
            if (ModelState.IsValid)
            {
                try
                {


                    _context.contactFormSubmissions.Add(model);
                    _context.SaveChanges();

                    // ModelState.Clear();

                    return View("ContactConfirmation");

                }
                catch (Exception ex)
                {



                    Console.WriteLine(ex.Message);
                    return RedirectToAction("faildSubmit", new { errorMessage = ex.Message });
                }

            }
            return View("contact");
        }


        [Authorize]
        public IActionResult ContactConfirmation()
        {
            return View();
        }
        [Authorize]
        public IActionResult faildSubmit(string errorMessage)
        {
            ViewBag.ErrorMessage = errorMessage;
            return View();
        }
        
        public IActionResult contactdata()
        {
            var submission = _context.contactFormSubmissions.ToList();

            return View(submission);    
        }

        [Authorize]
        public IActionResult Update(int  id)
        {

          var update=  _context.contactFormSubmissions.Find(id);
            return View(update);

        }


        [HttpPost]
        public IActionResult Update(submitmodel viewmodel)
        {

            if (ModelState.IsValid)
            {


                try
                {


                    var edit = _context.contactFormSubmissions.Find(viewmodel.id);

                    if (edit != null)
                    {

                        edit.name = viewmodel.name;
                        edit.email = viewmodel.email;
                        edit.message = viewmodel.message;

                        _context.SaveChanges();





                        
                    }
                    return NotFound();

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error updating entity:{ex.Message}");

                    return RedirectToAction("Error");

                }


            }

            else
            {
                return View(viewmodel);
            }


        }
        [HttpPost]
       
        public  IActionResult delete(int id)
        {
            
                    var delete =  _context.contactFormSubmissions.Find(id);
                    if (delete != null)
                    {
                        _context.contactFormSubmissions.Remove(delete);
                        _context.SaveChanges();
                        
                        
                    }
                    return RedirectToAction("contactdata");
                }
                
    }
}




