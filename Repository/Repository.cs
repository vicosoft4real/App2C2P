using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App2c2pTest.Data;
using App2c2pTest.Data.Interface;
using App2c2pTest.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace App2c2pTest.Repository
{
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class Repository<TEntity>: IRepository<TEntity> where TEntity : class, IEntity
    {
        private readonly App2c2pContext _dbContextProvider;

        public Repository(App2c2pContext dbContextProvider)
        {
            _dbContextProvider = dbContextProvider;
        }


        /// <summary>
        /// get the current Entity
        /// <returns><see cref="DbSet{TEntity}"/></returns>
        /// </summary>
        public virtual DbSet<TEntity> Table => _dbContextProvider.Set<TEntity>();


        public async Task<List<TEntity>> ExecuteTSQLAsync(string sql)
        {
           return await Table.FromSql(sql).ToListAsync();
        }

        public  List<TEntity> ExecuteTSQL(string sql)
        {
            return  Table.FromSql(sql).ToList(); ;
        }
    }
}