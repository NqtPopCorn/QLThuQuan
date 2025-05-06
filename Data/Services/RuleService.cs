﻿﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QLThuQuan.Data.Models;

namespace QLThuQuan.Data.Services
{
    public class RuleService : IRuleService
    {
        private readonly AppDbContext _context;

        public RuleService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Rule>> GetAllAsync()
        {
            return await _context.Rules.ToListAsync();
        }

        public async Task<Rule> GetByIdAsync(int id)
        {
            return await _context.Rules.FindAsync(id);
        }

        public async Task<Rule> AddAsync(Rule rule)
        {
            rule.CreatedAt = DateTime.Now;
            rule.UpdatedAt = DateTime.Now;
            _context.Rules.Add(rule);
            await _context.SaveChangesAsync();
            return rule;
        }

        public async Task<Rule> UpdateAsync(Rule rule)
        {
            rule.UpdatedAt = DateTime.Now;
            _context.Rules.Update(rule);
            await _context.SaveChangesAsync();
            return rule;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var rule = await _context.Rules.FindAsync(id);
            if (rule == null)
                return false;

            _context.Rules.Remove(rule);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Rule>> FindByKeywordAsync(string keyword)
        {
            if (string.IsNullOrEmpty(keyword))
                return await GetAllAsync();

            return await _context.Rules
                .Where(r => r.Name.Contains(keyword) || r.Description.Contains(keyword))
                .ToListAsync();
        }
    }
}
