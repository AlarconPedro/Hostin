using Hostin.Core.Interfaces.Config;
using HostIn_Api;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostin.Infra.Data.Services;

public class GenericService<T> : IGenericService<T> where T : class
{
    private readonly HostinContext _context;

    public GenericService(HostinContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<T>> GetAll() => await _context.Set<T>().ToListAsync();

    public async Task<IEnumerable<T>> GetWithFilter(Func<T, bool> filter) => _context.Set<T>().Where(filter).ToList();

    public async Task<T> GetById(int id) => await _context.Set<T>().FindAsync(id);

    public async Task<T> Add(T entity)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity));
        await _context.Set<T>().AddAsync(entity);
        
        await _context.SaveChangesAsync();
        //retornar o objeto adicionado com o ID atualizado
        return entity;

        _context.Set<T>().Add(entity);
        await _context.SaveChangesAsync();
    }

    public Task<T> Update(T entity)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity));
        _context.Set<T>().Update(entity);
        return _context.SaveChangesAsync().ContinueWith(t => entity);
    }

    public Task<bool> Delete(int id)
    {
        var entity = _context.Set<T>().Find(id);
        if (entity == null)
            return Task.FromResult(false);
        _context.Set<T>().Remove(entity);
        return _context.SaveChangesAsync().ContinueWith(t => t.Result > 0);
    }
}
