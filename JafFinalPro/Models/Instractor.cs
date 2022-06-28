using JafFinalPro.SharedProp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JafFinalPro.Models
{
    public class Instractor : CommonProp
    {
        public int InstractorId { get; set; }
        public string InstractorName { get; set; }
        public string InstractorPostin { get; set; }
        public string InsImage { get; set; }
        public string FbURL { get; set; }

    }
}
