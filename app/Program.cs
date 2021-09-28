using System;
using System.Linq;
using lib;

namespace app
{
  class Program
  {
    static void Main(string[] args)
    {
      using var db = new Database();
      Student s = new Student() { Name = "Bob", Email = "very long email" };
      db.Add(s);
      db.SaveChanges();
    }
  }
}
