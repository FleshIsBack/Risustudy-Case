using BackendApi.DTO;
using BackendApi.Models;

namespace BackendApi.Data
{
    public static class MockData
    {
        public static readonly Guid DefaultClassId = Guid.Parse("11111111-1111-1111-1111-111111111111");

        public static List<Student> Students = new()
        {
            new Student
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                Name = "Emma Nielsen",
                Status = StudentStatus.Advanced,
                progressPercentage = 85,
                ClassId = DefaultClassId,
            },
            new Student
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                Name = "Noah Jensen",
                Status = StudentStatus.OnTrack,
                progressPercentage = 72,
                ClassId = DefaultClassId,
            },
            new Student
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                Name = "Sophia Hansen",
                Status = StudentStatus.NeedsAttention,
                progressPercentage = 45,
                ClassId = DefaultClassId,
            },
            new Student
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000004"),
                Name = "Oliver Andersen",
                Status = StudentStatus.OnTrack,
                progressPercentage = 68,
                ClassId = DefaultClassId,
            },
            new Student
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000005"),
                Name = "Isabella Larsen",
                Status = StudentStatus.Advanced,
                progressPercentage = 91,
                ClassId = DefaultClassId,
            },
            new Student
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000006"),
                Name = "Lucas Pedersen",
                Status = StudentStatus.NeedsAttention,
                progressPercentage = 38,
                ClassId = DefaultClassId,
            }
        };

        public static List<Class> Classes = new()
        {
            new Class
            {
                Id = DefaultClassId,
                Name = "5.A Matematik",
                Subject = "Matematik",
                Grade = "5"
            }
        };

        public static List<Topic> Topics = new()
        {
            new Topic { Id = Guid.NewGuid(), Name = "Fractions", Subject = "Math" },
            new Topic { Id = Guid.NewGuid(), Name = "Word Problems", Subject = "Math" },
            new Topic { Id = Guid.NewGuid(), Name = "Multiplication", Subject = "Math" },
            new Topic { Id = Guid.NewGuid(), Name = "Geometry", Subject = "Math" },
            new Topic { Id = Guid.NewGuid(), Name = "Division", Subject = "Math" },
            new Topic { Id = Guid.NewGuid(), Name = "Problem Solving", Subject = "Math" },
            new Topic { Id = Guid.NewGuid(), Name = "Pattern Recognition", Subject = "Math" },
            new Topic { Id = Guid.NewGuid(), Name = "Addition", Subject = "Math" },
            new Topic { Id = Guid.NewGuid(), Name = "Subtraction", Subject = "Math" },
            new Topic { Id = Guid.NewGuid(), Name = "Time Concepts", Subject = "Math" }
        };

        public static Dictionary<Guid, AllInsigt> Insights = new()
        {
            {
                Guid.Parse("00000000-0000-0000-0000-000000000001"),
                new AllInsigt
                {
                    Id = Guid.NewGuid(),
                    StudentId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                    Analysis = "Emma excels in visual-spatial tasks but struggles with abstract problem-solving. Consider introducing fraction concepts through visual aids.",
                    WeakTopics = Topics.Where(t => t.Name is "Fractions" or "Word Problems").ToList(),
                    StrongTopics = Topics.Where(t => t.Name is "Multiplication" or "Geometry").ToList(),
                    Trend = LearningTrend.Improving,
                    GeneratedAt = DateTime.UtcNow.AddHours(-2)
                }
            },
            {
                Guid.Parse("00000000-0000-0000-0000-000000000002"),
                new AllInsigt
                {
                    Id = Guid.NewGuid(),
                    StudentId = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                    Analysis = "Sophia shows fundamental understanding but struggles with multi-step problems. Recommend breaking complex tasks into smaller chunks and providing more scaffolding.",
                    WeakTopics = Topics.Where(t => t.Name is "Division" or "Problem Solving" or "Pattern Recognition").ToList(),
                    StrongTopics = Topics.Where(t => t.Name is "Addition").ToList(),
                    Trend = LearningTrend.Declining,
                    GeneratedAt = DateTime.UtcNow.AddHours(-1)
                }
            },
            {
                Guid.Parse("00000000-0000-0000-0000-000000000003"),
                new AllInsigt
                {
                    Id = Guid.NewGuid(),
                    StudentId = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                    Analysis = "Sophia shows fundamental understanding but struggles with multi-step problems. Recommend breaking complex tasks into smaller chunks and providing more scaffolding.",
                    WeakTopics = Topics.Where(t => t.Name is "Division" or "Problem Solving" or "Pattern Recognition").ToList(),
                    StrongTopics = Topics.Where(t => t.Name is "Addition").ToList(),
                    Trend = LearningTrend.Declining,
                    GeneratedAt = DateTime.UtcNow.AddHours(-1)
                }
            },
             {
                Guid.Parse("00000000-0000-0000-0000-000000000004"),
                new AllInsigt
                {
                    Id = Guid.NewGuid(),
                    StudentId = Guid.Parse("00000000-0000-0000-0000-000000000004"),
                    Analysis = "Sophia shows fundamental understanding but struggles with multi-step problems. Recommend breaking complex tasks into smaller chunks and providing more scaffolding.",
                    WeakTopics = Topics.Where(t => t.Name is "Division" or "Problem Solving" or "Pattern Recognition").ToList(),
                    StrongTopics = Topics.Where(t => t.Name is "Addition").ToList(),
                    Trend = LearningTrend.Declining,
                    GeneratedAt = DateTime.UtcNow.AddHours(-1)
                }
            },
             {
                Guid.Parse("00000000-0000-0000-0000-000000000005"),
                new AllInsigt
                {
                    Id = Guid.NewGuid(),
                    StudentId = Guid.Parse("00000000-0000-0000-0000-000000000005"),
                    Analysis = "Sophia shows fundamental understanding but struggles with multi-step problems. Recommend breaking complex tasks into smaller chunks and providing more scaffolding.",
                    WeakTopics = Topics.Where(t => t.Name is "Division" or "Problem Solving" or "Pattern Recognition").ToList(),
                    StrongTopics = Topics.Where(t => t.Name is "Addition").ToList(),
                    Trend = LearningTrend.Declining,
                    GeneratedAt = DateTime.UtcNow.AddHours(-1)
                }
            },
            {
                Guid.Parse("00000000-0000-0000-0000-000000000006"),
                new AllInsigt
                {
                    Id = Guid.NewGuid(),
                    StudentId = Guid.Parse("00000000-0000-0000-0000-000000000006"),
                    Analysis = "Lucas needs significant support with basic arithmetic. Consider peer tutoring and additional practice time with manipulatives.",
                    WeakTopics = Topics.Where(t => t.Name is "Subtraction" or "Time Concepts").ToList(),
                    StrongTopics = Topics.Where(t => t.Name is "Pattern Recognition").ToList(),
                    Trend = LearningTrend.Stable,
                    GeneratedAt = DateTime.UtcNow.AddMinutes(-30)
                }
            }
        };

        public static List<Recommendation> Recommendations = new()
        {
            new Recommendation
            {
                Id = Guid.NewGuid(),
                ClassId = DefaultClassId,
                Type = RecommendationType.Intervention,
                Priority = Priority.High,
                Title = "Small Group Support Needed",
                Description = "Schedule 20-minute small group session focusing on basic division concepts",
                TargetStudentIds = new List<Guid>
                {
                    Guid.Parse("00000000-0000-0000-0000-000000000003"),
                    Guid.Parse("00000000-0000-0000-0000-000000000006")
                },
                ExpectedImpact = "High",
                CreatedAt = DateTime.UtcNow.AddHours(-3)
            },
            new Recommendation
            {
                Id = Guid.NewGuid(),
                ClassId = DefaultClassId,
                Type = RecommendationType.Grouping,
                Priority = Priority.Medium,
                Title = "Peer Learning Opportunity",
                Description = "Create advanced problem-solving group for enrichment activities",
                TargetStudentIds = new List<Guid>
                {
                    Guid.Parse("00000000-0000-0000-0000-000000000001"),
                    Guid.Parse("00000000-0000-0000-0000-000000000005"),
                    Guid.Parse("00000000-0000-0000-0000-000000000002")
                },
                ExpectedImpact = "Medium",
                CreatedAt = DateTime.UtcNow.AddHours(-5)
            },
            new Recommendation
            {
                Id = Guid.NewGuid(),
                ClassId = DefaultClassId,
                Type = RecommendationType.Assignment,
                Priority = Priority.High,
                Title = "Differentiated Practice",
                Description = "Assign adaptive practice exercises focusing on identified weak areas",
                TargetStudentIds = new List<Guid>
                {
                    Guid.Parse("00000000-0000-0000-0000-000000000003"),
                    Guid.Parse("00000000-0000-0000-0000-000000000006")
                },
                ExpectedImpact = "High",
                CreatedAt = DateTime.UtcNow.AddHours(-1)
            },
            new Recommendation
            {
                Id = Guid.NewGuid(),
                ClassId = DefaultClassId,
                Type = RecommendationType.CheckIn,
                Priority = Priority.Low,
                Title = "Progress Check",
                Description = "Monitor for potential regression - performance dipped 5% this week",
                TargetStudentIds = new List<Guid>
                {
                    Guid.Parse("00000000-0000-0000-0000-000000000004")
                },
                ExpectedImpact = "Low",
                CreatedAt = DateTime.UtcNow.AddMinutes(-45)
            }
        };
    }
}