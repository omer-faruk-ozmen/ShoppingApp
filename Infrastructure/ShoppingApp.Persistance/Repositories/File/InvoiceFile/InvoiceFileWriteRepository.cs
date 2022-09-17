using ShoppingApp.Application.Repositories.FileRepositories.InvoiceFile;
using ShoppingApp.Persistence.Contexts;

namespace ShoppingApp.Persistence.Repositories.File.InvoiceFile
{
    public class InvoiceFileWriteRepository:WriteRepository<Domain.Entities.File.InvoiceFile>,IInvoiceFileWriteRepository
    {
        public InvoiceFileWriteRepository(ShoppingAppDbContext context) : base(context)
        {
        }
    }
}
