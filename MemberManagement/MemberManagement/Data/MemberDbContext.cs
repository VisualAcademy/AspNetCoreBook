using MemberManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemberManagement.Data
{
    public class MemberDbContext : DbContext
    {
        // Member 모델 클래스를 바탕으로 Members 테이블을 생성
        public DbSet<Member> Members { get; set; }

        public MemberDbContext(DbContextOptions<MemberDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        
        }
    }
}
