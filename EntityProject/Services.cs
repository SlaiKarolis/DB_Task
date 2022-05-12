using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EntityProject
{
    internal class Services
    {
        private readonly UniContext _uniContext;
        public Services(UniContext unicontext)
        {
            _uniContext = unicontext;
        }
        public void CreateDepartment(string name, string lesson, string newDepartment)
        {
             var student = new Student() { Name = name };
             var lecture = new Lecture() { Name = lesson };
             var department = new Departament() { Name = newDepartment, Lectures = new List<Lecture>() { lecture}, Students = new List<Student>() { student}};
            _uniContext.Students.Add(student);
            _uniContext.Lectures.Add(lecture);
            _uniContext.Departaments.Add(department);
            _uniContext.SaveChanges();  
        }

        public void AddToExistingDepartment(string newName, string newLesson)
        {
            var newLecture = new Lecture() { Name = newLesson };
            var newStudent = new Student() { Name = newName };
            var existingDepartment = _uniContext.Departaments.FirstOrDefault(d => d.Id == 1); //duomenu bazeje egzistuojancio departamento Id yra vienetas
            existingDepartment.Lectures.Add(newLecture);
            existingDepartment.Students.Add(newStudent);
            _uniContext.SaveChanges();
        }

        public void CreateLecture(string newLesson)
        {
            var newLecture = new Lecture { Name = newLesson };
            var existingDepartment = _uniContext.Departaments.FirstOrDefault(d => d.Id == 1);
            existingDepartment.Lectures.Add(newLecture);
            _uniContext.SaveChanges();
        }

        public void AddNewStudentToExistingDepartmentAndLesson(string name)
        {
            var newStudent = new Student() { Name = name };
            var existingDepartment = _uniContext.Departaments.FirstOrDefault(d => d.Id == 1);
            existingDepartment.Students.Add(newStudent);
            _uniContext.Departaments.Update(existingDepartment);
            _uniContext.SaveChanges();
        }

        public void ShowStudents()
        {
            var allStudents = _uniContext.Departaments.Where(d => d.Id == 1).Include(d => d.Students);
            foreach (var department in allStudents)
            {
                Console.WriteLine($"{department.Name} studentai:");
                var students = department.Students;
                foreach (var item in students)
                {
                    Console.WriteLine(item.Name);
                }
            }
        }

        public void ShowLectures()
        {
            var allLectures = _uniContext.Departaments.Where(d => d.Id == 1).Include(d => d.Lectures);
            foreach (var department in allLectures)
            {
                Console.WriteLine($"{department.Name} departamentui priklausancios paskaitos:");
                var lectures = department.Lectures;
                foreach (var item in lectures)
                {
                    Console.WriteLine(item.Name);
                }
            }
        }

    }
}
