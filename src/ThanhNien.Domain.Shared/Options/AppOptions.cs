using System;
using System.Collections.Generic;
using System.Text;

namespace ThanhNien.Options
{
    public class AppOptions
    {
        public QuestionOptions Question { get; set; }
    }

    public class QuestionOptions
    {
        public int Count { get; set; }
    }
}
