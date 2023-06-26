// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using KafkaConsumer;

ConsumeMessage consumeMessage = new ConsumeMessage();
consumeMessage.ReadMessage().Wait();