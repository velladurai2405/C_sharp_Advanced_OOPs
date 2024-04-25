using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Threading.Tasks;

namespace SealedClassesAssignment2
{
    public sealed class PatientInfo
    {
        private static int s_patientID=1000;
        //PatientID, Name, FatherName, BedNo, NativePlace, AdmittedFor
        public string PatientID { get; set; }
        public string Name { get; set; }
        public string FatherName { get; set; }
        public int BedNo { get; set; }
        public string NativePlace { get; set; }
        public string AdmittedFor { get; set; }

        public PatientInfo(string name,string fatherName,int bedNo,string nativePlace,string admittedFor)
        {
            s_patientID++;
            PatientID="PID"+s_patientID;
            Name=name;
            FatherName=fatherName;
            BedNo=bedNo;
            NativePlace=nativePlace;
            AdmittedFor=admittedFor;

        }

        
    }
}