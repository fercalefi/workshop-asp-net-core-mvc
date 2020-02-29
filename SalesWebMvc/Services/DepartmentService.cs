using SalesWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SalesWebMvc.Services
{
    public class DepartmentService
    {
        private readonly SalesWebMvcContext _context;

        public DepartmentService(SalesWebMvcContext context)
        {
            _context = context;
        }

        /*public List<Department> FindAll()
        {
            return _context.Department.OrderBy(x => x.Name).ToList();
        }*/

            // comentado codigo acima para difernciar operações sincronas de assincronas.
            // tolist é do link. tolistAsync é do EF(entity).
        public async Task<List<Department>> FindAllAsync()
        {
            return await _context.Department.OrderBy(x => x.Name).ToListAsync();
        }

        // para utilizar tem que incluir a palavra await para avisar o compilador que é uma operação assincrona.
    }
}
