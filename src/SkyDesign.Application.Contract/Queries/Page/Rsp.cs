using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyDesign.Application.Contract.Queries.Page
{
    public class Rsp<T>
    {
        public List<string> ColumnNames { get; set; }
        public T Data { get; set; }
    }

    //{[columnsName: ['Id', 'Name', 'Price'],
    //data:[
    //    'id': 1,
    //    'Name:': 'Ekmek',
    //    'price': 5
    //    ]]
    //}
}
