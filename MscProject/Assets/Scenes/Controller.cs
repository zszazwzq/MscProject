
using UnityEngine;
using UnityEngine.UI;
using Lidgren.Network;
using System.Net;
using UnityEngine.SceneManagement;
using ProtoMessageClient;
using System.Threading.Tasks;
using System.Threading;
//using Assets.Scenes;
public class Controller : MonoBehaviour
{
    //login sence
    public InputField inputUsername;
    public InputField inputPassword;
    public Button loginButton;
    public Text buttonText;
    //Other value
    protected static TextTestClient tclient;
    protected static ProtoFief mf;
    protected static ProtoGenericArray<ProtoArmyOverview> ma;
    protected static ProtoPlayerCharacter c;
    protected static ProtoMessage hr;
    protected static ProtoMessage sd;
    public Text m_MyText;

    public void Start()
    {
        tclient = new TextTestClient();
        loginButton.onClick.AddListener(LoginButton);
    }

    protected void LoginButton()
    {
        m_MyText.text += "1";
        string username = inputUsername.text;
        string password = inputPassword.text;
        
        tclient.LogInAndConnect("helen", "potato", "localhost");

        while (!tclient.IsConnectedAndLoggedIn())
        {
            Thread.Sleep(0);
            
        }

        buttonText.text = "loading";
        if (tclient.IsConnectedAndLoggedIn())
        {
            mf = FiefDetails(tclient);

            SceneManager.LoadScene(1);
           // FiefControl f = new FiefControl(tclient);
        }       
    }

    protected ProtoFief FiefDetails(TextTestClient client)
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
    protected ProtoMessage GetActionReply(Actions action, TextTestClient client)
    {
        ProtoMessage responseTask = client.GetReply();

        while (responseTask.ActionType != action)
        {
            responseTask = client.GetReply();

        }
        client.ClearMessageQueues();
        return responseTask;
    }
    protected ProtoGenericArray<ProtoArmyOverview> ArmyStatus(TextTestClient client)
    {
        ProtoArmy proto = new ProtoArmy();
        proto.ownerID = "Char_158";
        proto.ActionType = Actions.ListArmies;
        client.net.Send(proto);
        var reply = GetActionReply(Actions.ListArmies, client);
        var armies = (ProtoGenericArray<ProtoArmyOverview>)reply;
        return armies;
    }
    protected ProtoPlayerCharacter Profile(TextTestClient client)
    {
        ProtoPlayerCharacter protoMessage = new ProtoPlayerCharacter();
        protoMessage.Message = "Char_158";
        protoMessage.ActionType = Actions.ViewChar;
        client.net.Send(protoMessage);
        var reply = GetActionReply(Actions.ViewChar, client);
        return (ProtoPlayerCharacter)reply;
    }
    protected ProtoMessage HireTroops(int amount, TextTestClient client)
    {
        ProtoPlayerCharacter protoMessage = new ProtoPlayerCharacter();
        protoMessage.Message = "Char_158";
        protoMessage.ActionType = Actions.ViewChar;
        client.net.Send(protoMessage);
        var armyReply = GetActionReply(Actions.ViewChar, client);
        var armyResult = (ProtoPlayerCharacter)armyReply;
        ProtoRecruit protoRecruit = new ProtoRecruit();
        protoRecruit.ActionType = Actions.RecruitTroops;
        if (amount > 0)
        {
            protoRecruit.amount = (uint)amount;
        }
        protoRecruit.armyID = armyResult.armyID;
        protoRecruit.isConfirm = true;
        client.net.Send(protoRecruit);
        var reply = GetActionReply(Actions.RecruitTroops, client);
        return reply;
    }
    protected ProtoMessage SiegeCurrentFief(TextTestClient client)
    {
        ProtoPlayerCharacter protoMessage = new ProtoPlayerCharacter();
        protoMessage.Message = "Char_158";
        protoMessage.ActionType = Actions.ViewChar;
        client.net.Send(protoMessage);
        var locReply = GetActionReply(Actions.ViewChar, client);
        var locResult = (ProtoPlayerCharacter)locReply;
        ProtoMessage protoSiegeStart = new ProtoMessage();
        protoSiegeStart.ActionType = Actions.BesiegeFief;
        protoSiegeStart.Message = locResult.armyID;
        client.net.Send(protoSiegeStart);
        var reply = GetActionReply(Actions.BesiegeFief, client);
        if (reply.GetType() == typeof(ProtoSiegeDisplay))
        {
            return reply as ProtoSiegeDisplay;
        }
        else
        {
            return reply;
        }
    }


}
