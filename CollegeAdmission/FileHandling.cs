using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeAdmission
{
    public static class FileHandling
    {
        public static void Create()
        {
            if(!Directory.Exists("CollegeAdmission"))
            {
                Console.WriteLine("Creating folder.");
                Directory.CreateDirectory("CollegeAdmission");
            }
            if(File.Exists("CollegeAdmission/StudentDetails.csv"))
            {
                Console.WriteLine("File creating....");
                File.Create("CollegeAdmission/StudentDetails.csv").Close();
            }
            if(File.Exists("CollegeAdmission/DepartmentDetails.csv"))
            {
                Console.WriteLine("File creating....");
                File.Create("CollegeAdmission/DepartmentDetails.csv").Close();
            }
            if(File.Exists("CollegeAdmission/AdmissionDetails.csv"))
            {
                Console.WriteLine("File creating....");
                File.Create("CollegeAdmission/AdmissionDetails.csv").Close();
            }
        }

        public static void WriteToCSV()
        {
            string[] students=new string[Operations.studentList.Count];
            for(int i=0;i<Operations.studentList.Count;i++)
            {
                students[i]=Operations.studentList[i].StudentID+","+Operations.studentList[i].StudentName+","+Operations.studentList[i].FatherName+","+Operations.studentList[i].DOB.ToString("dd/MM/yyyy")+","+Operations.studentList[i].Gender+","+Operations.studentList[i].PhysicsMark+","+Operations.studentList[i].ChemistryMark+","+Operations.studentList[i].MathsMark;
            }
            File.WriteAllLines("CollegeAdmission/StudentDetails.csv",students);

            string[] departments=new string[Operations.departmentList.Count];
            for(int i=0;i<Operations.departmentList.Count;i++)
            {
                departments[i]=Operations.departmentList[i].DepartmentID+","+Operations.departmentList[i].DepartmentName+","+Operations.departmentList[i].NumberOfSeats;
            }
            File.WriteAllLines("CollegeAdmission/DepartmentDetails.csv",departments);

            string[] admissions=new string[Operations.admissionList.Count];
            for(int i=0;i<Operations.admissionList.Count;i++)
            {
                admissions[i]=Operations.admissionList[i].AdmissionID+","+Operations.admissionList[i].StudentID+","+Operations.admissionList[i].DepartmentID+","+Operations.admissionList[i].AdmissionDate+","+Operations.admissionList[i].AdmissionStatus;
            }
            File.WriteAllLines("CollegeAdmission/AdmissionDetails.csv",admissions);
        }

        public static void ReadCSV()
        {
            string[] students=File.ReadAllLines("CollegeAdmission/StudentDetails.csv");
            foreach(string student in students)
            {
                StudentDetails student1=new StudentDetails(student);
            }
            string[] deparments=File.ReadAllLines("CollegeAdmission/DepartmentDetails.csv");
            foreach(string deparment in deparments)
            {
                DepartmentDetails deparment1=new DepartmentDetails(deparment);
            }

        }
        
    }
}