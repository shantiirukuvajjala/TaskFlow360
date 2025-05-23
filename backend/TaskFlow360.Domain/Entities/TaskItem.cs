﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskFlow360.Domain.Entities
{
    public class TaskItem
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = default!;
        public string? Description { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsCompleted { get; set; }
    }
}
