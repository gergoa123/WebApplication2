using Microsoft.EntityFrameworkCore;

namespace WebApplication1.DB
{
    public class DataAccessLayer
    {
        public void ResetDb()
        {
            Context ctx = new();
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
            Context ctx = new();
            List<Student> students = new();
            foreach (var student in ctx.Studenti)
            {
                students.Add(student);
            }
            return students;
        }

        public Student GetStudentById(int id)
        {
            Context ctx = new();
            return ctx.Studenti.Find(id);
        }

        public void CreateStudent(Student stud)
        {
            Context ctx = new();
            var res1 = ctx.Studenti.Add(stud);

            var res2 = ctx.SaveChanges();

            if (!(res1 != null && res2 >= 0))
            {
                throw new Exception("Create error");
            }
        }

        public void DeleteStudent(int id)
        {
            Context ctx = new();
            var student = ctx.Studenti.Find(id);

            if (student == null)
            {
                throw new Exception("Find error");
            }
            if (ctx.Studenti.Remove(student) == null)
            {
                throw new Exception("Deletion error");
            }
            if (ctx.SaveChanges() < 0)
            {
                throw new Exception("Save error");
            }
            
        }

        public void ChangeStudent(Student stud)
        {
            Context ctx = new();
            var student = ctx.Studenti.Include(s => s.Adresa).FirstOrDefault(s => s.Id == stud.Id);

            if (student == null)
            {
                throw new Exception("Student not found");
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
            }
        }

        public void ChangeStudentAddress(int studentId, Adresa adresa)
        {
            Context ctx = new();
            var student = ctx.Studenti.Include(s => s.Adresa).FirstOrDefault(s => s.Id == studentId);

            if (student == null)
            {
                throw new Exception("An error occured");
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
                }
                else
                {
                    throw new Exception("An error occured");
                }
            }
            student.Adresa.Numar = adresa.Numar;
            student.Adresa.Strada = adresa.Strada;
            student.Adresa.Oras = adresa.Oras;

            ctx.SaveChanges();
        }

        public void DeleteStudentPlus(int studentId)
        {
            Context ctx = new();
            var student = ctx.Studenti.Include(s => s.Adresa).FirstOrDefault(s => s.Id == studentId);

            if (student == null ||  ctx.Studenti.Remove(student) == null)
            {
                throw new Exception("An error occured");
            }
            ctx.SaveChanges();

        }
        
        public void CreateSubject(Subject subject)
        {
            Context ctx = new();
            if (ctx.Subjects.Add(subject) == null || ctx.SaveChanges() < 0)
            {
                throw new Exception("Subject creation error");
            }
        }

        public void AddMark(int studId, Mark mark)
        {
            Context ctx = new();
            var student = ctx.Studenti.Find(studId);
            
            if(student == null)
            {
                throw new Exception("No student found");
            }

            student.Marks.Add(mark);

            if (ctx.SaveChanges() < 0)
            {
                throw new Exception("Mark add error");
            }
        }

        public List<Mark> GetMarks()
        {
            Context ctx = new();
            List<Mark> marks = new();
            foreach (var Mark in ctx.Marks)
            {
                marks.Add(Mark);
            }

            return marks;
        }
    }
}
