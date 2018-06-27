
using UnityEngine;
using UnityEngine.UI;
using Lidgren.Network;
using System.Net;
using UnityEngine.SceneManagement;
using ProtoMessageClient;
using System.Threading.Tasks;
//using Assets.Scenes;
public class Login : MonoBehaviour
{
    public InputField mainInputField1;
    public InputField mainInputField2;
    public Button Login_Button;
    public Text midFief;
   
    private TextTestClient tclient;
   // private IPAddress ip = NetUtility.Resolve("localhost");

    public void Start()
    {
        Login_Button.onClick.AddListener(LoginButton);     
        tclient = new TextTestClient();
        tclient.LogInAndConnect("helen", "potato", "localhost");
      //  SceneManager.LoadScene(1);
      //  ProtoFief mf = FiefDetails(tclient);
       // midFief.text = mf.fiefID;
        Debug.Log("Start");
    }
    void LoginButton()
    {
        string username = mainInputField1.text;
        string password = mainInputField2.text;
        //tclient.LogInAndConnect("helen", "potato", "localhost");

        //
    }
    // Update is called once per frame
    public void Update()
    {

    }

    public ProtoFief FiefDetails(TextTestClient client)
    {
        ProtoPlayerCharacter protoMessage = new ProtoPlayerCharacter();
        protoMessage.Message = "Char_158";
        protoMessage.ActionType = Actions.ViewChar;
        client.net.Send(protoMessage);
        var locReply = GetActionReply(Actions.ViewChar, client);
        var locResult = (ProtoPlayerCharacter)locReply;
        ProtoFief protoFief = new ProtoFief();
        protoFief.Message = locResult.location;
        protoFief.ActionType = Actions.ViewFief;
        client.net.Send(protoFief);
        var reply = GetActionReply(Actions.ViewFief, client);
        return (ProtoFief)reply;
    }
    public ProtoMessage GetActionReply(Actions action, TextTestClient client)
    {
        ProtoMessage responseTask = client.GetReply();
        
        while (responseTask.ActionType != action)
        {
            responseTask = client.GetReply();
            
        }
        client.ClearMessageQueues();
        return responseTask;
    }

}
