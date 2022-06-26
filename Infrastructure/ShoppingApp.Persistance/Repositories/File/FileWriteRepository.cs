using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ShoppingApp.Application.Repositories.File;
using ShoppingApp.Persistence.Contexts;

namespace ShoppingApp.Persistence.Repositories.File
{
    public class FileWriteRepository : WriteRepository<Domain.Entities.File.File>, IFileWriteRepository
    {
        public FileWriteRepository(ShoppingAppDbContext context) : base(context)
        {
        }
    }
}
