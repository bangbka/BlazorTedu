using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ToDoListApi.Enums;

namespace ToDoListApi.Entities
{
    public class Task
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid? AssignId { get; set; }
        public Status Status { get; set; }
        public Priority Priority { get; set; }

    }
}
