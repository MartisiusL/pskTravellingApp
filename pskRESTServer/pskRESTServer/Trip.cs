
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace pskRESTServer
{

using System;
    using System.Collections.Generic;
    
public partial class Trip
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Trip()
    {

        this.UserTrips = new HashSet<UserTrip>();

    }


    public int Id { get; set; }

    public string TripName { get; set; }

    public System.DateTime TripStartDate { get; set; }

    public Nullable<int> ToOfficeId { get; set; }

    public Nullable<int> FromOfficeId { get; set; }

    public System.DateTime TripEndDate { get; set; }

    public Nullable<bool> HasHotel { get; set; }

    public Nullable<bool> RentCar { get; set; }

    public Nullable<bool> TravelTickets { get; set; }

    public byte[] RowVersion { get; set; }

    public Nullable<int> OrganizerId { get; set; }



    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<UserTrip> UserTrips { get; set; }

}

}
