namespace CertificatesBackendBackup.Entities;

public partial class User
{
    public int UserId { get; set; }

    public string UserName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual ICollection<CertificateParticipant> CertificateParticipants { get; set; } = new List<CertificateParticipant>();

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
}
