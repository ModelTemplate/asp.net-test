﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCWebApp.Data;
using MVCWebApp.Models;
using Newtonsoft.Json;

namespace MVCWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanEventsAPIController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public LoanEventsAPIController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/LoanEvents
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<LoanEvent>>> GetLoans()
        {
            /*List<LoanEvent> loans = _context.Loans.Include("BorrowerName").Include("LoanDate").ToList();
            List<string> jsonLoans = new List<string>();

            foreach(LoanEvent loan in loans)
            {
                jsonLoans.Add(JsonConvert.SerializeObject(loan));
            }*/
            
            return await _context.Loans.ToListAsync();
        }

        // GET: api/LoanEvents/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LoanEvent>> GetLoanEvent(int id)
        {
            var loanEvent = await _context.Loans.FindAsync(id);

            if (loanEvent == null)
            {
                return NotFound();
            }

            return loanEvent;
        }

        // PUT: api/LoanEvents/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutLoanEvent(int id, LoanEvent loanEvent)
        {
            if (id != loanEvent.ID)
            {
                return BadRequest();
            }

            _context.Entry(loanEvent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoanEventExists(id))
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

        // POST: api/LoanEvents
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<LoanEvent>> PostLoanEvent(LoanEvent loanEvent)
        {
            _context.Loans.Add(loanEvent);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLoanEvent", new { id = loanEvent.ID }, loanEvent);
        }

        // DELETE: api/LoanEvents/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<LoanEvent>> DeleteLoanEvent(int id)
        {
            var loanEvent = await _context.Loans.FindAsync(id);
            if (loanEvent == null)
            {
                return NotFound();
            }

            _context.Loans.Remove(loanEvent);
            await _context.SaveChangesAsync();

            return loanEvent;
        }

        private bool LoanEventExists(int id)
        {
            return _context.Loans.Any(e => e.ID == id);
        }
    }
}