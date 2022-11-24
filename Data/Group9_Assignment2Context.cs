using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Group9_Assignment2.Models;

namespace Group9_Assignment2.Data
{
    public class Group9_Assignment2Context : DbContext
    {
        public Group9_Assignment2Context (DbContextOptions<Group9_Assignment2Context> options)
            : base(options)
        {
        }

        public DbSet<Group9_Assignment2.Models.GenderModel> GenderModel { get; set; } = default!;

        public DbSet<Group9_Assignment2.Models.InstrumentModel> InstrumentModel { get; set; }

        public DbSet<Group9_Assignment2.Models.LessonModel> LessonModel { get; set; }

        public DbSet<Group9_Assignment2.Models.LessonTypeModel> LessonTypeModel { get; set; }

        public DbSet<Group9_Assignment2.Models.StudentModel> StudentModel { get; set; }

        public DbSet<Group9_Assignment2.Models.TutorModel> TutorModel { get; set; }

        public DbSet<Group9_Assignment2.Models.LetterModel> LetterModel { get; set; }
    }
}
