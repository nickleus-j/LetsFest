using AutoMapper;
using Humanizer;
using LetsFest.Data.Dto;
using LetsFest.Data.Entity;
using LetsFest.Mysql;
using LetsFest.Web.DataService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LetsFest.Web.Controllers
{
    [Authorize]
    public class EventsController : Controller
    {
        private readonly FestContext _context;
        private EventService service;
        public EventsController(FestContext context)
        {
            _context = context;
            service=new EventService(context);
        }

        // GET: Events
        public async Task<IActionResult> Index()
        {
            EfUnitOfWork efWorkUnit = new EfUnitOfWork(_context);
            var claimsIdentity = User.Identity as ClaimsIdentity;
            if (claimsIdentity != null)
            {
                return View(await service.GetEventsOfUserAsync(claimsIdentity));
            }
            return NotFound();
        }
        public async Task<IActionResult> EventsIn(int locationId)
        {
            EfUnitOfWork efWorkUnit = new EfUnitOfWork(_context);
            return View("Index", await efWorkUnit.EventRepository.GetEventsOfFutureLocationAsync(locationId));
        }
        // GET: Events/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var dto = await service.GetEventDtoWithId(id.Value);
            return View(dto);
        }

        // GET: Events/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Events/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EventID,Title,Description,InitiatorId,inUse,isPublic,ProposedStartDateTime,ProposedEndDateTime,CreatedOn")] EventCreateEditDto dto)
        {
            int result=service.CreateFromDto(dto, User.FindFirstValue(ClaimTypes.NameIdentifier));
            return RedirectToAction(nameof(Index));
        }

        // GET: Events/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var dto = await service.GetEventDtoWithId(id.Value);
            return View(dto);
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, EventCreateEditDto dto)
        {
            if (id != dto.EventID)
            {
                return NotFound();
            }

            await service.UpdateEventFromDto(dto);
            return RedirectToAction(nameof(Index));
        }

        // GET: Events/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Event
                .FirstOrDefaultAsync(m => m.EventID == id);
            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var @event = await _context.Event.FindAsync(id);
            if (@event != null)
            {
                _context.Event.Remove(@event);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventExists(long id)
        {
            return _context.Event.Any(e => e.EventID == id);
        }
    }
}
