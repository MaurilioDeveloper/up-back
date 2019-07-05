using System;

namespace Qualyteam.Repository
{
    public abstract class BaseEntity
    {
        public int CompanyId { get; set; }
        [Obsolete("Replaced by AuthorGuid", true)]
        public int? AuthorId { get; set; }
        public Guid? AuthorGuid { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
