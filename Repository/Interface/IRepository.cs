using App2c2pTest.Data.Interface;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;


namespace App2c2pTest.Repository.Interface
{
    /// <summary>
    /// This interface is implemented by all repositories to ensure implementation of fixed methods.
    /// </summary>
    /// <typeparam name="TEntity">Main Entity type this repository works on</typeparam>
    
    public interface IRepository<TEntity> where TEntity : class, IEntity
    {
        Task<List<TEntity>> ExecuteTSQLAsync(string sql);
        List<TEntity> ExecuteTSQL(string sql);

    }
}