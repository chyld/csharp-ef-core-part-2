using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace lib
{
  public class Klass
  {
    [Key]
    public string Name { get; set; } // primary key
    public string Description { get; set; }
    public string Department { get; set; }
    public List<Student> Students { get; set; }
    public List<Registration> Registrations { get; set; }
    public List<Teacher> Teachers { get; set; }

    public Klass(string name)
    {
      Name = name;
      Students = new();
      Teachers = new();
    }
  }
}
