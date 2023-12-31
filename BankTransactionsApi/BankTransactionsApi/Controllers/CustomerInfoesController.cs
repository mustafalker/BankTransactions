﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BankTransactionsApi.Model;

namespace BankTransactionsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerInfoesController : ControllerBase
    {
        private readonly CustomerInfoDbContext _context;

        public CustomerInfoesController(CustomerInfoDbContext context)
        {
            _context = context;
        }

        // GET: api/CustomerInfoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerInfo>>> GetCustomerInfos()
        {
          if (_context.CustomerInfos == null)
          {
              return NotFound();
          }
            return await _context.CustomerInfos.ToListAsync();
        }

        // GET: api/CustomerInfoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerInfo>> GetCustomerInfo(int id)
        {
          if (_context.CustomerInfos == null)
          {
              return NotFound();
          }
            var customerInfo = await _context.CustomerInfos.FindAsync(id);

            if (customerInfo == null)
            {
                return NotFound();
            }

            return customerInfo;
        }

        // PUT: api/CustomerInfoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomerInfo(int id, CustomerInfo customerInfo)
        {
            if (id != customerInfo.CustomerId)
            {
                return BadRequest();
            }

            _context.Entry(customerInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerInfoExists(id))
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

        // POST: api/CustomerInfoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CustomerInfo>> PostCustomerInfo(CustomerInfo customerInfo)
        {
          if (_context.CustomerInfos == null)
          {
              return Problem("Entity set 'customerInfoDbContext.CustomerInfos'  is null.");
          }
            _context.CustomerInfos.Add(customerInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomerInfo", new { id = customerInfo.CustomerId }, customerInfo);
        }

        // DELETE: api/CustomerInfoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomerInfo(int id)
        {
            if (_context.CustomerInfos == null)
            {
                return NotFound();
            }
            var customerInfo = await _context.CustomerInfos.FindAsync(id);
            if (customerInfo == null)
            {
                return NotFound();
            }

            _context.CustomerInfos.Remove(customerInfo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CustomerInfoExists(int id)
        {
            return (_context.CustomerInfos?.Any(e => e.CustomerId == id)).GetValueOrDefault();
        }
    }
}
