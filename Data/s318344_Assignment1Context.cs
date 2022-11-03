using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using s318344_Assignment1.Models;

namespace s318344_Assignment1.Data
{
    public class s318344_Assignment1Context : DbContext
    {
        public s318344_Assignment1Context (DbContextOptions<s318344_Assignment1Context> options)
            : base(options)
        {
        }

        public DbSet<s318344_Assignment1.Models.GenderModel> GenderModel { get; set; } = default!;

        public DbSet<s318344_Assignment1.Models.InstrumentModel> InstrumentModel { get; set; }

        public DbSet<s318344_Assignment1.Models.LessonModel> LessonModel { get; set; }

        public DbSet<s318344_Assignment1.Models.LessonTypeModel> LessonTypeModel { get; set; }

        public DbSet<s318344_Assignment1.Models.StudentModel> StudentModel { get; set; }

        public DbSet<s318344_Assignment1.Models.TutorModel> TutorModel { get; set; }
    }
}
