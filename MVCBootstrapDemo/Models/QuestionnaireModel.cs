using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCBootstrapDemo.Models
{
    public class QuestionnaireModel
    {
        public string Title { get; set; }
        public string Email {  get; set; }
        public IList<QuestionModel> Questions {  get; set; }
    }
}
