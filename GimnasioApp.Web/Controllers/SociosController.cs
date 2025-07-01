using GimnasioApp.Application.DTOs;
using GimnasioApp.Application.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;

namespace GimnasioApp.Web.Controllers
{
    public class SociosController : Controller
    {
        private readonly ISocioService _socioService;
        private readonly IMapper _mapper;

        public SociosController(ISocioService socioService, IMapper mapper)
        {
            _socioService = socioService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var socios = await _socioService.GetAllSociosAsync();
            return View(socios);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var socio = await _socioService.GetSocioByIdAsync(id.Value);
            if (socio == null)
            {
                return NotFound();
            }
            return View(socio);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(SocioCreateDTO socioDto)
        {
            if (ModelState.IsValid)
            {
                await _socioService.CreateSocioAsync(socioDto);
                return RedirectToAction(nameof(Index));
            }
            return View(socioDto);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var socio = await _socioService.GetSocioByIdAsync(id.Value);
            if (socio == null)
            {
                return NotFound();
            }

            var socioUpdateDto = _mapper.Map<SocioUpdateDTO>(socio);
            return View(socioUpdateDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(int id, SocioUpdateDTO socioDto)
        {
            if (id != socioDto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _socioService.UpdateSocioAsync(socioDto);
                }
                catch (KeyNotFoundException)
                {
                    if (await _socioService.GetSocioByIdAsync(socioDto.Id) == null)
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
            return View(socioDto);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var socio = await _socioService.GetSocioByIdAsync(id.Value);
            if (socio == null)
            {
                return NotFound();
            }
            return View(socio);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _socioService.DeleteSocioAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}