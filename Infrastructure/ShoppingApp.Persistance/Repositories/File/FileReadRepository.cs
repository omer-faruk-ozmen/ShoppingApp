﻿using ShoppingApp.Application.Repositories.File;
using ShoppingApp.Persistence.Contexts;

namespace ShoppingApp.Persistence.Repositories.File;

public class FileReadRepository : ReadRepository<Domain.Entities.File.File>, IFileReadRepository
{
    public FileReadRepository(ShoppingAppDbContext context) : base(context)
    {
    }
}