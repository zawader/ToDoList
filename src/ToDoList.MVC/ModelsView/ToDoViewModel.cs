using System;
using System.ComponentModel.DataAnnotations;

namespace ToDoList.MVC.ModelsView
{
    public class ToDoViewModel
    {
        [Key]
        public int ToDoId { get; set; }

        [Required(ErrorMessage = "Preencha o titulo")]
        [Display(Name = "Título")]
        public string Title { get; set; }

        [Display(Name = "Descrição")]
        public string Description { get; set; }

        [Display(Name = "Concluído")]
        public bool IsCompleted { get; set; }

        [Display(Name = "Data de cadastro")]
        public DateTime CreateDate { get; set; }

        [Display(Name = "Data de atualização")]
        public DateTime? UpdateDate { get; set; }

        [Display(Name = "Data de remoção")]
        public DateTime? DeleteDate { get; set; }

        [Display(Name = "Data de conclusão")]
        public DateTime? CompletedDate { get; set; }
    }
}