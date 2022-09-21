using System.ComponentModel.DataAnnotations;

namespace WpfApp1.DB
{
    public class Account
    {
        [Key]
        public int AccountId { get; set; }
        public string Name { get; set; }
        public string PathImage { get; set; }

    }
}