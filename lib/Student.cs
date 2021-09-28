using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib
{
  public class Student
  {
    public int Id { get; set; }  // primary key
    [Required]
    public string Name { get; set; }
    [MaxLength(35)]
    [Column(TypeName = "varchar(35)")]
    public string Email { get; set; }
    public List<Book> Books { get; set; }
    public List<Klass> Klasses { get; set; }
  }
}
