//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcStockApplication.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order
    {
        public int OrderID { get; set; }
        public Nullable<int> Product { get; set; }
        public Nullable<int> Customer { get; set; }
        public Nullable<byte> Piece { get; set; }
        public Nullable<decimal> UnitPrice { get; set; }
    
        public virtual Customer Customer1 { get; set; }
        public virtual Product Product1 { get; set; }
    }
}
