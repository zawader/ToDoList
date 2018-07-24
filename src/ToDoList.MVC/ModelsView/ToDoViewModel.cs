using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ToDoList.MVC.ModelsView
{
    public class ToDoViewModel
    {
        [Key]
        public int ToDoId { get; set; }

        [Required(ErrorMessage = "Preencha o titulo")]
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public DateTime? CompletedDate { get; set; }
    }
}