using Grpc.Core;
using GrpcPersonalDataServer;

namespace Services.PersonalDataService
{
    public class PersonDataService : SendPersonDataService.SendPersonDataServiceBase
    {
        private readonly ILogger<PersonDataService> _logger;
        public PersonDataService(ILogger<PersonDataService> logger)
        {
            _logger = logger;
        }

        public override Task<PersonalDataReply> SendReplayData(PersonalDataRequest request, ServerCallContext context)
        {
            return Task.FromResult(new PersonalDataReply
            {
                Message = $"Data sent from Server: " +
                $"\n{request.Firstname}  " +
                $"\n{request.Surname} " +
                $"\n{request.Age} " +
                $"\n{request.Adress} "
            });
        }
    }
}
