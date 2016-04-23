using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaMediaManager.Model
{
    public interface IHasOwner
    {
        User Owner { get; set; }

    }
}
