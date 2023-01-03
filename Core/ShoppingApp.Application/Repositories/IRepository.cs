using Microsoft.EntityFrameworkCore;
using ShoppingApp.Domain.Entities.Common;

namespace ShoppingApp.Application.Repositories;

public interface IRepository<T> where T : BaseEntity
{
    DbSet<T> Table { get; }
}