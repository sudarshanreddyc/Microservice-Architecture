using Dapper;
using Microsoft.Data.SqlClient;
using Portfolio.Models;

namespace Portfolio.Repositories
{
    public class SkillsRepository : IRepository<Skills>
    {
        private readonly string? _connectionString;

        public SkillsRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("PortfolioConnection");
        }

        public IEnumerable<Skills> GetAll() //Using this
        {
            using var connection = new SqlConnection(_connectionString);
            var skillsList = new List<Skills>
            {
                new Skills { Id = 5, Skill = "C#", Proficiency = null, Category = "Languages" },
                new Skills { Id = 6, Skill = "Java", Proficiency = null, Category = "Languages" },
                new Skills { Id = 7, Skill = "C++", Proficiency = null, Category = "Languages" },
                new Skills { Id = 8, Skill = "Python", Proficiency = null, Category = "Languages" },
                new Skills { Id = 9, Skill = "Javascript", Proficiency = null, Category = "Languages" },
                new Skills { Id = 10, Skill = "MySQL", Proficiency = null, Category = "Languages" },
                new Skills { Id = 11, Skill = "HTML/CSS", Proficiency = null, Category = "Languages" },
                new Skills { Id = 12, Skill = "React", Proficiency = null, Category = "Frameworks" },
                new Skills { Id = 13, Skill = ".Net core", Proficiency = null, Category = "Frameworks" },
                new Skills { Id = 14, Skill = "Dapper", Proficiency = null, Category = "Frameworks" },
                new Skills { Id = 15, Skill = "Jest", Proficiency = null, Category = "Frameworks" },
                new Skills { Id = 16, Skill = "Tailwind-CSS", Proficiency = null, Category = "Frameworks" },
                new Skills { Id = 17, Skill = "Git", Proficiency = null, Category = "Developer Tools" },
                new Skills { Id = 18, Skill = "VS Code", Proficiency = null, Category = "Developer Tools" },
                new Skills { Id = 19, Skill = "Visual Studio", Proficiency = null, Category = "Developer Tools" },
                new Skills { Id = 20, Skill = "Microsoft Azure", Proficiency = null, Category = "Cloud/Devops" },
                new Skills { Id = 21, Skill = "CI/CD", Proficiency = null, Category = "Cloud/Devops" },
                new Skills { Id = 22, Skill = "Cloudflare", Proficiency = null, Category = "Cloud/Devops" },
                new Skills { Id = 23, Skill = "Docker", Proficiency = null, Category = "Cloud/Devops" },
                new Skills { Id = 24, Skill = "Data structures and Algorithms", Proficiency = null, Category = "Other Skills" },
                new Skills { Id = 25, Skill = "Elastic search", Proficiency = null, Category = "Other Skills" },
                new Skills { Id = 26, Skill = "Web API", Proficiency = null, Category = "Other Skills" },
                new Skills { Id = 27, Skill = "Agile methodologies", Proficiency = null, Category = "Other Skills" },
                new Skills { Id = 28, Skill = "Problem solving skills", Proficiency = null, Category = "Other Skills" }
            };
            return skillsList;

        }

        public IEnumerable<SkillsGroup> GetAllGrouped()
        {
            using var connection = new SqlConnection(_connectionString);
            //var result = connection.Query<Skills>("EXEC sp_GetSkillsData;")
            //    .GroupBy(s => s.Category)
            //    .Select(g => new SkillsGroup
            //    {
            //        Category = g.Key,
            //        Skills = g.ToList()
            //    }).ToList();
            //return result;
            return null;
        }

        public void Add(Skills skills)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Execute("Exec sp_AddSkillsData(@SkillName, @Proficiency);", skills);
        }

        public void Update(Skills skills)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Execute("Exec sp_EditSkillsData(@Id, @SkillName, @Proficiency);", skills);
        }

        public void Delete(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Execute("Exec sp_DeleteSkillsData(@Id);", new { Id = id });
        }
    }

}
