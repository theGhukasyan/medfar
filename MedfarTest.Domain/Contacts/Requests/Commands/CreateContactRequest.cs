using System;
using MedfarTest.Domain.Contacts.Responses.Commands;
using MediatR;

namespace MedfarTest.Domain.Contacts.Requests.Commands;

public class CreateContactRequest : IRequest<CreateContactResponse>
{
    public string SearchableSummaryTitle { get; set; }
    
    public string SearchableSummaryDetails { get; set; }
    
    public string SearchableSummaryExtendedDetails { get; set; }
    
    public string SearchableSummarySearch1 { get; set; }
    
    public string SearchableSummarySearch2 { get; set; }
    
    public string SearchableSummarySearch3 { get; set; }
    
    public string SearchableSummarySearch4 { get; set; }
    
    public string SearchableSummarySearch5 { get; set; }
    
    public string SearchableSummarySearch6 { get; set; }
    
    public string SearchableSummarySearch7 { get; set; }
    
    public string SearchableSummarySearchSoundex1 { get; set; }
    
    public string SearchableSummarySearchSoundex2 { get; set; }
    
    public string SearchableSummarySearch8 { get; set; }
    
    public string SearchableSummarySearch9 { get; set; }
    
    public string SearchableSummarySearch10 { get; set; }
    
    public string SearchableSummarySearch11 { get; set; }
    
    public string SearchableSummarySearch12 { get; set; }
    
    public string SearchableSummarySearch13 { get; set; }
    
    public string Considerations { get; set; }
    
    public string ShortName { get; set; }
    
    public bool IsPatient { get; set; }
    
    public Guid? LoginId { get; set; }
    
    public Guid? ProfilePictureId { get; set; }
}