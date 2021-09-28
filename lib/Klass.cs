using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace lib
{
  public class Klass
  {
    [Key]
    public string Name { get; set; } // primary key
    [Required]
    public string Description { get; set; }
    public string Department { get; set; }
    public List<Student> Students { get; set; }
    public List<Teacher> Teachers { get; set; }
  }
}
