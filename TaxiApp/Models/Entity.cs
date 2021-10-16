using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiApp.Models
{
    public class Entity
    {
        public Guid Guid { get; set; } = Guid.NewGuid();
    }
}
