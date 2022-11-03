using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using s318344_Assignment1.Data;
using System;
using System.Linq;

namespace s318344_Assignment1.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new s318344_Assignment1Context(
                serviceProvider.GetRequiredService<
                    DbContextOptions<s318344_Assignment1Context>>()))
            {
                //Tutors

                if (!context.TutorModel.Any())
                {



                    context.TutorModel.AddRange(
                            new TutorModel { TutorName = "Jenna Stevens" },
                            new TutorModel { TutorName = "Monique Allen" },
                            new TutorModel { TutorName = "Valeria Montgomery" },
                            new TutorModel { TutorName = "Maggie Bullock" },
                            new TutorModel { TutorName = "Myla Gray" },
                            new TutorModel { TutorName = "Heidy Bautista" },
                            new TutorModel { TutorName = "Dominique Ingram" },
                            new TutorModel { TutorName = "Cadence Hurst" },
                            new TutorModel { TutorName = "Rudy Francis" },
                            new TutorModel { TutorName = "Nylah Peters" },
                            new TutorModel { TutorName = "Karlie Carney" },
                            new TutorModel { TutorName = "Frida Richards" }
                    );
                }
                context.SaveChanges();

                //Lesson types

                if (!context.LessonTypeModel.Any())
                {


                    context.LessonTypeModel.AddRange(
                        new LessonTypeModel { LessonType = "Short", LessonDuration = 30, LessonCost = 75 },
                        new LessonTypeModel { LessonType = "Medium", LessonDuration = 45, LessonCost = 120 },
                        new LessonTypeModel { LessonType = "Long", LessonDuration = 60, LessonCost = 135 }
                    );
                }
                context.SaveChanges();

                //Genders

                if (!context.GenderModel.Any())
                {


                    context.GenderModel.AddRange(
                        new GenderModel { Gender = "Male" },
                        new GenderModel { Gender = "Female" },
                        new GenderModel { Gender = "Nonbinary" }
                    );
                }
                context.SaveChanges();

                //Instruments

                if (!context.InstrumentModel.Any())
                {

                context.InstrumentModel.AddRange(
                    new InstrumentModel { Make = "Gibson", Model = "Harp" },
                    new InstrumentModel { Make = "Harman Professional", Model = "Turntables" },
                    new InstrumentModel { Make = "Shure", Model = "Oboe" },
                    new InstrumentModel { Make = "Yamaha", Model = "Wooden Flute" },
                    new InstrumentModel { Make = "Fender Musical Instruments", Model = "Harmonica" },
                    new InstrumentModel { Make = "Steinway Musical Instruments", Model = "Clarinet" },
                    new InstrumentModel { Make = "Sennheiser", Model = "Acoustic Guitar" },
                    new InstrumentModel { Make = "Roland", Model = "Spoons" },
                    new InstrumentModel { Make = "Gibson", Model = "Whistle" },
                    new InstrumentModel { Make = "Harman Professional", Model = "Crystal Glasses" },
                    new InstrumentModel { Make = "Shure", Model = "Steel Drums" },
                    new InstrumentModel { Make = "Yamaha", Model = "Trumpet" }

                );
            }
                context.SaveChanges();

                //Students

                if (!context.StudentModel.Any())
                {
                    context.StudentModel.AddRange(
                        new StudentModel { StudentFirstName = "Nola", StudentLastName = "Mcknight", DOB = DateTime.Parse("25/10/2000"), GenderId = 1, GuardianName = "Darius Ross", PaymentContactEmail = "Darius.Ross@gmail.com", PaymentContactNumber = "0659613541" },
                        new StudentModel { StudentFirstName = "Blaze", StudentLastName = "Krause", DOB = DateTime.Parse("24/07/2000"), GenderId = 2, GuardianName = "Makayla Klein", PaymentContactEmail = "Makayla.Klein@gmail.com", PaymentContactNumber = "0133111847" },
                        new StudentModel { StudentFirstName = "Marvin", StudentLastName = "Henry", DOB = DateTime.Parse("15/01/1998"), GenderId = 3, GuardianName = "Macey Brooks", PaymentContactEmail = "Macey.Brooks@gmail.com", PaymentContactNumber = "0356879593" },
                        new StudentModel { StudentFirstName = "Kendrick", StudentLastName = "Thomas", DOB = DateTime.Parse("19/08/1997"), GenderId = 1, GuardianName = "Erica Perez", PaymentContactEmail = "Erica.Perez@gmail.com", PaymentContactNumber = "0107669420" },
                        new StudentModel { StudentFirstName = "Lea", StudentLastName = "Watts", DOB = DateTime.Parse("1/03/1995"), GenderId = 1, GuardianName = "Emery Haney", PaymentContactEmail = "Emery.Haney@gmail.com", PaymentContactNumber = "0169534317" },
                        new StudentModel { StudentFirstName = "Patrick", StudentLastName = "Mcclure", DOB = DateTime.Parse("9/10/2002"), GenderId = 1, GuardianName = "Kymani Wade", PaymentContactEmail = "Kymani.Wade@gmail.com", PaymentContactNumber = "0676173758" },
                        new StudentModel { StudentFirstName = "Rory", StudentLastName = "Glass", DOB = DateTime.Parse("25/09/1999"), GenderId = 3, GuardianName = "Noel Velazquez", PaymentContactEmail = "Noel.Velazquez@gmail.com", PaymentContactNumber = "0139044615" },
                        new StudentModel { StudentFirstName = "Jessie", StudentLastName = "Parrish", DOB = DateTime.Parse("24/08/1999"), GenderId = 1, GuardianName = "Gabriela Hurst", PaymentContactEmail = "Gabriela.Hurst@gmail.com", PaymentContactNumber = "0297715838" },
                        new StudentModel { StudentFirstName = "Jayson", StudentLastName = "Pace", DOB = DateTime.Parse("24/08/2001"), GenderId = 3, GuardianName = "Abigayle Barton", PaymentContactEmail = "Abigayle.Barton@gmail.com", PaymentContactNumber = "0421188077" },
                        new StudentModel { StudentFirstName = "Zaire", StudentLastName = "Mclean", DOB = DateTime.Parse("23/09/1997"), GenderId = 3, GuardianName = "Roy Brennan", PaymentContactEmail = "Roy.Brennan@gmail.com", PaymentContactNumber = "0478179846" },
                        new StudentModel { StudentFirstName = "Regina", StudentLastName = "Reid", DOB = DateTime.Parse("19/04/1996"), GenderId = 1, GuardianName = "Leah Mcintosh", PaymentContactEmail = "Leah.Mcintosh@gmail.com", PaymentContactNumber = "0537376170" },
                        new StudentModel { StudentFirstName = "Bronson", StudentLastName = "Cook", DOB = DateTime.Parse("29/12/2002"), GenderId = 1, GuardianName = "Cohen Buckley", PaymentContactEmail = "Cohen.Buckley@gmail.com", PaymentContactNumber = "0502033370" },
                        new StudentModel { StudentFirstName = "Carson", StudentLastName = "Mckay", DOB = DateTime.Parse("11/09/2001"), GenderId = 1, GuardianName = "Renee Wiley", PaymentContactEmail = "Renee.Wiley@gmail.com", PaymentContactNumber = "0616176434" },
                        new StudentModel { StudentFirstName = "Joel", StudentLastName = "Gardner", DOB = DateTime.Parse("31/05/1995"), GenderId = 1, GuardianName = "Brenden Yoder", PaymentContactEmail = "Brenden.Yoder@gmail.com", PaymentContactNumber = "0739000401" },
                        new StudentModel { StudentFirstName = "Brendon", StudentLastName = "Aguilar", DOB = DateTime.Parse("12/04/2002"), GenderId = 1, GuardianName = "Nadia Flynn", PaymentContactEmail = "Nadia.Flynn@gmail.com", PaymentContactNumber = "0192229706" },
                        new StudentModel { StudentFirstName = "Sebastian", StudentLastName = "Cunningham", DOB = DateTime.Parse("10/02/1996"), GenderId = 1, GuardianName = "Janessa Yu", PaymentContactEmail = "Janessa.Yu@gmail.com", PaymentContactNumber = "0159711510" },
                        new StudentModel { StudentFirstName = "Gavin", StudentLastName = "Mendez", DOB = DateTime.Parse("23/01/2000"), GenderId = 2, GuardianName = "Kelsey Bright", PaymentContactEmail = "Kelsey.Bright@gmail.com", PaymentContactNumber = "0793509175" },
                        new StudentModel { StudentFirstName = "Marc", StudentLastName = "Blake", DOB = DateTime.Parse("17/12/2002"), GenderId = 1, GuardianName = "Giada Hines", PaymentContactEmail = "Giada.Hines@gmail.com", PaymentContactNumber = "0675405030" },
                        new StudentModel { StudentFirstName = "Everett", StudentLastName = "Horton", DOB = DateTime.Parse("24/12/1999"), GenderId = 3, GuardianName = "Josiah Moore", PaymentContactEmail = "Josiah.Moore@gmail.com", PaymentContactNumber = "0439830290" },
                        new StudentModel { StudentFirstName = "Maximilian", StudentLastName = "Ashley", DOB = DateTime.Parse("29/01/1997"), GenderId = 3, GuardianName = "Hailee Nelson", PaymentContactEmail = "Hailee.Nelson@gmail.com", PaymentContactNumber = "0791006949" },
                        new StudentModel { StudentFirstName = "Keira", StudentLastName = "York", DOB = DateTime.Parse("11/01/1996"), GenderId = 2, GuardianName = "Kristina Caldwell", PaymentContactEmail = "Kristina.Caldwell@gmail.com", PaymentContactNumber = "0679078764" },
                        new StudentModel { StudentFirstName = "Davian", StudentLastName = "Jacobson", DOB = DateTime.Parse("10/06/1997"), GenderId = 3, GuardianName = "Gunnar Sparks", PaymentContactEmail = "Gunnar.Sparks@gmail.com", PaymentContactNumber = "0152517060" },
                        new StudentModel { StudentFirstName = "Olive", StudentLastName = "Nielsen", DOB = DateTime.Parse("1/02/2002"), GenderId = 2, GuardianName = "Brenton Petty", PaymentContactEmail = "Brenton.Petty@gmail.com", PaymentContactNumber = "0374924524" },
                        new StudentModel { StudentFirstName = "Sebastian", StudentLastName = "Livingston", DOB = DateTime.Parse("26/08/2000"), GenderId = 3, GuardianName = "Kadin Pruitt", PaymentContactEmail = "Kadin.Pruitt@gmail.com", PaymentContactNumber = "0511231428" },
                        new StudentModel { StudentFirstName = "Ben", StudentLastName = "James", DOB = DateTime.Parse("6/06/1996"), GenderId = 2, GuardianName = "Brock Burnett", PaymentContactEmail = "Brock.Burnett@gmail.com", PaymentContactNumber = "0555965937" },
                        new StudentModel { StudentFirstName = "Bryson", StudentLastName = "Holder", DOB = DateTime.Parse("24/03/2000"), GenderId = 2, GuardianName = "Hanna Knapp", PaymentContactEmail = "Hanna.Knapp@gmail.com", PaymentContactNumber = "0189292994" },
                        new StudentModel { StudentFirstName = "Bruce", StudentLastName = "Greer", DOB = DateTime.Parse("9/11/2001"), GenderId = 2, GuardianName = "Kassandra Noble", PaymentContactEmail = "Kassandra.Noble@gmail.com", PaymentContactNumber = "0158451105" },
                        new StudentModel { StudentFirstName = "Kamden", StudentLastName = "Joseph", DOB = DateTime.Parse("11/04/2001"), GenderId = 2, GuardianName = "Warren Moses", PaymentContactEmail = "Warren.Moses@gmail.com", PaymentContactNumber = "0396466139" },
                        new StudentModel { StudentFirstName = "Lane", StudentLastName = "Obrien", DOB = DateTime.Parse("3/05/1997"), GenderId = 3, GuardianName = "Alisson Downs", PaymentContactEmail = "Alisson.Downs@gmail.com", PaymentContactNumber = "0340112190" },
                        new StudentModel { StudentFirstName = "Addyson", StudentLastName = "Keith", DOB = DateTime.Parse("22/07/1999"), GenderId = 1, GuardianName = "Peyton Suarez", PaymentContactEmail = "Peyton.Suarez@gmail.com", PaymentContactNumber = "0378444772" },
                        new StudentModel { StudentFirstName = "Reilly", StudentLastName = "Walter", DOB = DateTime.Parse("5/07/1999"), GenderId = 1, GuardianName = "Braden Dickson", PaymentContactEmail = "Braden.Dickson@gmail.com", PaymentContactNumber = "0378871637" },
                        new StudentModel { StudentFirstName = "Brenna", StudentLastName = "Valenzuela", DOB = DateTime.Parse("28/10/2001"), GenderId = 3, GuardianName = "Callum Russell", PaymentContactEmail = "Callum.Russell@gmail.com", PaymentContactNumber = "0626104430" },
                        new StudentModel { StudentFirstName = "Philip", StudentLastName = "Crane", DOB = DateTime.Parse("7/06/2000"), GenderId = 1, GuardianName = "Chase Graham", PaymentContactEmail = "Chase.Graham@gmail.com", PaymentContactNumber = "0782904280" },
                        new StudentModel { StudentFirstName = "Cason", StudentLastName = "Kramer", DOB = DateTime.Parse("5/06/1999"), GenderId = 2, GuardianName = "Sarahi Middleton", PaymentContactEmail = "Sarahi.Middleton@gmail.com", PaymentContactNumber = "0691012988" },
                        new StudentModel { StudentFirstName = "Cruz", StudentLastName = "Hess", DOB = DateTime.Parse("6/09/2002"), GenderId = 1, GuardianName = "Rafael Becker", PaymentContactEmail = "Rafael.Becker@gmail.com", PaymentContactNumber = "0373428283" },
                        new StudentModel { StudentFirstName = "Kayleigh", StudentLastName = "Woodard", DOB = DateTime.Parse("2/04/1995"), GenderId = 3, GuardianName = "Kaelyn Kaiser", PaymentContactEmail = "Kaelyn.Kaiser@gmail.com", PaymentContactNumber = "0682207748" },
                        new StudentModel { StudentFirstName = "Elsie", StudentLastName = "Galloway", DOB = DateTime.Parse("23/11/1998"), GenderId = 1, GuardianName = "Dexter Olson", PaymentContactEmail = "Dexter.Olson@gmail.com", PaymentContactNumber = "0690558879" },
                        new StudentModel { StudentFirstName = "Rayan", StudentLastName = "Lucas", DOB = DateTime.Parse("8/05/1996"), GenderId = 3, GuardianName = "Itzel Oconnor", PaymentContactEmail = "Itzel.Oconnor@gmail.com", PaymentContactNumber = "0604035213" },
                        new StudentModel { StudentFirstName = "Jorden", StudentLastName = "Walter", DOB = DateTime.Parse("20/04/2001"), GenderId = 3, GuardianName = "Alisson Ryan", PaymentContactEmail = "Alisson.Ryan@gmail.com", PaymentContactNumber = "0607621893" },
                        new StudentModel { StudentFirstName = "Alexus", StudentLastName = "Bonilla", DOB = DateTime.Parse("10/09/1998"), GenderId = 3, GuardianName = "Adrien Charles", PaymentContactEmail = "Adrien.Charles@gmail.com", PaymentContactNumber = "0481836562" },
                        new StudentModel { StudentFirstName = "Romeo", StudentLastName = "Beck", DOB = DateTime.Parse("25/03/1997"), GenderId = 3, GuardianName = "Anton Mejia", PaymentContactEmail = "Anton.Mejia@gmail.com", PaymentContactNumber = "0370396441" },
                        new StudentModel { StudentFirstName = "Beckett", StudentLastName = "Henderson", DOB = DateTime.Parse("4/05/2002"), GenderId = 2, GuardianName = "Reece Farley", PaymentContactEmail = "Reece.Farley@gmail.com", PaymentContactNumber = "0621299025" },
                        new StudentModel { StudentFirstName = "Lawrence", StudentLastName = "Blankenship", DOB = DateTime.Parse("21/07/1998"), GenderId = 2, GuardianName = "Valerie Chung", PaymentContactEmail = "Valerie.Chung@gmail.com", PaymentContactNumber = "0552875163" },
                        new StudentModel { StudentFirstName = "Alec", StudentLastName = "Richards", DOB = DateTime.Parse("26/10/1996"), GenderId = 3, GuardianName = "Jeremy Lloyd", PaymentContactEmail = "Jeremy.Lloyd@gmail.com", PaymentContactNumber = "0121927561" },
                        new StudentModel { StudentFirstName = "Iliana", StudentLastName = "Willis", DOB = DateTime.Parse("21/06/1999"), GenderId = 2, GuardianName = "Julia Mccann", PaymentContactEmail = "Julia.Mccann@gmail.com", PaymentContactNumber = "0379374926" },
                        new StudentModel { StudentFirstName = "Nevaeh", StudentLastName = "Travis", DOB = DateTime.Parse("26/02/1996"), GenderId = 3, GuardianName = "Ishaan Camacho", PaymentContactEmail = "Ishaan.Camacho@gmail.com", PaymentContactNumber = "0219396531" },
                        new StudentModel { StudentFirstName = "Eric", StudentLastName = "Romero", DOB = DateTime.Parse("6/10/1996"), GenderId = 1, GuardianName = "Danny Burch", PaymentContactEmail = "Danny.Burch@gmail.com", PaymentContactNumber = "0347357320" },
                        new StudentModel { StudentFirstName = "Aryana", StudentLastName = "Wilcox", DOB = DateTime.Parse("27/12/2002"), GenderId = 2, GuardianName = "Frida Franco", PaymentContactEmail = "Frida.Franco@gmail.com", PaymentContactNumber = "0219504278" },
                        new StudentModel { StudentFirstName = "Liliana", StudentLastName = "Sweeney", DOB = DateTime.Parse("9/06/2002"), GenderId = 2, GuardianName = "Maxim Bird", PaymentContactEmail = "Maxim.Bird@gmail.com", PaymentContactNumber = "0295316387" },
                        new StudentModel { StudentFirstName = "Paris", StudentLastName = "Yates", DOB = DateTime.Parse("25/05/2002"), GenderId = 2, GuardianName = "Lara Heath", PaymentContactEmail = "Lara.Heath@gmail.com", PaymentContactNumber = "0154950390" }

                    );
                }
                context.SaveChanges();

                //Lessons

                if (!context.LessonModel.Any())
                {


                    context.LessonModel.AddRange(
                        new LessonModel { StudentId = 23, TutorId = 6, LessonTypeId = 3, LessonDateTime = DateTime.Parse("4/01/2022 7:00:00 AM"), Paid = false },
                        new LessonModel { StudentId = 14, TutorId = 10, LessonTypeId = 3, LessonDateTime = DateTime.Parse("6/07/2021 8:00:00 AM"), Paid = false },
                        new LessonModel { StudentId = 10, TutorId = 9, LessonTypeId = 1, LessonDateTime = DateTime.Parse("10/11/2022 9:00:00 AM"), Paid = false },
                        new LessonModel { StudentId = 13, TutorId = 5, LessonTypeId = 3, LessonDateTime = DateTime.Parse("20/12/2021 10:00:00 AM"), Paid = false },
                        new LessonModel { StudentId = 9, TutorId = 8, LessonTypeId = 1, LessonDateTime = DateTime.Parse("13/05/2022 11:00:00 AM"), Paid = true },
                        new LessonModel { StudentId = 6, TutorId = 10, LessonTypeId = 2, LessonDateTime = DateTime.Parse("21/07/2021 12:00:00 PM"), Paid = true },
                        new LessonModel { StudentId = 8, TutorId = 3, LessonTypeId = 2, LessonDateTime = DateTime.Parse("16/05/2022 1:00:00 PM"), Paid = false },
                        new LessonModel { StudentId = 3, TutorId = 7, LessonTypeId = 3, LessonDateTime = DateTime.Parse("24/03/2022 2:00:00 PM"), Paid = false },
                        new LessonModel { StudentId = 27, TutorId = 9, LessonTypeId = 2, LessonDateTime = DateTime.Parse("18/06/2022 3:00:00 PM"), Paid = false },
                        new LessonModel { StudentId = 48, TutorId = 3, LessonTypeId = 2, LessonDateTime = DateTime.Parse("1/02/2022 4:00:00 PM"), Paid = true },
                        new LessonModel { StudentId = 10, TutorId = 8, LessonTypeId = 2, LessonDateTime = DateTime.Parse("16/09/2022 5:00:00 PM"), Paid = true },
                        new LessonModel { StudentId = 43, TutorId = 4, LessonTypeId = 2, LessonDateTime = DateTime.Parse("2/03/2022 7:00:00 AM"), Paid = true },
                        new LessonModel { StudentId = 24, TutorId = 3, LessonTypeId = 2, LessonDateTime = DateTime.Parse("30/08/2022 8:00:00 AM"), Paid = true },
                        new LessonModel { StudentId = 20, TutorId = 3, LessonTypeId = 1, LessonDateTime = DateTime.Parse("24/11/2021 9:00:00 AM"), Paid = true },
                        new LessonModel { StudentId = 47, TutorId = 12, LessonTypeId = 2, LessonDateTime = DateTime.Parse("10/10/2022 10:00:00 AM"), Paid = true },
                        new LessonModel { StudentId = 14, TutorId = 4, LessonTypeId = 1, LessonDateTime = DateTime.Parse("28/04/2022 11:00:00 AM"), Paid = true },
                        new LessonModel { StudentId = 17, TutorId = 6, LessonTypeId = 3, LessonDateTime = DateTime.Parse("22/12/2022 12:00:00 PM"), Paid = true },
                        new LessonModel { StudentId = 13, TutorId = 12, LessonTypeId = 2, LessonDateTime = DateTime.Parse("5/01/2022 1:00:00 PM"), Paid = true },
                        new LessonModel { StudentId = 47, TutorId = 4, LessonTypeId = 3, LessonDateTime = DateTime.Parse("7/02/2022 2:00:00 PM"), Paid = true },
                        new LessonModel { StudentId = 4, TutorId = 9, LessonTypeId = 1, LessonDateTime = DateTime.Parse("31/05/2022 3:00:00 PM"), Paid = false },
                        new LessonModel { StudentId = 41, TutorId = 12, LessonTypeId = 3, LessonDateTime = DateTime.Parse("22/10/2022 4:00:00 PM"), Paid = false },
                        new LessonModel { StudentId = 12, TutorId = 8, LessonTypeId = 3, LessonDateTime = DateTime.Parse("22/10/2021 5:00:00 PM"), Paid = true },
                        new LessonModel { StudentId = 35, TutorId = 3, LessonTypeId = 3, LessonDateTime = DateTime.Parse("10/02/2022 7:00:00 AM"), Paid = true },
                        new LessonModel { StudentId = 12, TutorId = 8, LessonTypeId = 2, LessonDateTime = DateTime.Parse("10/10/2021 8:00:00 AM"), Paid = true },
                        new LessonModel { StudentId = 37, TutorId = 5, LessonTypeId = 2, LessonDateTime = DateTime.Parse("28/01/2022 9:00:00 AM"), Paid = true },
                        new LessonModel { StudentId = 42, TutorId = 4, LessonTypeId = 1, LessonDateTime = DateTime.Parse("21/07/2021 10:00:00 AM"), Paid = true },
                        new LessonModel { StudentId = 31, TutorId = 12, LessonTypeId = 3, LessonDateTime = DateTime.Parse("20/03/2022 11:00:00 AM"), Paid = false },
                        new LessonModel { StudentId = 3, TutorId = 3, LessonTypeId = 3, LessonDateTime = DateTime.Parse("10/12/2022 12:00:00 PM"), Paid = false },
                        new LessonModel { StudentId = 14, TutorId = 2, LessonTypeId = 1, LessonDateTime = DateTime.Parse("13/12/2021 1:00:00 PM"), Paid = false },
                        new LessonModel { StudentId = 7, TutorId = 8, LessonTypeId = 1, LessonDateTime = DateTime.Parse("19/01/2022 2:00:00 PM"), Paid = false },
                        new LessonModel { StudentId = 23, TutorId = 12, LessonTypeId = 2, LessonDateTime = DateTime.Parse("6/11/2021 3:00:00 PM"), Paid = false },
                        new LessonModel { StudentId = 3, TutorId = 10, LessonTypeId = 2, LessonDateTime = DateTime.Parse("31/10/2021 4:00:00 PM"), Paid = false },
                        new LessonModel { StudentId = 47, TutorId = 7, LessonTypeId = 1, LessonDateTime = DateTime.Parse("21/11/2021 5:00:00 PM"), Paid = false },
                        new LessonModel { StudentId = 39, TutorId = 11, LessonTypeId = 1, LessonDateTime = DateTime.Parse("3/10/2021 7:00:00 AM"), Paid = true },
                        new LessonModel { StudentId = 28, TutorId = 6, LessonTypeId = 1, LessonDateTime = DateTime.Parse("1/08/2022 8:00:00 AM"), Paid = true },
                        new LessonModel { StudentId = 38, TutorId = 9, LessonTypeId = 3, LessonDateTime = DateTime.Parse("4/09/2022 9:00:00 AM"), Paid = false },
                        new LessonModel { StudentId = 28, TutorId = 11, LessonTypeId = 2, LessonDateTime = DateTime.Parse("18/05/2022 10:00:00 AM"), Paid = false },
                        new LessonModel { StudentId = 26, TutorId = 8, LessonTypeId = 3, LessonDateTime = DateTime.Parse("24/11/2022 11:00:00 AM"), Paid = false },
                        new LessonModel { StudentId = 33, TutorId = 7, LessonTypeId = 2, LessonDateTime = DateTime.Parse("22/03/2022 12:00:00 PM"), Paid = false },
                        new LessonModel { StudentId = 3, TutorId = 10, LessonTypeId = 3, LessonDateTime = DateTime.Parse("15/04/2022 1:00:00 PM"), Paid = false },
                        new LessonModel { StudentId = 19, TutorId = 8, LessonTypeId = 1, LessonDateTime = DateTime.Parse("28/07/2021 2:00:00 PM"), Paid = false },
                        new LessonModel { StudentId = 49, TutorId = 4, LessonTypeId = 3, LessonDateTime = DateTime.Parse("7/12/2021 3:00:00 PM"), Paid = true },
                        new LessonModel { StudentId = 19, TutorId = 8, LessonTypeId = 3, LessonDateTime = DateTime.Parse("15/08/2021 4:00:00 PM"), Paid = true },
                        new LessonModel { StudentId = 10, TutorId = 3, LessonTypeId = 1, LessonDateTime = DateTime.Parse("13/11/2021 5:00:00 PM"), Paid = false },
                        new LessonModel { StudentId = 33, TutorId = 10, LessonTypeId = 2, LessonDateTime = DateTime.Parse("29/12/2021 7:00:00 AM"), Paid = false },
                        new LessonModel { StudentId = 27, TutorId = 9, LessonTypeId = 1, LessonDateTime = DateTime.Parse("9/07/2021 8:00:00 AM"), Paid = true },
                        new LessonModel { StudentId = 12, TutorId = 2, LessonTypeId = 1, LessonDateTime = DateTime.Parse("30/11/2022 9:00:00 AM"), Paid = false },
                        new LessonModel { StudentId = 22, TutorId = 7, LessonTypeId = 3, LessonDateTime = DateTime.Parse("22/11/2021 10:00:00 AM"), Paid = false },
                        new LessonModel { StudentId = 38, TutorId = 5, LessonTypeId = 1, LessonDateTime = DateTime.Parse("21/10/2022 11:00:00 AM"), Paid = false },
                        new LessonModel { StudentId = 15, TutorId = 10, LessonTypeId = 1, LessonDateTime = DateTime.Parse("11/07/2021 12:00:00 PM"), Paid = true },
                        new LessonModel { StudentId = 6, TutorId = 12, LessonTypeId = 2, LessonDateTime = DateTime.Parse("19/10/2022 1:00:00 PM"), Paid = false },
                        new LessonModel { StudentId = 19, TutorId = 5, LessonTypeId = 3, LessonDateTime = DateTime.Parse("9/08/2021 2:00:00 PM"), Paid = true },
                        new LessonModel { StudentId = 21, TutorId = 10, LessonTypeId = 1, LessonDateTime = DateTime.Parse("6/12/2021 3:00:00 PM"), Paid = false },
                        new LessonModel { StudentId = 27, TutorId = 4, LessonTypeId = 1, LessonDateTime = DateTime.Parse("26/05/2022 4:00:00 PM"), Paid = false },
                        new LessonModel { StudentId = 2, TutorId = 5, LessonTypeId = 2, LessonDateTime = DateTime.Parse("28/06/2022 5:00:00 PM"), Paid = false },
                        new LessonModel { StudentId = 13, TutorId = 9, LessonTypeId = 3, LessonDateTime = DateTime.Parse("28/07/2022 7:00:00 AM"), Paid = true },
                        new LessonModel { StudentId = 41, TutorId = 5, LessonTypeId = 2, LessonDateTime = DateTime.Parse("27/11/2022 8:00:00 AM"), Paid = true },
                        new LessonModel { StudentId = 26, TutorId = 3, LessonTypeId = 2, LessonDateTime = DateTime.Parse("5/02/2022 9:00:00 AM"), Paid = true },
                        new LessonModel { StudentId = 45, TutorId = 2, LessonTypeId = 3, LessonDateTime = DateTime.Parse("13/03/2022 10:00:00 AM"), Paid = false },
                        new LessonModel { StudentId = 2, TutorId = 5, LessonTypeId = 1, LessonDateTime = DateTime.Parse("1/12/2021 11:00:00 AM"), Paid = true },
                        new LessonModel { StudentId = 20, TutorId = 6, LessonTypeId = 1, LessonDateTime = DateTime.Parse("17/11/2022 12:00:00 PM"), Paid = true },
                        new LessonModel { StudentId = 40, TutorId = 5, LessonTypeId = 2, LessonDateTime = DateTime.Parse("15/11/2022 1:00:00 PM"), Paid = true },
                        new LessonModel { StudentId = 19, TutorId = 11, LessonTypeId = 1, LessonDateTime = DateTime.Parse("4/12/2022 2:00:00 PM"), Paid = true },
                        new LessonModel { StudentId = 14, TutorId = 6, LessonTypeId = 2, LessonDateTime = DateTime.Parse("10/10/2021 3:00:00 PM"), Paid = true },
                        new LessonModel { StudentId = 48, TutorId = 10, LessonTypeId = 3, LessonDateTime = DateTime.Parse("25/07/2021 4:00:00 PM"), Paid = false },
                        new LessonModel { StudentId = 26, TutorId = 2, LessonTypeId = 2, LessonDateTime = DateTime.Parse("3/12/2021 5:00:00 PM"), Paid = true },
                        new LessonModel { StudentId = 28, TutorId = 5, LessonTypeId = 1, LessonDateTime = DateTime.Parse("2/09/2021 7:00:00 AM"), Paid = false },
                        new LessonModel { StudentId = 7, TutorId = 8, LessonTypeId = 1, LessonDateTime = DateTime.Parse("14/11/2022 8:00:00 AM"), Paid = false },
                        new LessonModel { StudentId = 48, TutorId = 7, LessonTypeId = 2, LessonDateTime = DateTime.Parse("1/08/2022 9:00:00 AM"), Paid = true },
                        new LessonModel { StudentId = 25, TutorId = 6, LessonTypeId = 3, LessonDateTime = DateTime.Parse("1/11/2022 10:00:00 AM"), Paid = true },
                        new LessonModel { StudentId = 6, TutorId = 2, LessonTypeId = 3, LessonDateTime = DateTime.Parse("20/05/2022 11:00:00 AM"), Paid = false },
                        new LessonModel { StudentId = 7, TutorId = 9, LessonTypeId = 3, LessonDateTime = DateTime.Parse("29/10/2022 12:00:00 PM"), Paid = false },
                        new LessonModel { StudentId = 40, TutorId = 12, LessonTypeId = 2, LessonDateTime = DateTime.Parse("24/07/2021 1:00:00 PM"), Paid = true },
                        new LessonModel { StudentId = 24, TutorId = 4, LessonTypeId = 3, LessonDateTime = DateTime.Parse("4/03/2022 2:00:00 PM"), Paid = true },
                        new LessonModel { StudentId = 7, TutorId = 6, LessonTypeId = 1, LessonDateTime = DateTime.Parse("25/06/2022 3:00:00 PM"), Paid = true },
                        new LessonModel { StudentId = 45, TutorId = 10, LessonTypeId = 2, LessonDateTime = DateTime.Parse("14/07/2022 4:00:00 PM"), Paid = true },
                        new LessonModel { StudentId = 10, TutorId = 3, LessonTypeId = 3, LessonDateTime = DateTime.Parse("19/12/2022 5:00:00 PM"), Paid = false },
                        new LessonModel { StudentId = 37, TutorId = 2, LessonTypeId = 1, LessonDateTime = DateTime.Parse("23/07/2022 7:00:00 AM"), Paid = false },
                        new LessonModel { StudentId = 14, TutorId = 11, LessonTypeId = 2, LessonDateTime = DateTime.Parse("31/10/2021 8:00:00 AM"), Paid = false },
                        new LessonModel { StudentId = 29, TutorId = 10, LessonTypeId = 1, LessonDateTime = DateTime.Parse("3/11/2021 9:00:00 AM"), Paid = true },
                        new LessonModel { StudentId = 20, TutorId = 11, LessonTypeId = 3, LessonDateTime = DateTime.Parse("5/12/2021 10:00:00 AM"), Paid = true },
                        new LessonModel { StudentId = 6, TutorId = 7, LessonTypeId = 3, LessonDateTime = DateTime.Parse("26/01/2022 11:00:00 AM"), Paid = true },
                        new LessonModel { StudentId = 31, TutorId = 6, LessonTypeId = 3, LessonDateTime = DateTime.Parse("8/10/2021 12:00:00 PM"), Paid = true },
                        new LessonModel { StudentId = 7, TutorId = 6, LessonTypeId = 2, LessonDateTime = DateTime.Parse("22/05/2022 1:00:00 PM"), Paid = false },
                        new LessonModel { StudentId = 13, TutorId = 8, LessonTypeId = 2, LessonDateTime = DateTime.Parse("17/04/2022 2:00:00 PM"), Paid = false },
                        new LessonModel { StudentId = 43, TutorId = 10, LessonTypeId = 1, LessonDateTime = DateTime.Parse("7/07/2022 3:00:00 PM"), Paid = true },
                        new LessonModel { StudentId = 29, TutorId = 5, LessonTypeId = 1, LessonDateTime = DateTime.Parse("11/08/2021 4:00:00 PM"), Paid = true },
                        new LessonModel { StudentId = 42, TutorId = 11, LessonTypeId = 3, LessonDateTime = DateTime.Parse("24/04/2022 5:00:00 PM"), Paid = true },
                        new LessonModel { StudentId = 20, TutorId = 4, LessonTypeId = 1, LessonDateTime = DateTime.Parse("10/09/2022 7:00:00 AM"), Paid = false },
                        new LessonModel { StudentId = 25, TutorId = 12, LessonTypeId = 3, LessonDateTime = DateTime.Parse("1/06/2022 8:00:00 AM"), Paid = true },
                        new LessonModel { StudentId = 21, TutorId = 8, LessonTypeId = 1, LessonDateTime = DateTime.Parse("15/11/2021 9:00:00 AM"), Paid = true },
                        new LessonModel { StudentId = 38, TutorId = 8, LessonTypeId = 1, LessonDateTime = DateTime.Parse("9/10/2021 10:00:00 AM"), Paid = false },
                        new LessonModel { StudentId = 26, TutorId = 12, LessonTypeId = 2, LessonDateTime = DateTime.Parse("27/11/2021 11:00:00 AM"), Paid = true },
                        new LessonModel { StudentId = 31, TutorId = 12, LessonTypeId = 2, LessonDateTime = DateTime.Parse("1/08/2022 12:00:00 PM"), Paid = true },
                        new LessonModel { StudentId = 4, TutorId = 6, LessonTypeId = 3, LessonDateTime = DateTime.Parse("23/09/2022 1:00:00 PM"), Paid = true },
                        new LessonModel { StudentId = 28, TutorId = 3, LessonTypeId = 1, LessonDateTime = DateTime.Parse("6/03/2022 2:00:00 PM"), Paid = false },
                        new LessonModel { StudentId = 27, TutorId = 7, LessonTypeId = 3, LessonDateTime = DateTime.Parse("1/07/2022 3:00:00 PM"), Paid = false },
                        new LessonModel { StudentId = 35, TutorId = 11, LessonTypeId = 1, LessonDateTime = DateTime.Parse("4/12/2022 4:00:00 PM"), Paid = true },
                        new LessonModel { StudentId = 30, TutorId = 7, LessonTypeId = 2, LessonDateTime = DateTime.Parse("24/09/2022 5:00:00 PM"), Paid = false }



                    );
                }
                context.SaveChanges();

            }
        }
    }
}