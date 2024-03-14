using Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Queries.GetListOutsideAdmin;
public class GetListBrandOutsideAdminItemDto:IDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}
