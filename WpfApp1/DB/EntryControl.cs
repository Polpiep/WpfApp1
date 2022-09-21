using System;
using System.ComponentModel.DataAnnotations;
using System.Windows.Automation.Peers;

namespace WpfApp1.DB
{
    public class EntryControl
    {
        [Key]
        public int EntryControlId { get; set; }
        public DateTime DateTimeEntryControl { get; set; }
        public int AccountId{ get; set; }
        public Account Account { get; set; }
    }
}