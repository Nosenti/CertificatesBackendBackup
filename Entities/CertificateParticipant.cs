using System;
using System.Collections.Generic;

namespace CertificatesBackendBackup.Entities;

public partial class CertificateParticipant
{
    public int ParticipantId { get; set; }

    public int? CertificateId { get; set; }

    public int? UserId { get; set; }

    public DateOnly AssignedDate { get; set; }

    public virtual Certificate? Certificate { get; set; }

    public virtual User? User { get; set; }
}
