using SmartCardBackend.Domain.Entities;
using SmartCardBackend.Domain.Repositories;

namespace SmartCartBackend.Infrastructure.Repositories;

public class UserRepository(
    DatabaseContext context) 
    : Repository<User, Guid>(context), IUserRepository;