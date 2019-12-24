using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Contexts.Models
{
    [Table("RESOURCE")]
    public partial class Resource
    {
        public Resource()
        {
            Reservation = new HashSet<Reservation>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Required]
        [Column("NAME")]
        [StringLength(255)]
        public string Name { get; set; }
        [Required]
        [Column("ROW_VERSION")]
        public byte[] RowVersion { get; set; }

        [InverseProperty("Resource")]
        public virtual ICollection<Reservation> Reservation { get; set; }
    }
}
