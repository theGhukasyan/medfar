namespace MedfarTest.Data.Entities;

public class Lookup
{
    public Guid Id { get; set; }
    
    public string LookupTypeName { get; set; }
    
    public string LookupTypeCode { get; set; }
    
    public string LookupCode { get; set; }
    
    public int? LookupPosition { get; set; }

    public Guid LookupID { get; set; }
    
    public string En { get; set; }
    
    public string Fr { get; set; }
    
    public Guid? EnValueID { get; set; }
    
    public Guid? FrValueID { get; set; }
    
    public Guid? EnLocalizedValueID { get; set; }
    
    public Guid? FrLocalizedValueID { get; set; }
    
    public Guid LookupTypeID { get; set; }
}