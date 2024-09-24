using System;
using System.Collections.Generic;

namespace CertificatesBackendBackup.Entities;

public partial class Supplier
{
    public int SupplierId { get; set; }

    public string SupplierName { get; set; } = null!;

    public string SupplierIndex { get; set; } = null!;

    public string? City { get; set; }

    public virtual ICollection<Certificate> Certificates { get; set; } = new List<Certificate>();
}
