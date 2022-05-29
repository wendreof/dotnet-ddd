﻿using System.Threading.Tasks;
using Api.Data.Repository;
using Api.Domain.Entities;
using Api.Domain.Repository;
using Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Implementations
{
    public class UserImplementation : BaseRepository<UserEntity>, IUserRepository
    {
        private readonly DbSet<UserEntity> _dataset;

        public UserImplementation(MyContext context) : base(context)
        {
            _dataset = context.Set<UserEntity>();

        }

        public async Task<UserEntity> FindByLogin(string email)
        {
            return await _dataset.FirstOrDefaultAsync(user => user.Email.Equals(email));
        }
    }
}
