using LibraryApp.Application.Interfaces;
using LibraryApp.Domain.Entities;
using LibraryApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryApp.Infrastructure.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        private readonly LibraryAppDbContext _context;

        public MemberRepository(LibraryAppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Member member)
        {
            await _context.Members.AddAsync(member);
        }

        public void Delete(Member member)
        {
            _context.Members.Remove(member);
        }

        public async Task<IEnumerable<Member>> GetAllAsync()
        {
            return await _context.Members.ToListAsync();
        }

        public async Task<Member?> GetByIdAsync(int id)
        {
            return await _context.Members.FindAsync(id);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(Member member)
        {
            _context.Members.Update(member);
        }
    }
}
