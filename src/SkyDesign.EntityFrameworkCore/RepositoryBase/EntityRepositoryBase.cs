using Microsoft.EntityFrameworkCore;
using SkyDesign.Core.Base;
using SkyDesign.Domain.Common;
using SkyDesign.EntityFrameworkCore.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SkyDesign.EntityFrameworkCore.RepositoryBase
{
    public class EntityRepositoryBase<T> where T : class, IEntity
    {
        protected readonly ApplicationContext Context;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Context"></param>
        public EntityRepositoryBase(ApplicationContext Context)
        {
            this.Context = Context;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public CommonResponse<List<T>> GetAll()
        {
            try
            {
                return new CommonResponse<List<T>>
                {
                    Value = Context.Set<T>().ToList(),
                    Success = true,
                    InfoMessage = "Successfully"
                };
            }
            catch (Exception ex)
            {
                return new CommonResponse<List<T>>
                {
                    Value = null,
                    Success = false,
                    ErrorMessage = ex.Message
                };
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CommonResponse<T> Get(object id)
        {
            try
            {
                return new CommonResponse<T>
                {
                    Value = Context.Set<T>().Find(id),
                    Success = true,
                    InfoMessage = "Successfully"
                };
            }
            catch (Exception ex)
            {
                return new CommonResponse<T>
                {
                    Value = null,
                    Success = false,
                    ErrorMessage = ex.Message
                };
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public CommonResponse<T> Add(T entity)
        {
            try
            {
                Context.Set<T>().Add(entity);
                Context.SaveChanges();
                return new CommonResponse<T>
                {
                    Value = entity,
                    Success = true,
                    InfoMessage = "Successfully"
                };
            }
            catch (Exception ex)
            {
                return new CommonResponse<T>
                {
                    Value = entity,
                    Success = false,
                    ErrorMessage = ex.Message
                };
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CommonResponse<T> Delete(object id)
        {
            try
            {
                var entity = Get(id);
                entity.Value.DeleteDate = DateTime.Now;
                entity.Value.IsActive = false;
                Context.SaveChanges();
                return new CommonResponse<T>
                {
                    Value = entity.Value,
                    Success = true,
                    InfoMessage = "Successfully"
                };
            }
            catch (Exception ex)
            {
                return new CommonResponse<T>
                {
                    Value = null,
                    Success = false,
                    ErrorMessage = ex.Message
                };
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public CommonResponse<T> Update(T entity)
        {
            try
            {
                Context.Entry(entity).State = EntityState.Modified;
                Context.SaveChanges();
                return new CommonResponse<T>
                {
                    Value = entity,
                    Success = true,
                    InfoMessage = "Successfully"
                };
            }
            catch (Exception ex)
            {
                return new CommonResponse<T>
                {
                    Value = entity,
                    Success = false,
                    ErrorMessage = ex.Message
                };
            }
        }
    }
}
