using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib
{

  [Table("Registrations")]
  public class Registration
  {
    public Student Student { get; set; }
    public Klass Klass { get; set; }
    public double Grade { get; set; }
  }
}
