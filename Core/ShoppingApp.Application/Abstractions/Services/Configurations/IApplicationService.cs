using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query.Internal;
using ShoppingApp.Application.DTOs.Configurations;

namespace ShoppingApp.Application.Abstractions.Services.Configurations
{
    public interface IApplicationService
    {
        List<Menu> GetAuthorizeDefinitionEndpoints(Type type);
    }
}
