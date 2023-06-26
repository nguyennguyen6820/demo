//// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using KafkaProducer;

ProduceMessage produceMessage = new ProduceMessage();
produceMessage.CreateMessage().Wait();