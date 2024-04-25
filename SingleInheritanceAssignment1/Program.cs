using System;
namespace SingleInheritanceAssignment1;
class Program{
    public static void Main(string[] args)
    {
        PersonalInfo personal=new PersonalInfo("velladurai","jeyaraj",123456,"vella@mail.com",new DateTime(22/04/2024),"male");
        StudentInfo student =new StudentInfo(personal.Name,personal.FatherName,personal.Phone,personal.Mail,personal.DOB,personal.Gender,12,"bilogy",2023);
        student.ShowStudentInfo();
    }
}
