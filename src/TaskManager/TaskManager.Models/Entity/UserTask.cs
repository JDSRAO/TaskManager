using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Models.Entity
{
    public class UserTask : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime TargetDate { get; set; }
        public DateTime? EndedAt { get; set; }
        public TimeSpan TotalTimeTaken
        {
            get { return TimeSpan.FromTicks(TotalTimeTakenInTicks); }
            set { TotalTimeTakenInTicks = value.Ticks; }
        }
        public long TotalTimeTakenInTicks { get; set; }
        public bool IsSuspended { get; set; }
        public bool IsEnded { get; set; }
    }
}
