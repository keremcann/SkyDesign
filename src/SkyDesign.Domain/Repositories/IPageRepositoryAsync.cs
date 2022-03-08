﻿using SkyDesign.Core.Base;
using SkyDesign.Domain.Common;
using SkyDesign.Domain.Entities;
using System.Threading.Tasks;

namespace SkyDesign.Domain.Repositories
{
    public interface IPageRepositoryAsync : IRepositoryAsync<Page>
    {
        Task<CommonResponse<Page>> AddRolePageAsync(Page request);
    }
}