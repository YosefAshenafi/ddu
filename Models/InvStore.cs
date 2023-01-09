using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DDU.Models;

[Table("InvStore")]
public partial class InvStore
{
    [Key]
    public int StoreID { get; set; }

    [StringLength(256)]
    public string StoreCode { get; set; } = null!;

    [StringLength(256)]
    public string? StoreLocation { get; set; }

    public int DivID { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? SessionID { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? SessionIP { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? SessionMAC { get; set; }

    public int? IsDeleted { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? LastUpdated { get; set; }
}
