using ConsoleClient.MessageHandler;
using Grpc.Net.Client;
using GrpcPersonalDataClient;

// The port number must match the port of the gRPC server.
using var channel = GrpcChannel.ForAddress("https://localhost:7197");
var client = new SendPersonDataService.SendPersonDataServiceClient(channel);
var reply = await client.SendReplayDataAsync(
                  new PersonalDataRequest { 
                        Firstname = ConsoleDialogManager.HandleMessage("Enter Firstname: ", ConsoleColor.Green),
                        Surname = ConsoleDialogManager.HandleMessage("Enter Surname: ", ConsoleColor.Green),
                        Age = ConsoleDialogManager.HandleMessage("Enter Age: ", ConsoleColor.Green),
                        Adress = ConsoleDialogManager.HandleMessage("Enter Adress: ", ConsoleColor.Green)
                  });

Console.WriteLine("Personal Info: " + reply.Message);
Console.WriteLine("Press any key to exit...");
Console.ReadKey();