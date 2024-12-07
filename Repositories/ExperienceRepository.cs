using Dapper;
using Microsoft.Data.SqlClient;
using Portfolio.Models;

namespace Portfolio.Repositories
{
    public class ExperienceRepository : IRepository<Experience>
    {
        private readonly string? _connectionString;

        public ExperienceRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("PortfolioConnection");
        }

        public IEnumerable<Experience> GetAll()
        {
            using var connection = new SqlConnection(_connectionString);
            var experienceList = new List<Experience>
            {
                new Experience
                {
                    Id = 1,
                    JobTitle = "Software Engineer",
                    Company = "Insightsoftware",
                    Responsibilities = "• Migrated an analytical tool from Knockout.js to React, leveraging .NET and SQL for backend operations, resulting in a 25%\n" +
                                       "improvement in performance and enhanced maintainability, leading to faster load times and easier feature updates.\n" +
                                       "• Detected and resolved a security vulnerability by implementing encoding and decoding mechanisms in .NET to protect sensitive\n" +
                                       "data between the backend and browser, ensuring secure communication.\n" +
                                       "• Optimized CI/CD pipelines using Azure DevOps, reducing deployment times by 30%",
                    FromDate = new DateOnly(2024, 1, 5),
                    ToDate = new DateOnly(2024, 7, 30)
                },
                new Experience
                {
                    Id = 2,
                    JobTitle = "Software Engineer",
                    Company = "Arcadix Infotech Pvt Ltd",
                    Responsibilities = "• Proposed and led the migration from Angular.js to React for the School Management System, improving performance by 30% and reducing technical debt.\n" +
                                       "• Integrated SignalR to update students' marks in real-time in their profiles after exams, ensuring immediate updates.\n" +
                                       "• Designed and developed scalable web APIs using .NET and SQL Server with a microservice architecture, and integrated Elasticsearch for faster data retrieval, improving system reliability, efficiency, and search performance by 40%.",
                    FromDate = new DateOnly(2021, 12, 1),
                    ToDate = new DateOnly(2024, 1, 1)
                },
                new Experience
                {
                    Id = 3,
                    JobTitle = "Software Engineer",
                    Company = "Odessa Technologies",
                    Responsibilities = "• Contributed to the development of LeaseWave, a global lease management system, optimizing backend processes using .NET Core, C#, React, and Dapper.\n" +
                                       "• Improved query efficiency by optimizing SQL queries, reducing database response times by 15%, and streamlined CI/CD deployment processes using Azure DevOps, enhancing team productivity and deployment reliability.\n" +
                                       "• Practiced test-driven development (TDD) with NUnit and Jest, improving code quality and reducing bugs by 25%.",
                    FromDate = new DateOnly(2020, 7, 1),
                    ToDate = new DateOnly(2021, 11, 30)
                },
                new Experience
                {
                    Id = 4,
                    JobTitle = "Software Engineer Intern",
                    Company = "Odessa Technologies",
                    Responsibilities = "• Contributed to the development of LeaseWave, a global lease management system, optimizing backend processes using .NET Core, C#, React, and Dapper.\n" +
                                       "• Improved query efficiency by optimizing SQL queries, reducing database response times by 15%, and streamlined CI/CD deployment processes using Azure DevOps, enhancing team productivity and deployment reliability.\n",
                    FromDate = new DateOnly(2019, 9, 1),
                    ToDate = new DateOnly(2020, 7, 30)
                }
            };
            return experienceList;

        }

        public void Add(Experience experience)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Execute("Exec sp_AddExperienceData(@JobTitle, @Company, @StartDate, @EndDate, @Responsibilities);", experience);
        }

        public void Update(Experience experience)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Execute("Exec sp_EditExperienceData(@Id, @JobTitle, @Company, @StartDate, @EndDate, @Responsibilities);", experience);
        }

        public void Delete(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Execute("Exec sp_DeleteExperienceData(@Id);", new { Id = id });
        }
    }

}
