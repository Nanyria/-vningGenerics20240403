using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ÖvningGenerics20240403
{
    internal class Student:IEquatable<Student>
    {

        public int ID { get; set; }
        public int Grade { get; set; }
        public int Total { get; set; }

        public Student(int id, int grade, int total)
        {
            this.ID = id;
            this.Grade = grade;
            this.Total = total;
        }

        public bool Equals(Student? other)
        {
            if (new StudentSameProp().Equals(this, other))
            {
                return true;
            }

            else 
            {
                return false; 
            }
            
        }
    }
    
}
