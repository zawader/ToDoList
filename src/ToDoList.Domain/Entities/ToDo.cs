using System;

namespace ToDoList.Domain.Entities
{
    public class ToDo
    {
        public int ToDoId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public DateTime? CompletedDate { get; set; }

        protected ToDo()
        {
        }
    }
}
