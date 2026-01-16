using SmartCardBackend.Domain.Entities;
using SmartCardBackend.Domain.Repositories;

namespace SmartCartBackend.Infrastructure.Repositories;

public class UserAiRequestRepository(
    DatabaseContext context) 
    : Repository<UserAiRequest>(context), IUserAiRequestRepository;