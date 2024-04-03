using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidationTraining.Domain.Models;

namespace ValidationTraining.Domain.Repositories
{
    public interface IProductInterface
    {
        Product GetById(Guid Id);
        IEnumerable<Product> GetAll();
        Guid Add(Product product);
        void Update(Product product);
        void Delete(Guid id);
    }
}
