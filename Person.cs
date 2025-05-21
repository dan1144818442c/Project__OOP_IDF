using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_idf___
{
    internal class Person
    {
        protected string Firstname;
        protected string Lastname;
        protected int age;
        public Person( string first_name ,string last_name , int age) {
        this.Firstname = first_name;
        this.Lastname = last_name;
        this.age = age;
        }
    }
}
