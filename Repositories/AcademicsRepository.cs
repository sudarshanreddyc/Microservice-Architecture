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
                    Level = "Graduate",
                    Location="Detroit, MI, United States",
                    FromDate = new DateOnly(2024, 8, 1),
                    ToDate = new DateOnly(2024, 8, 1) 
                },
                new Academics
                {
                    Id = 2,
                    School = "Lovely Professional University",
                    Percentage = 9.54m,
                    Level = "Undergraduate",
                    Location="Punjab, India",
                    FromDate = new DateOnly(2016, 7, 1),
                    ToDate = new DateOnly(2020, 6, 1)
                },
                new Academics
                {
                    Id = 3,
                    School = "Sri Sai Jr College",
                    Percentage = 97.50m,
                    Level = "Intermediate",
                    Location="Anantapur, Andhrapradesh, India",
                    FromDate = new DateOnly(2014, 6, 1),
                    ToDate = new DateOnly(2016, 3, 25)
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
