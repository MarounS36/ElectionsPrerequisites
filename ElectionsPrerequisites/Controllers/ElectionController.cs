using AutoMapper;
using ElectionsPrerequisites.Models;
using ElectionsPrerequisites.Models.Dto;
using ElectionsPrerequisites.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Reflection;

namespace ElectionsPrerequisites.Controllers
{
    public class ElectionController : Controller
    {
        public readonly IElectionService _electionService;
        private readonly IMapper _mapper;
        public ElectionController(IElectionService electionService, IMapper mapper)
        {
            _electionService = electionService;
            _mapper = mapper;
        }

        public async Task<IActionResult> IndexElection()
        {
            List<ElectionDTO> list = new();

            var response = await _electionService.GetAllAsync<APIResponse>();
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<ElectionDTO>>(Convert.ToString(response.Result));
            }
            return View(list);
        }
        public async Task<IActionResult> CreateElection()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateElection(ElectionCreateDTO model)
        {
            if (ModelState.IsValid)
            {
                var response = await _electionService.CreateAsync<APIResponse>(model);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(IndexElection));
                }
            }
            return View(model);

        }
        public async Task<IActionResult> UpdateElection(int electionID)
        {
            var response = await _electionService.GetAsync<APIResponse>(electionID);
            if (response != null && response.IsSuccess)
            {
                ElectionDTO model = JsonConvert.DeserializeObject<ElectionDTO>(Convert.ToString(response.Result));
                return View(_mapper.Map<ElectionUpdateDTO>(model));
            }
            return NotFound();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateElection(ElectionUpdateDTO model)
        {
            if (ModelState.IsValid)
            {
                var response = await _electionService.UpdateAsync<APIResponse>(model);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(IndexElection));
                }
            }
            return View(model);

        }
        public async Task<IActionResult> DeleteElection(int electionID)
        {
            var response = await _electionService.GetAsync<APIResponse>(electionID);
            if (response != null && response.IsSuccess)
            {
                ElectionDTO model = JsonConvert.DeserializeObject<ElectionDTO>(Convert.ToString(response.Result));
                return View(model);
            }
            return NotFound();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteElection(ElectionDTO model)
        {
           
            
                var response = await _electionService.DeleteAsync<APIResponse>(model.Id);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(IndexElection));
                }
            
            return View(model);

        }
    }
}
