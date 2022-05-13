using SkyDesign.Core.Base;
using SkyDesign.Domain.Common;
using SkyDesign.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SkyDesign.Domain.Repositories
{
    public interface IPageRepositoryAsync : IRepositoryAsync<Page>
    {
        Task<CommonResponse<Page>> AddRolePageAsync(Page request);
        Task<CommonResponse<string>> CreateDefaultTable(Page request);
        Task<CommonResponse<List<ColumnList>>> GetAllColumnListAsync();
        Task<CommonResponse<List<ColumnDefinition>>> GetAllColumnListByPageId(int pageId);
        Task<CommonResponse<object>> AddColumnToTable(int pageId,
                                                      string columnName,
                                                      string dataType,
                                                      string hasRelationship,
                                                      string nullable,
                                                      string joinedTableName);
        Task<CommonResponse<object>> DropColumnFromTable(int pageId,
                                                       string columnName,
                                                       string hasRelationship,
                                                       string joinedTableName);
        Task<CommonResponse<dynamic>> GetAddOrUpdateModalDetailPage(string selectedPage, int? id);
    }
}
