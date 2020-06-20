using System.Collections.Generic;
using APIFuelStation.Models;

namespace APIFuelStation.QueryBus
{
    public class GetAllDepartmentQuery : MediatR.IRequest<List<Department>>
    {

    }
}