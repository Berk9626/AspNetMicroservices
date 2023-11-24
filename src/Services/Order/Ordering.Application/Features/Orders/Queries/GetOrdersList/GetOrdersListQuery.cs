using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Features.Orders.Queries.GetOrdersList
{
    //request class for our query object
    //These will be provided to define a query and in return type is it ordersDVM.
    //Commands: Objenin veya sistemin durumunu değiştirir. Queries: Sadece sonucu geriye döner herhangi bir objenin veya sistemin durumunu değiştirmez.
    public class GetOrdersListQuery: IRequest<List<OrdersVm>>
    {
        public string UserName { get; set; }

        public GetOrdersListQuery(string userName)
        {
            UserName= userName; 
        }

    }
}
