namespace PI.Domain.Core.Models
{
    internal interface IAuditableEntity
    {
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset? LastModifiedOn { get; set; }
    }
}
