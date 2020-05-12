using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace MMSEApp.Models
{
    public class PatientItem
    {
        public int PatientID { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; } 
        public DateTime PatientDOB { get; set; }
        public DateTime LastTestDate { get; set; }

    }

    
}
