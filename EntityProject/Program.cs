// See https://aka.ms/new-console-template for more information
using EntityProject;

Console.WriteLine("Hello, World!");

var uniContext = new UniContext();
var services = new Services(uniContext);


// --------------- 1   UZDUOTIS-----------------------------

/*services.CreateDepartment("Jonas", "Fizika", "Technikos");*/



// --------------- 2   UZDUOTIS-----------------------------

/*services.AddToExistingDepartment("Marcius", "Matematika");*/


// --------------- 3  UZDUOTIS-----------------------------

/*services.CreateLecture("Mechanika");*/

// --------------- 6  UZDUOTIS-----------------------------

/*services.ShowStudents();*/


// --------------- 7  UZDUOTIS-----------------------------

services.ShowLectures();