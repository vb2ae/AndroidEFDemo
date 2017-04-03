using System;
using System.ComponentModel.DataAnnotations;

namespace AndroidEF.Standard
{
    public class ToDoItem
    {
        [Key]
        public int Id { get; set; }

        public string Description { get; set; }

        public bool Completed { get; set; }
    }
}
