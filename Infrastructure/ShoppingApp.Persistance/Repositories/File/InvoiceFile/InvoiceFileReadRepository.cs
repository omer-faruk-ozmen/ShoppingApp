using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingApp.Application.Repositories.FileRepositories.InvoiceFile;
using ShoppingApp.Persistence.Contexts;

namespace ShoppingApp.Persistence.Repositories.File.InvoiceFile
{
    public class InvoiceFileReadRepository:ReadRepository<Domain.Entities.File.InvoiceFile>,IInvoiceFileReadRepository
    {
        public InvoiceFileReadRepository(ShoppingAppDbContext context) : base(context)
        {
        }
    }
}
