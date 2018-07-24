using System.Data.Entity.ModelConfiguration;
using ToDoList.Domain.Entities;

namespace ToDoList.Infra.Data.EntityConfig
{
    public class ToDoConfiguration : EntityTypeConfiguration<ToDo>
    {
        public ToDoConfiguration()
        {
            ToTable("todolist");
            HasKey(t => t.ToDoId);
            Property(t => t.Title).IsRequired().HasMaxLength(150);
            Property(t => t.Description).HasMaxLength(1000);
            Property(t => t.CreateDate).HasColumnType("datetime2");
            Property(t => t.UpdateDate).HasColumnType("datetime2");
            Property(t => t.DeleteDate).HasColumnType("datetime2");
            Property(t => t.CompletedDate).HasColumnType("datetime2");
        }
    }
}
