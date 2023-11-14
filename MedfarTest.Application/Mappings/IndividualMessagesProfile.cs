using AutoMapper;
using MedfarTest.Data.Entities;
using MedfarTest.Domain.IndividualMessages.Requests.Commands;
using MedfarTest.Domain.IndividualMessages.Requests.Queries;
using MedfarTest.Domain.IndividualMessages.Responses.Commands;
using MedfarTest.Domain.IndividualMessages.Responses.Queries;

namespace MedfarTest.Application.Mappings;

public class IndividualMessagesProfile : Profile
{
    public IndividualMessagesProfile()
    {
        CreateMap<IndividualMessage, GetIndividualMessageQuery>();
        CreateMap<CreateIndividualMessageRequest, IndividualMessage>();
        CreateMap<UpdateIndividualMessageRequest, IndividualMessage>();
        CreateMap<IndividualMessage, CreateIndividualMessageResponse>();
        CreateMap<IndividualMessage, UpdateIndividualMessageResponse>();
        CreateMap<IndividualMessage, GetIndividualMessageResponse>();
    }
}