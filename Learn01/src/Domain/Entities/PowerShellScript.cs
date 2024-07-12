namespace Learn01.Domain.Entities;
public class PowerShellScript : BaseEntity<string>
{
    public string? ScriptName { get; set; }
    public string? ScriptURL { get; set; }
}
