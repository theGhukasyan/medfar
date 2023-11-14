using System;

namespace MedfarTest.Domain.Lookups.Responses.Commands;

public class UpdateLookupResponse
{
    public Guid Id { get; set; }
    
    public string LookupTypeName { get; set; }
    
    public string LookupTypeCode { get; set; }
    
    public string LookupCode { get; set; }
    
    public int? LookupPosition { get; set; }

    public Guid LookupID { get; set; }
    
    public string en { get; set; }
    
    public string fr { get; set; }
    
    public Guid? enValueID { get; set; }
    
    public Guid? frValueID { get; set; }
    
    public Guid? enLocalizedValueID { get; set; }
    
    public Guid? frLocalizedValueID { get; set; }
    
    public Guid LookupTypeID { get; set; }
}