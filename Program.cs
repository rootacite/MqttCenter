using HslCommunication.MQTT;

MqttServer Server = new MqttServer();

Server.ClientVerification += (MqttSession mqttSession, string clientId, string userName, string passwrod) =>
  {
      Console.Write(mqttSession.EndPoint.Address.ToString());
      Console.Write("attempt to connect with username:");
      Console.Write(userName);
      Console.Write(" password: ");
      Console.WriteLine(passwrod);

      if (userName == "Acite" && passwrod == "761834") 
      {
          Console.WriteLine("ClientVerification Success");
          return 0;
      }

      Console.WriteLine("ClientVerification Failed");
      return 5;
  };

Server.ServerStart(54234);
while(true)
{
    _ = Console.ReadLine();
}
