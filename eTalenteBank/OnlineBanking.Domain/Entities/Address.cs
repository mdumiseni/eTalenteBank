using System.ComponentModel.DataAnnotations.Schema;
using OnlineBanking.Domain.Common;
using OnlineBanking.Domain.Entities.User;

namespace OnlineBanking.Domain.Entities;
[Table("Address", Schema = "Address")]
public class Address : AuditableEntity
{
    public int Id { get; set; }
    public string StreetAddress { get; set; }
    public string City { get; set; }
    public string PostalCode { get; set; }
    public string Province { get; set; }
    public string Country { get; set; }

    public ICollection<ApplicationUser> NavApplicationUsers { get; set; } = new HashSet<ApplicationUser>();
    
}