using ASP_API.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;

namespace ASP_API.Helpers.Repositories.Base;


public abstract class Repository<TEntity> where TEntity : class
{
    private readonly DataContext _context;

    protected Repository(DataContext context)
    {
        _context = context;
    }


    public virtual async Task<TEntity> AddAsync(TEntity entity)
    {
        try
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error in {nameof(AddAsync)}: {ex.Message}");
            throw;
        }
    }

    public virtual async Task<bool> FindAsync(Expression<Func<TEntity, bool>> expression)
    {
        try
        {
            return await _context.Set<TEntity>().AnyAsync(expression);
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error in {nameof(FindAsync)}: {ex.Message}");
            throw;
        }
    }

    public virtual async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression)
    {
        try
        {
            return await _context.Set<TEntity>().FirstOrDefaultAsync(expression);
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error in {nameof(UpdateAsync)}: {ex.Message}");
            throw;
        }
    }

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        try
        {
            var result = await _context.Set<TEntity>().ToListAsync();
            return result;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error in {nameof(DeleteAsync)}: {ex.Message}");
            throw;
        }
    }

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression)
    {
        try
        {
            var result = await _context.Set<TEntity>().Where(expression).ToListAsync();
            return result;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error in {nameof(GetAllAsync)}: {ex.Message}");
            return Enumerable.Empty<TEntity>();
        }
    }

    public virtual async Task<TEntity> UpdateAsync(TEntity entity)
    {
        try
        {
            _context.Set<TEntity>().Update(entity);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return entity;
    }

    public virtual async Task<bool> DeleteAsync(TEntity entity)
    {
        try
        {
            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();  
            return true;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return false;
        }
    }


}






