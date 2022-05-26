using MediatR;
using SkyDesign.Core.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyDesign.Application.Contract.Queries.Page
{
    public  class DropColumnFromTableRequest: IRequest<CommonResponse<DropColumnFromTableResponse>>
    {

        public int PageId { get; set; }

        public string ColumnName { get; set; }
        public string HasRelation { get; set; }
        public string TableName { get; set; }
    }
}
