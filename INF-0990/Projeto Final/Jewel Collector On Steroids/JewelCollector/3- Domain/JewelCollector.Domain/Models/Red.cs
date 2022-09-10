using JewelCollector.Domain.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelCollector.Domain.Models
{
    public class Red : Jewel
    {
        public Red()
        {
            base.Value = 100;
        }
    }
}
