using System;
using System.Collections.Generic;

namespace lib
{
  public class Teacher
  {
    public int Id { get; set; } // primary key
    public string Name { get; set; }
    public List<Klass> Klasses { get; set; }

    public Teacher(string name)
    {
      Name = name;
      Klasses = new();
    }
  }
}
