using HslCommunication.MQTT;
using System.Text;

MqttServer Server = new MqttServer();
Console.Write("ServiceStarted");

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
Server.OnClientApplicationMessageReceive += (MqttSession session, MqttClientApplicationMessage message) =>
{
    Console.WriteLine(session.EndPoint.Address.ToString() + "says" + Encoding.UTF8.GetString(message.Payload));
};
Server.ServerStart(54234);
while(true)
{
    Thread.Sleep(500);
    if(!Server.IsStarted)
    {
        try
        {
            Server.ServerClose();
            Server.ServerStart();
        }catch (Exception ex)
        { }
        Console.WriteLine("Serivice Restarted");
    }
}
