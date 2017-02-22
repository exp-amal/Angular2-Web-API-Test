﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Experion.Marina.Dto
{
    public class QuestionsDto
    {
        public long id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Owner { get; set; }
        public DateTime Date { get; set; }
        public int count { get; set; }
    }
}
