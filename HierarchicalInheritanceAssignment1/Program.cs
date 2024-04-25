using System;
namespace HierarchicalInheritanceAssignment1;
class Program{
    public static void Main(string[] args)
    {
        //object creation
        PersonalInfo personal =new PersonalInfo("vella","jeyaraj",12334,new DateTime(22/03/2023),"male","vella@mail");
        TeacherInfo teacher =new TeacherInfo(personal.Name,personal.FatherName,personal.Phone,personal.DOB,personal.Gender,personal.Mail,"Mechanical","solid mechanics","M.Tech",10,new DateTime(22/03/2010));
        StudentInfo student=new StudentInfo(personal.Name,personal.FatherName,personal.Phone,personal.DOB,personal.Gender,personal.Mail,"enginnering","Mechanical",7);
        PrincipalInfo principal=new PrincipalInfo(personal.Name,personal.FatherName,personal.Phone,personal.DOB,personal.Gender,personal.Mail,"PhD","10",new DateTime(12/12/2023));

        //Method calling
        teacher.ShowDetails();
        student.ShowDetails();
        principal.ShowDetails();
    }
}


