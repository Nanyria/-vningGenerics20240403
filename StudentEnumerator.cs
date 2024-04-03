using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ÖvningGenerics20240403
{
    internal class StudentEnumerator : IEnumerator<Student>
    {
        private StudentCollection _students;
        private int currentIndex;
        private Student currentStudent;

        public StudentEnumerator(StudentCollection student)
        {
            _students = student;
            currentIndex = -1;
            //Varför -1?
            currentStudent = default(Student);
        }

        public Student Current {get { return currentStudent; } }

        object IEnumerator.Current { get { return Current; } }

        //Returnerar var studenten befinner siig i index?
        public int Count { get { return _students.Count; } }

        public void Dispose()
        {        }

        public bool MoveNext()
        {
            //om currentIndex är större än antalet studenter?
            if (++currentIndex >= _students.Count)
            {
                return false;
            }
            else
            {
                currentStudent = _students[currentIndex];
                return true;
            }
        }

        void IEnumerator.Reset()
        {
            throw new NotImplementedException();
        }
    }
}
