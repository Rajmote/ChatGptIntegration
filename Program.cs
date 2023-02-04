// See https://aka.ms/new-console-template for more information
using ChatGptIntegration;

Console.WriteLine ( "Chat GPT Code completion process started" );

var integration = new Integration();
integration.CallAPIAsync ();
Console.ReadLine();
