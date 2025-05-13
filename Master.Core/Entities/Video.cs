using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Master.Core.Entities
{
    public class video
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public string YouTubeUrl { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

    }
}
