using System;
using System.Collections.Generic;
using System.Text;

namespace Toolbox.Core.Forms.Models
{
    public class TechnicalServiceBulletinModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string URI { get; set; }
        public DateTime PublicationDate { get; set; }
        //public IEnumerable<string> VehicleIds { get; set; }
        //public DateTime DateIssued { get; set; }
        //public string Title { get; set; }
        //public string Details { get; set; }
        //public bool HasBeenRead { get; set; }
    }
}
