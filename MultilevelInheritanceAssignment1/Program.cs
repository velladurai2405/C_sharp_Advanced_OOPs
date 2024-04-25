using System;
namespace MultilevelInheritanceAssignment1;
class Program{
    public static void Main(string[] args)
    {
        PersonalInfo personal=new PersonalInfo("velladurai","jeyaraj",123456,"vella@mail.com",new DateTime(22/04/2024),"male");
        
        StudentInfo student=new StudentInfo();

        student.GetStudentInfo();
    }
}
