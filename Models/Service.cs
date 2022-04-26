using System;
using System.Collections.Generic;

namespace LivingAssistance2.Models
{
    public partial class Service
    {
        public string ServicesId { get; set; } = null!;
        public string ServicesName { get; set; } = null!;
        public int Charges { get; set; }
    }
}
