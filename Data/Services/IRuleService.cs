﻿﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLThuQuan.Data.Models;

namespace QLThuQuan.Data.Services
{
    public interface IRuleService
    {
        Task<List<Rule>> GetAllAsync();
        Task<Rule> GetByIdAsync(int id);
        Task<Rule> AddAsync(Rule rule);
        Task<Rule> UpdateAsync(Rule rule);
        Task<bool> DeleteAsync(int id);
        Task<List<Rule>> FindByKeywordAsync(string keyword);
    }
}
