using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Models.DTO
{
    public class BaseDto
    {
        public Guid ID { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
