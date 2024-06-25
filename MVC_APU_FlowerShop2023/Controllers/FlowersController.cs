using Microsoft.AspNetCore.Mvc;
using MVC_APU_FlowerShop2023.Models;
using MVC_APU_FlowerShop2023.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.IO;
using Amazon;
using Amazon.S3;
using Amazon.S3.Model;



namespace MVC_APU_FlowerShop2023.Controllers
{
    public class FlowersController : Controller
    {
        private readonly MVC_APU_FlowerShop2023Context _context;
        public FlowersController(MVC_APU_FlowerShop2023Context context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            List<Flower> flowers = await _context.FlowerTable.ToListAsync();
            return View(flowers);
        }


        public IActionResult AddData ()

        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> AddData(Flower flower)
        {
            if (ModelState.IsValid)
            {
                _context.Add(flower);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(flower);
        }

        public async Task<IActionResult> UpdateData(Flower flower)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.FlowerTable.Update(flower);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index", "Flowers");
                }
                return View("EditData", flower);
            }
            catch (Exception ex)
            {
                return BadRequest("Error: " + ex.Message);
            }
        }


        //load an update page for the user
        public async Task<IActionResult> EditData(int? FlowerID)
        {
            if (FlowerID == null)
            {
                return NotFound();
            }
            var flower = await _context.FlowerTable.FindAsync(FlowerID);
            if (flower == null)
            {
                return BadRequest(FlowerID + " is not found in the table!");
            }
            return View(flower);
        }

        //delete data from the page
        public async Task<IActionResult> DeleteData(int? FlowerID)
        {
            if (FlowerID == null)
            {
                return NotFound();
            }
            var flower = await _context.FlowerTable.FindAsync(FlowerID);
            if (flower == null)
            {
                return BadRequest(FlowerID + " is not found in the list!");
            }
            _context.FlowerTable.Remove(flower);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Flowers");
        }



    }
}
