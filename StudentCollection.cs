using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ÖvningGenerics20240403
{
    internal class StudentCollection : ICollection<Student>
    {
        //Lista där studenterna lagras
        private List<Student> innerCollection;
        public StudentCollection()
        {
            innerCollection = new List<Student>();
        }
        public Student this[int index]
        {
            //Returnerar studentens plats i indexet.
            get { return (Student)innerCollection[index]; }
            set { innerCollection[index] = value;}
        }

        //Sätter att StudentCollection -inte- är ReadOnly
        public bool IsReadOnly {get { return false;}}

        public void Add(Student item)
        {
            //Om StudentCollection -inte- innehåller den nya studenten vi vill lägga till
            if (!Contains(item))
            {
                //Lägg till student
                innerCollection.Add(item);
            }
            else
            {
                //Om studenten redan lagrats
                Console.WriteLine("This student is already registered int the collection.");
            }
        }

        public void Clear()
        {
            //Cleara hela innercollection
            innerCollection.Clear();
        }

        public bool Contains(Student item)
        {
            //Defaultvärde false (vi har inte sökt något än)
            bool found = false;

            //Söker igenom innerCollection där alla studenter lagras efter den valda studenten
            foreach (Student s in innerCollection)
            {
                //Om  objektet är detsamma som studenten vi söker efter
                if (s.Equals(item))
                {
                    //returnera true, studenten existerar
                    found = true;
                }
            }
            //Annars returnera false
            return found;
        }

        //Söker mer avancerat, jämför värdena i student med studenten vi söker efter. Kan användas om vi söker efter ett specifikt betyg kanske?
        public bool Contains(Student item, EqualityComparer<Student> comp)
        {
            bool found = false;
            foreach (Student s in innerCollection)
            {
                if (comp.Equals(s, item))
                {
                    found = true;
                }
            }
            return found;
        }

        public void CopyTo(Student[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<Student> GetEnumerator()
        {
            return new StudentEnumerator(this);
        }

        public bool Remove(Student item)
        {
            //Default värde innan vi sökt
            bool result = false;
            //Söker listan innerCollection för att hitta platsen studenten finns på
            for (int i = 0; i < innerCollection.Count; i++)
            {
                
                Student currentStudent = innerCollection[i];
                //Om studenten hittas i listan jämförs värdet med StudentSameProp för att hitta alla värden? 
                if (new StudentSameProp().Equals(currentStudent, item))
                {
                    //Tar bort studenten
                    innerCollection.RemoveAt(i);
                    result = true;

                    //Ut ur loopen
                    break;
                }
            }
            return result;
            //Returnera resultat
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new StudentEnumerator(this);
        }

        //Metod för att räkna hur många studenter som finns i innerCollection. 
        public int Count
        {
            get
            {
                return innerCollection.Count;
            }
        }
    }
}
