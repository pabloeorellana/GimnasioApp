using GimnasioApp.Application.DTOs;
using GimnasioApp.Application.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;

namespace GimnasioApp.Web.Controllers
{
    public class ClasesController : Controller
    {
        private readonly IClaseService _claseService;
        private readonly IMapper _mapper;

        public ClasesController(IClaseService claseService, IMapper mapper)
        {
            _claseService = claseService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var clases = await _claseService.GetAllClasesAsync();
            return View(clases);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clase = await _claseService.GetClaseByIdAsync(id.Value);
            if (clase == null)
            {
                return NotFound();
            }
            return View(clase);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ClaseCreateDTO claseDto)
        {
            if (ModelState.IsValid)
            {
                await _claseService.CreateClaseAsync(claseDto);
                return RedirectToAction(nameof(Index));
            }
            return View(claseDto);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clase = await _claseService.GetClaseByIdAsync(id.Value);
            if (clase == null)
            {
                return NotFound();
            }
            var claseUpdateDto = _mapper.Map<ClaseUpdateDTO>(clase);
            return View(claseUpdateDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ClaseUpdateDTO claseDto)
        {
            if (id != claseDto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _claseService.UpdateClaseAsync(claseDto);
                }
                catch (KeyNotFoundException)
                {
                    if (await _claseService.GetClaseByIdAsync(claseDto.Id) == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                catch (System.Exception)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(claseDto);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clase = await _claseService.GetClaseByIdAsync(id.Value);
            if (clase == null)
            {
                return NotFound();
            }
            return View(clase);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _claseService.DeleteClaseAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}