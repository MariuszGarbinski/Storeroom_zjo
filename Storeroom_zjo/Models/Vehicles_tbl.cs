//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Storeroom_zjo.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Vehicles_tbl
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Vehicles_tbl()
        {
            this.Customers_tbl = new HashSet<Customers_tbl>();
        }
    
        public int IdVehicle { get; set; }
        public string VehicleBrand { get; set; }
        public string Model { get; set; }
        public string VehicleType { get; set; }
        public string VINnumber { get; set; }
        public string REGnumber { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Customers_tbl> Customers_tbl { get; set; }
    }
}
