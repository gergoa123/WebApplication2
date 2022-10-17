using Microsoft.EntityFrameworkCore; 
 
namespace WebApplication1.DB
{
    public class Context : DbContext
    {
        public DbSet<Student> Studenti { get; set; }
        public DbSet<Adresa> Adresses { get; set; }
        public DbSet<Mark> Marks { get; set; }
        public DbSet<Subject> Subjects { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-U2JAPE5\SQLEXPRESS;
                                        Initial Catalog=WebApp;
                                        Integrated Security=True;
                                        Connect Timeout=30;
                                        Encrypt=False;
                                        TrustServerCertificate=False;
                                        ApplicationIntent=ReadWrite;
                                        MultiSubnetFailover=False");
            optionsBuilder.LogTo(Console.WriteLine); 
        }
    }
}
