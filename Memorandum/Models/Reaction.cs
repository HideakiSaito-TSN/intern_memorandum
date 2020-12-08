using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Memorandum.Models
{
  public class Reaction
  {
     [DisplayName("ID")]
    public int ID { get; set; }

    [DisplayName("送信者ID")]
    public int SenderID { get; set; }

    [DisplayName("種類")]
    public int Type { get; set; }

  }
}