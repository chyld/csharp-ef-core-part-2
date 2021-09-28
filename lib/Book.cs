using System;
using System.ComponentModel.DataAnnotations;

namespace lib
{
  public class Book
  {
    [Key]
    public int BId { get; set; } // primary key
    public string Title { get; set; }
    public string ISBN { get; set; }
    public string SerialNumber { get; set; }
    public Student Owner { get; set; }
  }
}
