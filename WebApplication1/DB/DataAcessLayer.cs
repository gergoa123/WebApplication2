using Microsoft.EntityFrameworkCore;

namespace WebApplication1.DB
{
    public class DataAcessLayer
    {
        private static DataAcessLayer? instance = null;
        private readonly Context ctx;

        public static DataAcessLayer Instance
        {
            get
            {
                instance ??= new DataAcessLayer();

                return instance; 
            }
        }

        private DataAcessLayer()
        {
            ctx = new Context();
        }

        public void ResetDb()
        {
            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();

            var addr = new Adresa()
            {
                Numar = "10",
                Oras = "Zalau",
                Strada = "NuAreNume"
            };

            var sub1 = new Subject()
            {
                Name = "Matematica"
            };

            var sub2 = new Subject()
            {
                Name = "Informatica"
            };

            var sub3 = new Subject()
            {
                Name = "Romana"
            };

            var marks1 = new List<Mark>()
            {
                new Mark()
                {
                    Subject = sub1,
                    Nota = 9,
                    Date = new DateTime()
                },
                new Mark()
                {
                    Subject = sub1,
                    Nota = 4,
                    Date = new DateTime()
                },
                new Mark()
                {
                    Subject = sub2,
                    Nota = 8,
                    Date = new DateTime()
                },
            };

            var marks2 = new List<Mark>()
            {
                new Mark()
                {
                    Subject = sub1,
                    Nota = 5,
                    Date = new DateTime()
                },
                new Mark()
                {
                    Subject = sub1,
                    Nota = 3,
                    Date = new DateTime()
                },
                new Mark()
                {
                    Subject = sub2,
                    Nota = 6,
                    Date = new DateTime()
                },
            };

            var stud1 = new Student()
            {
                Nume = "Lewis",
                Prenume = "Big",
                Varsta = 15,
                Adresa = addr,
                Marks = marks1
            };

            var stud2 = new Student()
            {
                Nume = "John",
                Prenume = "Big",
                Varsta = 25,
                Adresa = addr,
                Marks = marks2
            };

            ctx.Adresses.Add(addr);

            ctx.Subjects.Add(sub1);
            ctx.Subjects.Add(sub2);
            ctx.Subjects.Add(sub3);

            ctx.Studenti.Add(stud1);
            ctx.Studenti.Add(stud2);

            ctx.SaveChanges();
        }

        public List<Student> GetStudents()
        {
            List<Student> students = new();
            foreach (var student in ctx.Studenti)
            {
                students.Add(student);
            }
            return students;
        }

        public Student GetStudentById(int id) => ctx.Studenti.Find(id);

        public string CreateStudent(Student stud)
        {
            var res1 = ctx.Studenti.Add(stud);

            var res2 = ctx.SaveChanges();

            if (res1 != null && res2 >= 0)
            {
                return "";
            }
            else
            {
                return "Create error";
            }
        }

        public string DeleteStudent(int id)
        {
            var res3 = ctx.Studenti.Find(id);

            if (res3 == null)
            {
                return "Delete error: Not found";
            }

            var res4 = ctx.Studenti.Remove(res3);

            if (res4 == null)
            {
                return "Delete error: Couldn't remove";
            }

            var res5 = ctx.SaveChanges();

            if (res5 < 0)
            {
                return "Delete error";
            }

            return "";
            
        }

        public string ChangeStudent(Student stud)
        {
            var student = ctx.Studenti.Include(s => s.Adresa).FirstOrDefault(s => s.Id == stud.Id);

            if (student == null)
            {
                return "Student not found";
            }
            else { 
                student.Nume = stud.Nume;
                student.Prenume = stud.Prenume;
                student.Varsta = stud.Varsta;
                student.Adresa.Numar = stud.Adresa.Numar;
                student.Adresa.Strada = stud.Adresa.Strada;
                student.Adresa.Oras = stud.Adresa.Oras;
                student.Adresa.Id = stud.Adresa.Id;
                 
                ctx.SaveChanges();
            
                return "";
            }

        }

        public int ChangeStudentAddress(int studentId, Adresa adresa)
        {
            var student = ctx.Studenti.Include(s => s.Adresa).FirstOrDefault(s => s.Id == studentId);

            if (student == null)
            {
                return 0;
            }
            if (student.Adresa == null)
            {
                if (student.Adresa == null)
                {
                    student.Adresa = new()
                    {
                        Numar = adresa.Numar,
                        Strada = adresa.Strada,
                        Oras = adresa.Oras
                    };
                    ctx.SaveChanges();
                    return 2;
                }
                else
                {
                    return 0;
                }
            }
            student.Adresa.Numar = adresa.Numar;
            student.Adresa.Strada = adresa.Strada;
            student.Adresa.Oras = adresa.Oras;

            ctx.SaveChanges();

            return 1;
        }

        public int DeleteStudentPlus(int studentId)
        {
            var student = ctx.Studenti.Include(s => s.Adresa).FirstOrDefault(s => s.Id == studentId);
            var res = ctx.Studenti.Remove(student);

            if (res == null)
            {
                return 1;
            }
            else
            {
                ctx.SaveChanges();
                return 0;
            }

        }
        
        public string CreateSubject(Subject subject)
        {
            var res1 = ctx.Subjects.Add(subject);
            
            var res2 = ctx.SaveChanges();

            if (res1 != null && res2 >= 0)
            {
                return "";
            }
            else
            {
                return "Subject creation error";
            }
        }

        public string AddMark(int studId, Mark mark)
        {
            var student = ctx.Studenti.Find(studId);
            
            if(student == null)
            {
                return "No student found";
            }

            student.Marks.Add(mark);

            var res = ctx.SaveChanges();

            if (res >= 0)
            {
                return "";
            }
            else
            {
                return "Mark add error";
            }
        }

        public List<Mark> GetMarks()
        {
            List<Mark> marks = new();
            foreach (var Mark in ctx.Marks)
            {
                marks.Add(Mark);
            }

            return marks;
           

        }
    }
}
