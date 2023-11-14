using System;
using MedfarTest.Domain.IndividualMessages.Responses.Commands;
using MediatR;
using Newtonsoft.Json;

namespace MedfarTest.Domain.IndividualMessages.Requests.Commands;

public class CreateIndividualMessageRequest : IRequest<CreateIndividualMessageResponse>
{
    public int Version { get; set; }
    
    [JsonIgnore]
    public DateTime CreationDate { get; set; }
    
    public Guid CreatedBy { get; set; }
    
    public DateTime? LastUpdateDate { get; set; }
    
    public Guid? LastUpdatedBy { get; set; }
    
    [JsonIgnore]
    public DateTime? DeletionDate { get; set; }
    
    [JsonIgnore]
    public Guid? DeletedBy { get; set; }
    
    public DateTime? ArchivalDate { get; set; }
    
    public Guid? ArchivedBy { get; set; }
    
    public string Subject{ get; set; }
    
    public string Body { get; set; }
    
    public DateTime SendDate { get; set; }
    
    public bool IsTask{ get; set; }
    
    public DateTime? StartDate{ get; set; }
    
    public DateTime? DueDate { get; set; }
    
    public bool IsDraft { get; set; }
    
    public bool? IsGroupTask { get; set; }
    
    public Guid? DocumentPatientId { get; set; }
    
    public string FileName{ get; set; }
    
    public Guid? TypeTaskLookupId { get; set; }
    
    public Guid? PriorityLookupId { get; set; }

    public Guid FromContactId { get; set; }

    public CreateIndividualMessageRequest()
    {
        CreationDate = DateTime.UtcNow;
    }
    
    public CreateIndividualMessageRequest(
        int version,
        Guid createdBy, 
        DateTime? lastUpdateDate, 
        Guid? lastUpdatedBy, 
        DateTime? deletionDate, 
        Guid? deletedBy, 
        DateTime? archivalDate, 
        Guid? archivedBy, 
        string subject, 
        string body, 
        DateTime sendDate, 
        bool isTask, 
        DateTime? startDate, 
        DateTime? dueDate, 
        bool isDraft, 
        bool? isGroupTask, 
        Guid? documentPatientId, 
        string fileName, 
        Guid? typeTaskLookupId, 
        Guid? priorityLookupId, 
        Guid fromContactId)
    {
        Version = version;
        CreationDate = DateTime.UtcNow;
        CreatedBy = createdBy;
        LastUpdateDate = lastUpdateDate;
        LastUpdatedBy = lastUpdatedBy;
        DeletionDate = deletionDate;
        DeletedBy = deletedBy;
        ArchivalDate = archivalDate;
        ArchivedBy = archivedBy;
        Subject = subject;
        Body = body;
        SendDate = sendDate;
        IsTask = isTask;
        StartDate = startDate;
        DueDate = dueDate;
        IsDraft = isDraft;
        IsGroupTask = isGroupTask;
        DocumentPatientId = documentPatientId;
        FileName = fileName;
        TypeTaskLookupId = typeTaskLookupId;
        PriorityLookupId = priorityLookupId;
        FromContactId = fromContactId;
    }
}