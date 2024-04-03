using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidationTraining.Domain.Models;

namespace ValidationTraining.Domain.Repositories
{
    public interface ICategoryInterface
    {
        Category GetById(Guid Id);
        IEnumerable<Category> GetAll();
        Guid Add(Category category);
        void Update(Category category);
        void Delete(Guid id);
    }
}
