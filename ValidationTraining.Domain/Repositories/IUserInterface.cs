using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidationTraining.Domain.Models;

namespace ValidationTraining.Domain.Repositories
{
    public interface IUserInterface
    {
        User GetById (Guid Id);
        IEnumerable<User> GetAll();
        Guid Add(User user);
        void Update(User user);
        void Delete (Guid id);
    }
}
