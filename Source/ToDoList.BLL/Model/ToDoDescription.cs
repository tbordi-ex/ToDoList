using System.ComponentModel.DataAnnotations;

namespace ToDoList.BLL
{
    public class ToDoDescription
    {
        [Key]
        public int Id { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
    }
}
