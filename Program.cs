using HslCommunication.MQTT;

MqttServer Server = new MqttServer();

Server.ClientVerification += (MqttSession mqttSession, string clientId, string userName, string passwrod) =>
  {
      if (userName == "Acite" && passwrod == "761834") return 0;

      return 5;
  };

Server.ServerStart(54234);
