using Microsoft.EntityFrameworkCore;
using NetCore.Data.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCore.Services.Data
{
    //2. Fluent API
    //상속
    //CodeFirstDbContext : 자식 클래스
    //DbContext : 부모 클래스
    public class CodeFirstDbContext : DbContext
    {
        //생성자 상속
        public CodeFirstDbContext(DbContextOptions<CodeFirstDbContext> options) : base(options)
        {

        }

        //DB테이블 리스트 지정
        public DbSet<User> Users { get; set; }


        //메서드 상속, 부모 클래스에서 OnModelCreating 메서드가 virtual로 지정되어 있어야
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //4가지 작업
            //DB 테이블 이름 변경
            modelBuilder.Entity<User>().ToTable(name: "User");

            //복합키 지정
            modelBuilder.Entity<UserRolesByUser>().HasKey(c => new { c.UserId, c.RoleId });

            //컬럼 기본 값 지정
            modelBuilder.Entity<User>(e =>
            {
                e.Property(c => c.IsMembershipWithdrawn).HasDefaultValue(value: false);
            });

            //인덱스 지정
            modelBuilder.Entity<User>().HasIndex(c => new { c.UserEmail });
        }

    }
}
