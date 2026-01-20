using SmartCardBackend.Domain.Entities;
using SmartCardBackend.Domain.Repositories;

namespace SmartCartBackend.Infrastructure.Repositories;

public class UserAiRequestRepository(
    IDatabaseContextFactory contextFactory) 
    : Repository<UserAiRequest, Guid>(contextFactory), 
        IUserAiRequestRepository;