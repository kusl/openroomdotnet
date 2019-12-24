using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Contexts.Models
{
    [Table("RESERVATION")]
    public partial class Reservation
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("PATRON_ID")]
        public int PatronId { get; set; }
        [Column("RESOURCE_ID")]
        public int ResourceId { get; set; }
        [Column("START_TIME")]
        public DateTime StartTime { get; set; }
        [Column("END_TIME")]
        public DateTime EndTime { get; set; }
        [Required]
        [Column("ROW_VERSION")]
        public byte[] RowVersion { get; set; }

        [ForeignKey(nameof(PatronId))]
        [InverseProperty("Reservation")]
        public virtual Patron Patron { get; set; }
        [ForeignKey(nameof(ResourceId))]
        [InverseProperty("Reservation")]
        public virtual Resource Resource { get; set; }
    }
}
