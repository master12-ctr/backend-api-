using System.Security.Cryptography.X509Certificates;
using FirstProject.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstProject
{
    public class UsersdbContext :DbContext
    {
     public UsersdbContext(DbContextOptions<UsersdbContext> options)
            :base(options)
        { 
         
        } 
        public virtual DbSet<Department> Department { get; set; }   
        public virtual DbSet<User> User { get; set; } 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<Department>(entity =>
    {
        entity.HasKey(x => x.Deptid);
        entity.Property(x=> x.Deptname);
        entity.Property(x=> x.Description);
        entity.HasOne(x=> x.ParentDepartment)
            .WithMany(x=> x.ChildrenDeprtment)
            .HasForeignKey(x=> x.Parentid)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Cascade);
            
    });
    /*
    modelBuilder.Entity<Department>(entity =>
    {
        entity.HasKey(x => x.Deptid);
        entity.HasOne(x=> x.Employee)
            .WithOne(x=> x.Department)
             .HasForeignKey<Employee>(x=> x.Deptid)
            .IsRequired(true)
            .OnDelete(DeleteBehavior.Cascade);
            
    });
     modelBuilder.Entity<Employee>(entity =>
    {
        entity.HasKey(x => x.Empid);
        entity.HasOne(x=> x.Department)
            .WithOne(x=> x.Employee)
            .HasForeignKey<Department>(x=> x.Managerid)
            .OnDelete(DeleteBehavior.Restrict);
            
    }
    );
    */
    // ...
}
    }


}