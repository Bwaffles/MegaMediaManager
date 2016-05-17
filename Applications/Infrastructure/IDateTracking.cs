using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    /// <summary> 
    /// Defines an interface for objects whose creation and modified 
    /// dates are kept track of automatically. 
    /// </summary> 
    public interface IDateTracking
    {
        /// <summary> 
        /// Gets or sets the date the object was created. 
        /// </summary> 
        DateTime DateCreated { get; set; }

        /// <summary> 
        /// Gets or sets the date the object was last modified. 
        /// </summary> 
        DateTime DateModified { get; set; }
    }
}
