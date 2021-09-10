using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MedicineShop.Models;
using Microsoft.AspNetCore.Cors;
using MedicineShop.Models.ViewModels;
using System.IO;

namespace MedicineShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[EnableCors("AllowAnyOrigin")]
    public class MedicinesController : ControllerBase
    {
        private readonly MedicneDbContext _context;

        public MedicinesController(MedicneDbContext context)
        {
            _context = context;
        }

        // GET: api/Medicines
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Medicine>>> GetMedicines()
        {
            return await _context.Medicines.ToListAsync();
        }

        // GET: api/Medicines/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Medicine>> GetMedicine(int id)
        {
            var medicine = await _context.Medicines.FindAsync(id);

            if (medicine == null)
            {
                return NotFound();
            }

            return medicine;
        }

        // PUT: api/Medicines/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMedicine(int id, Medicine medicine)
        {
            if (id != medicine.Id)
            {
                return BadRequest();
            }

            _context.Entry(medicine).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedicineExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Medicines
        [HttpPost]
        public async Task<ActionResult<Medicine>> PostMedicine(Medicine medicine)
        {
            _context.Medicines.Add(medicine);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMedicine", new { id = medicine.Id }, medicine);
        }

        //[HttpPost, Route("api/Create")]
        //public IActionResult Create(MedicineViewModel mvm)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    Medicine app = new Medicine { MedicineName = mvm.MedicineName, ExpireDate = mvm.ExpireDate, GenericGroupId=mvm.GenericGroupId,UnitPrice=mvm.UnitPrice };
        //    string fileName = "";
        //    if (mvm.Image == "image/jpeg") fileName = Guid.NewGuid() + ".jpeg";
        //    if (mvm.Image == "image/jpg") fileName = Guid.NewGuid() + ".jpg";
        //    if (mvm.Image == "image/png") fileName = Guid.NewGuid() + ".png";
        //    if (mvm.Image == "image/gif") fileName = Guid.NewGuid() + ".gif";

        //    byte[] bytes = Convert.FromBase64String(mvm.ImagePath);
        //    //FileStream fs = new FileStream(Path.Combine(HttpContext.Current.Server.MapPath("~/Images"), fileName), FileMode.Create);
        //    //fs.Write(bytes, 0, bytes.Length);
        //    //fs.Close();
        //    File.WriteAllBytes
        //    File.WriteAllBytes(Path.Combine(HttpContext.Current.Server.MapPath("~/wwwroot/Images"), fileName), bytes);
        //    app.Picture = fileName;
        //    db.Applicants.Add(app);
        //    db.SaveChanges();

        //    return Ok(app);
        //}



        // DELETE: api/Medicines/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Medicine>> DeleteMedicine(int id)
        {
            var medicine = await _context.Medicines.FindAsync(id);
            if (medicine == null)
            {
                return NotFound();
            }

            _context.Medicines.Remove(medicine);
            await _context.SaveChangesAsync();

            return medicine;
        }

        private bool MedicineExists(int id)
        {
            return _context.Medicines.Any(e => e.Id == id);
        }
    }
}
