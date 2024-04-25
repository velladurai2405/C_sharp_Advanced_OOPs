using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeAdmission
{
    //enum
    public enum AdmissionStatus{Select,Admitted,Cancelled}
    public class AdmissionDetails
    {
        //field
        private static int s_admissionID=1000;
        //properties
        public string AdmissionID { get; set; }
        public string StudentID { get; set; }
        public string DepartmentID { get; set; }
        public DateTime AdmissionDate { get; set; }
        public AdmissionStatus AdmissionStatus { get; set; }

        //constructor
        public AdmissionDetails(string studentID,string departmentID,DateTime admissionDate,AdmissionStatus admissionStatus)
        {
            //Auto increment
            s_admissionID++;
            AdmissionID="AID"+s_admissionID;
            StudentID=studentID;
            DepartmentID=departmentID;
            AdmissionDate=admissionDate;
            AdmissionStatus=admissionStatus;
        }

        /*a.	AdmissionID – (Auto Increment ID - AID1001)
            b.	StudentID
            c.	DepartmentID
            d.	AdmissionDate
            e.	AdmissionStatus – Enum- (Select, Admitted, Cancelled)
            */
    }
}