using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCBootstrapDemo.Models
{
    public class QuestionModel
    {
        public int Id {  get; set; }      
        public string Type {  get; set; }
        public string Question{  get; set; }
        public IList<string> Answers { get; set; }

    }
}
