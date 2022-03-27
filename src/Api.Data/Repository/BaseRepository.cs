using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Repository
{
  public class BaseRepository<T> : IRepository<T> where T : BaseEntity
  {
    protected readonly MyContext _context;
    private DbSet<T> _dataset;
    public BaseRepository(MyContext context)
    {
      _context = context;
      _dataset = context.Set<T>();
    }

    public MyContext MyContext { get; }

    public Task<bool> DeleteAsync(Guid id)
    {
      throw new NotImplementedException();
    }

    public async Task<T> InsertAsync(T item)
    {
      try
      {
        if (item.Id == Guid.Empty)
        {
          item.Id = Guid.NewGuid();
        }

        item.CreatedAt = DateTime.UtcNow;

        _dataset.Add(item);
        await _context.SaveChangesAsync();
      }
      catch (Exception ex)
      {
        throw ex;
      }

      return item;
    }

    public Task<T> SelectAsync(Guid id)
    {
      throw new NotImplementedException();
    }

    public Task<IEnumerable<T>> SelectAsync()
    {
      throw new NotImplementedException();
    }

    public async Task<T> UpdateAsync(T item)
    {
      try
      {
        var result = await _dataset.SingleOrDefaultAsync(user => user.Id.Equals(item.Id));

        if (result == null)
        {
          return null;
        }

        item.UpdatedAt = DateTime.UtcNow;
        item.CreatedAt = result.CreatedAt;

        _context.Entry(result).CurrentValues.SetValues(item);
        await _context.SaveChangesAsync();
      }
      catch (Exception ex)
      {
        throw ex;
      }

      return item;
    }
  }
}