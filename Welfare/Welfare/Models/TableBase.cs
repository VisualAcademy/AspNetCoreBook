using System;
using System.ComponentModel.DataAnnotations;

namespace Welfare.Models
{
    public abstract class TableBase
    {
        public int Id { get; set; }

        public bool Active { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        [StringLength(100)]
        public string CreatedBy { get; set; }
    }
}
