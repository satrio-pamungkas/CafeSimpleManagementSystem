using CafeSimpleManagementSystem.Models;
using CafeSimpleManagementSystem.Data;
using Microsoft.EntityFrameworkCore;

namespace CafeSimpleManagementSystem.Repositories;

public class UserRepository
{
    private readonly DataContext? _context;
    public UserRepository(DataContext context)
    {
        _context = context;
    }

    public User? GetById(Guid id)
    {
        return _context!.Users?
            .AsNoTracking()
            .SingleOrDefault(p => p.Id == id);
    }
}