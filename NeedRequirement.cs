using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWHibernateTestApp.Models
{
    class NeedRequirement
    {
        public virtual long Id { get; set; }
        public virtual string Need_Date { get; set; }
        public virtual string Need_LOB { get; set; }
        public virtual Double ts_0700 { get; set; }
        public virtual Double ts_0730 { get; set; }
    }
}
