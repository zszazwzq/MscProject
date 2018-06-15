using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Lidgren.Network;
using System.Threading;
using System;
using System.IO;
using System.Net;

public class Login : MonoBehaviour
{
    public InputField mainInputField1;
    public InputField mainInputField2;
    private Scene Login_Scene;
    public Button Login_Button;
    private NetClient client;
    private IPAddress ip = NetUtility.Resolve("localhost");
    private int port = 8000;
    private NetConnection connection;
    private NetEncryption alg = null;

    // public LoginControl LC;
    // public Assets.sence.JENetwork Net;

    // Use this for initialization
    public void Start()
    {
        //Login_Scene = new Scene();

        Login_Button.onClick.AddListener(LoginButton);
        NetPeerConfiguration config = new NetPeerConfiguration("test");
        config.SetMessageTypeEnabled(NetIncomingMessageType.ConnectionLatencyUpdated, true);
        config.ConnectionTimeout = 3000f;
        client = new NetClient(config);

    }
    void LoginButton()
    {
        string username = mainInputField1.text;
        string password = mainInputField2.text;
        //Application.Quit();
        Connect("helen", "potato");

        SceneManager.LoadScene(1);

    }
    // Update is called once per frame
    public void Update()
    {

    }
    public void Connect(string username, string password)
    {

        client.Start();
        string host = ip.ToString();
        // remember to encrypt the bloody thing in the final
        // Application.Quit();
        if (username != null)
        {
            NetOutgoingMessage msg = client.CreateMessage(username);

            msg.Write("TestString");
            NetConnection c = client.Connect(host, port, msg);
        }
        else
        {
            connection = client.Connect(host, port);
        }
        // Start listening for responses
        Thread t_reader = new Thread(new ThreadStart(this.read));
        t_reader.Start();

    }
    public void Send(ProtoMessage message, bool encrypt = true)
    {
        NetOutgoingMessage msg = client.CreateMessage();
        MemoryStream ms = new MemoryStream();
        try
        {
            //Serializer.SerializeWithLengthPrefix<ProtoMessage>(ms, message, ProtoBuf.PrefixStyle.Fixed32);
            Console.Write("Client: Sending");
            msg.Write(ms.GetBuffer());
            if (alg != null && encrypt)
            {
                Console.Write(" encrypted");
                msg.Encrypt(alg);
            }
            var result = client.SendMessage(msg, NetDeliveryMethod.ReliableOrdered);
            Console.WriteLine(" message of type " + message.GetType() + " with Action: " + message.ActionType + " with result: " + result.ToString());
            client.FlushSendQueue();

        }
        catch (Exception e)
        {
            Console.WriteLine("CLIENT: Failed to serialise message!");
        }

    }

    public void read()
    {

    }

}
