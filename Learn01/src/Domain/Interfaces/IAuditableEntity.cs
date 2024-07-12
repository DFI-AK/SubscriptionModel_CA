namespace Learn01.Domain.Interfaces;
internal interface IAuditableEntity
{
    DateTimeOffset Created { get; set; }
    string? CreatedBy { get; set; }
    DateTimeOffset LastModified { get; set; }
    string? LastModifiedBy { get; set; }
}
