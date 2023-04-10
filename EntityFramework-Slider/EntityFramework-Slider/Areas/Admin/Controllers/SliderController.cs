﻿using EntityFramework_Slider.Data;
using EntityFramework_Slider.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework_Slider.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController : Controller
    {
        private readonly AppDbContext _context;
        public SliderController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Slider> sliders = await _context.Sliders.Where(m => !m.SoftDelete).ToListAsync();
            return View(sliders);
        }


        //Info butona basanda bu actiona yonlenir
        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            //eyer kimse urlden UI-dan yani  id--ni silse seyfe baglansin
            //BadRequest=Exception cixaririq
            if (id == null) return BadRequest();
            Slider? slider = await _context.Sliders.FirstOrDefaultAsync(m => m.Id == id);
            //eyer kimse sehv regem yazibsa Url-e
            //NotFound-tapilmadi deye Exception 
            if(slider == null) return NotFound();
            return View(slider);
        }


        //[HttpGet]-datani goturende 
        [HttpGet]

        public IActionResult Create()    /*async-elemirik cunku data gelmir databazadan*/
        {
           
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return BadRequest();
            Slider? slider = await _context.Sliders.FirstOrDefaultAsync(m => m.Id == id);
           
            if (slider == null) return NotFound();
            return View(slider);
         
        }

    }
}
