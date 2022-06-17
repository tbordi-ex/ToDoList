using System;
using System.ComponentModel.DataAnnotations;

namespace ToDoList.BLL
{
    public class ToDoItem
    {
        [Key]
        public int Id { get; set; }
        public ToDoDescription Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public ItemState State { get; set; }
    }
}
