using MediatR;
using SkyDesign.Core.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyDesign.Application.Contract.Queries.Page
{
    public class AddColumnToTableRequest : IRequest<CommonResponse<AddColumnToTableResponse>>
    {
        public int PageId { get; set; }

        public string ColumnName { get; set; }
        public string DataType { get; set; }
        public string HasRelation { get; set; }
        public string Nullable { get; set; }
        public string TableName { get; set; }
    }
}
