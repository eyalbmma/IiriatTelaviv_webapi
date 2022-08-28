﻿using DomainIriatTelaviv.BaseRepository.Interfaces;
using DomainIriatTelaviv.BaseRepository.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DomainIriatTelaviv.BaseRepository.Infrastucture
{
    public class Repository<TDbContext> : IRepository<TDbContext> where TDbContext : DbContext
    {
        protected TDbContext dbContext;

        public Repository(TDbContext context)
        {
            dbContext = context;
        }

        public async Task CreateAsync<T>(T entity) where T : class
        {
            this.dbContext.Set<T>().Add(entity);

            _ = await this.dbContext.SaveChangesAsync();
        }
        public int Create<T>(T entity) where T : class
        {
            this.dbContext.Set<T>().Add(entity);

            return this.dbContext.SaveChanges();
        }
        public async Task DeleteAsync<T>(T entity) where T : class
        {
            this.dbContext.Set<T>().Remove(entity);

            _ = await this.dbContext.SaveChangesAsync();
        }

        public int Delete<T>(T entity) where T : class
        {
            this.dbContext.Set<T>().Remove(entity);

            return this.dbContext.SaveChanges();
        }

        public async Task<List<T>> GetAllAsync<T>() where T : class
        {
            return await this.dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync<T>(long id) where T : class
        {
            return await this.dbContext.Set<T>().FindAsync(id);
        }
        public T GetById<T>(int id) where T : class
        {
            return this.dbContext.Set<T>().Find(id);

        }
        public async Task UpdateAsync<T>(T entity) where T : class
        {
            this.dbContext.Set<T>().Update(entity);

            _ = await this.dbContext.SaveChangesAsync();
        }
        public int Update<T>(T entity) where T : class
        {
            this.dbContext.Set<T>().Update(entity);

            return this.dbContext.SaveChanges();
        }

        public T Find<T>(Expression<Func<T, bool>> expression) where T : class
        {
            return this.dbContext.Set<T>().Find(expression);
        }

        public T GetFirstObject<T>(Expression<Func<T, bool>> filterExpression) where T : class
        {
            return this.dbContext.Set<T>().FirstOrDefault(filterExpression);
        }



        public async Task<T> FindAsync<T>(Expression<Func<T, bool>> expression) where T : class
        {
            try
            {
                var pk = this.dbContext.Model.FindEntityType(typeof(T)).FindPrimaryKey();

                var res = await this.dbContext.Set<T>().FindAsync(expression);
                return res;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public IQueryable<T> Get<T>() where T : class
        {
            return this.dbContext.Set<T>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TRes"></typeparam>
        /// <param name="spName"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public IQueryable<TRes> ExecuteGetSP<TRes>(string spName, object parameters = null) where TRes : class
        {
            var paramsArr = new Collection<object>();
            var spStringCommand = BuildSpCommand(spName, ref paramsArr, parameters);

            return this.dbContext.Set<TRes>().FromSqlRaw(spStringCommand, parameters: paramsArr.ToArray());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TRes"></typeparam>
        /// <param name="spName"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public Task<List<TRes>> ExecuteGetSPAsync<TRes>(string spName, object parameters = null) where TRes : class
        {
            var paramsArr = new Collection<object>();
            var spStringCommand = BuildSpCommand(spName, ref paramsArr, parameters);

            return this.dbContext.Set<TRes>().FromSqlRaw(spStringCommand, paramsArr.ToArray()).ToListAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="spName"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public Task<int> ExecuteSqlCommandAsync(string spName, object parameters = null)
        {
            var paramsArr = new Collection<object>();
            var spStringCommand = BuildSpCommand(spName, ref paramsArr, parameters);

            return this.dbContext.Database.ExecuteSqlRawAsync(spStringCommand, paramsArr.ToArray());
        }

        private string BuildSpCommand(string spName, ref Collection<object> paramsArr, object parameters = null)
        {
            var spStringCommand = spName;
            if (parameters != null)
            {
                var props = parameters.GetType().GetProperties();

                foreach (var item in props)
                {
                    var name = item.Name;
                    spStringCommand += $" @{name},";
                    SqlParameter paramEntity = null;

                    if (item.GetValue(parameters) == null)
                    {
                        paramEntity = new SqlParameter($"{name}", DBNull.Value);
                    }
                    else
                    {
                        if (item.GetValue(parameters).GetType() == typeof(UserDataTypes))
                        {
                            UserDataTypes userDataTable = (UserDataTypes)item.GetValue(parameters);
                            paramEntity = new SqlParameter($"{name}", userDataTable.Value);
                            paramEntity.TypeName = userDataTable.TypeName;
                        }
                        else
                        {
                            paramEntity = new SqlParameter($"{name}", item.GetValue(parameters));
                        }
                    }

                    paramsArr.Add(paramEntity);
                }

                spStringCommand = spStringCommand.Remove(spStringCommand.Length - 1);
            }
            return spStringCommand;
        }
    }
}
