using System;
using System.Collections.Generic;

namespace CertificatesBackendBackup.Entities;

public partial class Comment
{
    public int CommentId { get; set; }

    public int? CertificateId { get; set; }

    public int? UserId { get; set; }

    public string CommentText { get; set; } = null!;

    public DateTime? CommentDate { get; set; }

    public virtual Certificate? Certificate { get; set; }

    public virtual User? User { get; set; }
}
