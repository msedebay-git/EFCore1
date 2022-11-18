using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

//Console.WriteLine("Done!");

[Table("Department")]
public class Department
{
    [Key]
    public int Did { get; set; }
    public string? DName { get; set; }
    public string? Description { get; set; }
}

[Table("Employee")]
public class Employee
{
    [Key]
    public int Eid { get; set; }
    public string? EName { get; set; }
    public string? Gender { get; set; }
    public string? Email { get; set; }
    public double Salary { get; set; }
    public DateTime DOB { get; set; }
    public int? Did { get; set; }
}

public class   OrganizationDbContext : DbContext
{
    #region Step - 4: Adding DbSets
    public DbSet<Department> Departments { get; set; }
    public DbSet<Employee> Employees { get; set; }
    #endregion

    #region Step - 5: Configuring database connection
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer("Server=DESKTOP-DF2H2V7\\SQLEXPRESS2019;Database=OrgEFDbTask1;Trusted_Connection=True;");
    }

    class Program
    {
        static void Main(string[] args)
        {
            //var D = new Department() { DName = "Finance", Description="Finance Department"};
            
            OrganizationDbContext dbContext = new OrganizationDbContext();
            //dbContext.Departments.Add(D);
            //dbContext.SaveChanges();

            List<Department> departments = dbContext.Departments.ToList();
            foreach (var d in departments)
            {
                Console.WriteLine($"Did:{d.Did} DName:{d.DName} Desc:{d.Description}");
            }

        }
    }
   
}

#endregion
