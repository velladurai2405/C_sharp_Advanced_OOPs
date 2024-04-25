using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeAdmission
{
    public static class Operations
    {
        static StudentDetails currentLoggedinStudent;
        //static List creation
        public static List<StudentDetails> studentList=new List<StudentDetails>();
        public static List<DepartmentDetails> departmentList=new List<DepartmentDetails>();
        public static List<AdmissionDetails>  admissionList=new List<AdmissionDetails>();

        //Main Menu
        public static void MainMenu()
        {
            Console.WriteLine("************Welcome to Synfusion college*************");
            string mainChoice="yes";
            do{
                //Need to show the main menu option.
                Console.WriteLine("MainMenu\n1.Student Registration\n2.Student Login3.Department wise seat availability\n4.Exit");
                //Need to get input from user and validate.
                System.Console.WriteLine("Select an option: ");
                int mainOption = int.Parse(Console.ReadLine());

                //Need create mainmenu structure
                switch (mainOption)
                {
                    case 1:
                        {
                            System.Console.WriteLine("***********Student Registration************");
                            StudentRegistration();
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("************Student Login************");
                            StudentLogin();
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("*************Department wise seat availability************");
                            DepartmentWiseSeatAvailability();
                            break;
                        }
                    case 4:
                        {
                            System.Console.WriteLine("Exited succesfully"); 
                            mainChoice="no";
                            break;
                        }
                }
                //Need to until the option exit
            }while(mainChoice=="yes");

        }//Main menu ends

        //Student regsitration
        public static void StudentRegistration()
        {
            //Need to get required details
            Console.Write("Enter your name: ");
            string studentName=Console.ReadLine();
            Console.Write("Enter your father name: ");
            string fatherName=Console.ReadLine();
            Console.Write("Enter your DOB: ");
            DateTime dob=DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy",null);
            Console.Write("Enter your gender: Male or Female or Transgender: ");
            Gender gender;
            bool temp = Enum.TryParse<Gender>(Console.ReadLine(), true, out gender);
            while (!temp)
            {
                Console.WriteLine("Invalid gender,Please reenter.");
                temp = Enum.TryParse<Gender>(Console.ReadLine(), true, out gender);
            }
            System.Console.Write("Enter your physics marks: ");
            int physicsMark = int.Parse(Console.ReadLine());
            System.Console.Write("Enter chemistry marks: ");
            int chemistryMark = int.Parse(Console.ReadLine());
            System.Console.Write("Enter your maths marks:");
            int mathsMark = int.Parse(Console.ReadLine());
            //Need to create an object
            StudentDetails student = new StudentDetails(studentName, fatherName, dob, gender, physicsMark, chemistryMark, mathsMark);
            studentList.Add(student);
            Console.WriteLine($"Registered successfully.And your registered id is:{student.StudentID}");

        }//Student regsitration ends
        //student Login
        public static void StudentLogin()
        {
            //Need to get ID input in the list
            Console.Write("Enter your student ID"); 
            string login=Console.ReadLine().ToUpper();
            bool flag=true;
            foreach(StudentDetails student in studentList)
            {
                if(login.Equals(student.StudentID))
                {
                    flag=false;
                    //Assigning current user to global variable-(Its like object)
                    currentLoggedinStudent=student;
                    //Need to call submneu
                    SubMenu();
                    break;

                }
            }
            if(flag==false)
            {
                Console.WriteLine("Invalid ID");
            }
            //If not-Invalid input

        }//student Login ends
        //submenu starts
        public static void SubMenu()
        {
            string subChoice="yes";
            do
            {
                Console.WriteLine("**********SubMenu************");
                Console.WriteLine("1.Check Eligibility\n2.Show Details\n3.Take Admission\n4.Cancel Admission\n5.Show Admission Details\n6.Exit");
                //Need to show submenu option
                Console.Write("Enter an option: ");
                int subOption=int.Parse(Console.ReadLine());
                switch(subOption)
                {
                    case 1:
                    {
                        Console.WriteLine("**********Check Eligibility***********");
                        CheckEligiblity();
                        break;
                    }
                    case 2:
                    {
                        Console.WriteLine("**********Show Details***********");
                        ShowDetails();
                        break;
                    }
                    case 3:
                    {
                        Console.WriteLine("**********Take Admission***********");
                        TakeAdmission();
                        break;
                    }
                    case 4:
                    {
                        Console.WriteLine("**********Cancel Admission***********");
                        CancelAdmission();
                        break;
                    }
                    case 5:
                    {
                        Console.WriteLine("**********Show Admission Details***********");
                        ShowAdmissionDetails();
                        break;
                    }
                     case 6:
                    {
                        Console.WriteLine("Taking Back to Main Menu");
                        subChoice="no";
                        break;
                    }
                }
                //Getting user option
                //Iterate till the option is exit
                

            }while(subChoice=="yes");
        }//submenu ends
        //CheckEligiblity
        public static void CheckEligiblity()
        {
            //Get cutoff value as input
            Console.Write("Enter cutoff value: ");
            double cutoff=double.Parse(Console.ReadLine());
            //check Eligibility or not
            if(currentLoggedinStudent.CheckEligibility(cutoff))
            {
                Console.WriteLine("Student is eligible");
            }
            else
            {
                Console.WriteLine("Student is not eligible");
            }

        }//CheckEligiblity ends
        //ShowDetails starts
        public static void ShowDetails()
        {
            //Need to show the current login student details
            Console.WriteLine("|Student ID|Student Name|Father Name|DOB|Gender|Physic Mark|Chemistry Mark|Maths Mark");
            Console.WriteLine($"|{currentLoggedinStudent.StudentID}|{currentLoggedinStudent.StudentName}|{currentLoggedinStudent.FatherName}|{currentLoggedinStudent.DOB}|{currentLoggedinStudent.Gender}|{currentLoggedinStudent.PhysicsMark}|{currentLoggedinStudent.ChemistryMark}|{currentLoggedinStudent.MathsMark}");
            Console.WriteLine();

        }//ShowDetails ends
        //TakeAdmission
        public static void TakeAdmission()
        {
            //Need to show available department details
            DepartmentWiseSeatAvailability();
            //Ask deparment id from user
            Console.Write("Select deparment ID");
            string departmentID=Console.ReadLine();
            //check the ID is present or not
            bool flag=true;
            foreach(DepartmentDetails department in departmentList)
            {
                if(departmentID.Equals(department.DepartmentID))
                {
                    flag=false;
                    //check the student is eligible or not 
                    if(currentLoggedinStudent.CheckEligibility(75))
                    {
                        //check seat availability
                        if(department.NumberOfSeats>0)
                        {
                            int count=0;
                            //check student already taken any admission
                            foreach(AdmissionDetails admission in admissionList)
                            {
                                if(currentLoggedinStudent.StudentID.Equals(admission.StudentID)&&admission.AdmissionStatus.Equals(AdmissionStatus.Admitted))
                                {
                                    count++;
                                }
                            }
                            if(count==0)
                            {
                                // create admission object
                                AdmissionDetails admissionTaken=new AdmissionDetails(currentLoggedinStudent.StudentID,department.DepartmentID,DateTime.Now,AdmissionStatus.Admitted);
                                //reduce seat count
                                department.NumberOfSeats--;
                                // add to admission list
                                admissionList.Add(admissionTaken);
                                //Display admission successful message.
                                Console.WriteLine($"You have took admission succefully and your admission ID is{admissionTaken.AdmissionID}");
                            }
                            else
                            {
                                Console.WriteLine("You have already taken admission");
                            }


                        }
                        
                        
                        
                       
                    }
                    else
                    {
                        Console.WriteLine("Student not eligible");
                    }
                    
                }
            }
            if(flag)
            {
                Console.WriteLine("Invalid ID");
            }
            

        }//TakeAdmission ends
        //CancelAdmission starts
        public static void CancelAdmission()
        {
            //check the student is taken any admission and display it
            bool flag=true;
            foreach(AdmissionDetails admission in admissionList)
            {
                if(currentLoggedinStudent.StudentID.Equals(admission.StudentID)&&admission.AdmissionStatus.Equals(AdmissionStatus.Admitted))
                {
                    flag=false;
                    //cancel found admission
                    admission.AdmissionStatus=AdmissionStatus.Cancelled;
                    foreach(DepartmentDetails department in departmentList)
                    {
                        if(admission.DepartmentID.Equals(department.DepartmentID))
                        {
                            department.NumberOfSeats++;
                            break;
                        }
                    }
                    //return seat to department

                }
                break;
            }
            if(flag)
            {
                Console.WriteLine("You have no admission toi cancel.");
            }
            

        }//CancelAdmission ends
        //ShowAdmissionDetails starts
        public static void ShowAdmissionDetails()
        {
            //Need to show current loggedin student's admission details
             foreach(AdmissionDetails admission in admissionList)
            {
                if(currentLoggedinStudent.StudentID.Equals(admission.StudentID))
                {
                    Console.WriteLine("|AdmissionID|StudentID|DepartmentID|AdmissionDate|AdmissionStatus");
                    Console.WriteLine($"{admission.AdmissionID}|{admission.StudentID}|{admission.DepartmentID}|{admission.AdmissionDate}|{admission.AdmissionStatus}");
                }
            }
            Console.WriteLine();

        }//ShowAdmissionDetails ends
        //DepartmentwiseSeatAvailability
        public static void DepartmentWiseSeatAvailability()
        {
            Console.WriteLine("DepartmentID|DepartMentName|NumberOfSeats");
            foreach(DepartmentDetails department in departmentList)
            {
                Console.WriteLine($"{department.DepartmentID}|{department.DepartmentName}|{department.NumberOfSeats}");
            }
            Console.WriteLine();
        }//DepartmentwiseSeatAvailability ends

        public static void AddDefaultData()
        {
            StudentDetails student1=new StudentDetails("Ravichandran","Ettapparajan",new DateTime(1999,11,11),Gender.Male,95,95,95);
            StudentDetails student2=new StudentDetails("Baskaran","Sethurajan",new DateTime(1999,11,11),Gender.Male,95,95,95);
            studentList.AddRange(new List<StudentDetails>{student1,student2});

            DepartmentDetails department1=new DepartmentDetails("EEE",29);
            DepartmentDetails department2=new DepartmentDetails("CSE",29);
            DepartmentDetails department3=new DepartmentDetails("MECH",30);
            DepartmentDetails department4=new DepartmentDetails("ECE",30);
            departmentList.AddRange(new List<DepartmentDetails>{department1,department2,department3,department4});

            AdmissionDetails admission1=new AdmissionDetails(student1.StudentID,department1.DepartmentID,new DateTime(2022,05,11),AdmissionStatus.Admitted);
            AdmissionDetails admission2=new AdmissionDetails(student2.StudentID,department1.DepartmentID,new DateTime(2022,05,11),AdmissionStatus.Admitted);
            admissionList.AddRange(new List<AdmissionDetails>{admission1,admission2});

            //printing the data
            foreach(StudentDetails student in studentList)
            {
                Console.WriteLine($"|{student.StudentID}|{student.StudentName}|{student.FatherName}|{student.DOB}|{student.Gender}|{student.PhysicsMark}|{student.ChemistryMark}|{student.MathsMark}");
            }
            Console.WriteLine();
            foreach(DepartmentDetails department in departmentList)
            {
                Console.WriteLine($"{department.DepartmentID}|{department.DepartmentName}|{department.NumberOfSeats}");
            }
            Console.WriteLine();
            foreach(AdmissionDetails admission in admissionList)
            {
                Console.WriteLine($"{admission.AdmissionID}|{admission.StudentID}|{admission.DepartmentID}|{admission.AdmissionDate}|{admission.AdmissionStatus}");
            }
            Console.WriteLine();

        }//Default data ends
        
    }
}