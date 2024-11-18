using Dapper;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using Portfolio.Models;

namespace Portfolio.Repositories
{
    public class AcademicsRepository : IRepository<Academics>
    {
        private readonly string? _connectionString;

        public AcademicsRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("PortfolioConnection");
        }

        public IEnumerable<Academics> GetAll()
        {
            using var connection = new SqlConnection(_connectionString);
            var academicsList = new List<Academics>
            {
                new Academics
                {
                    Id = 1,
                    School = "Trine University",
                    Percentage = 4.00m,
                    Level = "graduate",
                    FromDate = new DateTime(2024, 8, 1),
                    ToDate = new DateTime(2024, 8, 1) // Assuming you want to allow null for ongoing education
                },
                new Academics
                {
                    Id = 2,
                    School = "Lovely Professional University",
                    Percentage = 9.54m,
                    Level = "undergraduate",
                    FromDate = new DateTime(2016, 7, 1),
                    ToDate = new DateTime(2020, 6, 1)
                },
                new Academics
                {
                    Id = 3,
                    School = "Sri Sai Jr College",
                    Percentage = 97.50m,
                    Level = "Intermediate",
                    FromDate = new DateTime(2014, 6, 1),
                    ToDate = new DateTime(2016, 3, 25)
                }
            };
            return academicsList;

        }

        public void Add(Academics academics)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Execute("Exec sp_AddAcademicsData(@Degree, @Institution, @StartDate, @EndDate);", academics);
        }

        public void Update(Academics academics)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Execute("Exec sp_EditAcademicsData(@Id, @Degree, @Institution, @StartDate, @EndDate);", academics);
        }

        public void Delete(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Execute("Exec sp_DeleteAcademicsData(@Id);", new { Id = id });
        }
    }
}
