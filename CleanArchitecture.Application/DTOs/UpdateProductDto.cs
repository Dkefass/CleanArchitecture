using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.DTOs
{
    public record UpdateProductDto(int Id, string Name, string Description, decimal Price)
    {
    }
}
