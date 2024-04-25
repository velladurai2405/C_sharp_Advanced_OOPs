using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SealedClassesAssignment2
{
    public class DoctorInfo:PatientInfo //I got this error-'DoctorInfo': cannot derive from sealed type 'PatientInfo'
    {                                   //because seaded class cannot inherit
        private static int s_doctorID=1000;
        //DoctorID, Name, FatherName
        public string DoctorID { get; set; }
        public string Name { get; set; }
        public string FatherName { get; set; }

        public DoctorInfo(string doctorID,string name,string fatherName)
        {
            s_doctorID++;
            DoctorID="DID"+s_doctorID;
            Name=name;
            FatherName=fatherName;
        }

    }
}