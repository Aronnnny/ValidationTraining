using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidationTraining.Domain.Models;

namespace ValidationTraining.Domain.Repositories
{
    public interface IBrandInterfrace
    {
        Brand GetById(Guid Id);
        IEnumerable<Brand> GetAll();
        Guid Add(Brand brand);
        void Update(Brand brand);
        void Delete(Guid id);
    }
}
