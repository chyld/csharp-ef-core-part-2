using System;
using System.Collections.Generic;

namespace lib
{
  public class Teacher
  {
    public int TeacherId { get; set; } // primary key
    public string Name { get; set; }
    public List<Klass> Klasses { get; set; }
  }
}
