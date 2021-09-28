using System;
using System.Collections.Generic;

namespace lib
{
  public class Klass
  {
    public int Id { get; set; } // primary key
    public string Name { get; set; }
    public List<Student> Students { get; set; }
    public List<Teacher> Teachers { get; set; }
  }
}
