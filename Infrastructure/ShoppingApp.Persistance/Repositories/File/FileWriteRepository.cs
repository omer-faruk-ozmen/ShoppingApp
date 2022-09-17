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
