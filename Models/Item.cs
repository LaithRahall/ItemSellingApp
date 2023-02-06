using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace ItemSellingApp.Models
{
    public class Item
    {
        [DisplayName("Number")]
        public string Id { get; set; }   
        public string Name { get; set; }        
        public int Price { get; set; }   
        
        [MinLength(5,ErrorMessage ="between 5-10")]
        [MaxLength(5)]
        public string DESC { get; set; }    

    }
}
