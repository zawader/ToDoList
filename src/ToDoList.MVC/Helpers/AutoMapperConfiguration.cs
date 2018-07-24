using AutoMapper;
using ToDoList.Domain.Entities;
using ToDoList.MVC.ModelsView;

namespace ToDoList.MVC.Helpers
{
    public class AutoMapperConfiguration
    {
        public static void AutoMapperStart()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<ToDo, ToDoViewModel>();
            });
        }
    }
}