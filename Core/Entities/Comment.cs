using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Comment : BaseEntity
    {
        public string CommentText { get; set; }
        public int ProductId { get; set; }
    }
}
