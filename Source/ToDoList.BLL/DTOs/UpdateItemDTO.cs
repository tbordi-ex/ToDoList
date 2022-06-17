using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoList.BLL
{
    public class UpdateItemDTO
    {
        public string NewShortDescription { get; set; }
        public string NewLongDescription { get; set; }
        public ItemState NewState { get; set; }
    }
}
