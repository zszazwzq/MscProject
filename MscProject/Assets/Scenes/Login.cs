
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
    //login sence
    public InputField mainInputField1;
    public InputField mainInputField2;
    public Button Login_Button;
    //Fief sence
    //IDs
    public Text mID;
    public Text nID;
    public Text wID;
    public Text sID;
    public Text eID;
    public Text nwID;
    public Text neID;
    public Text swID;
    public Text seID;
    //Buttons
    public Button mB;
    public Button nB;
    public Button wB;
    public Button sB;
    public Button eB;
    public Button nwB;
    public Button neB;
    public Button swB;
    public Button seB;
    //Other value
    private TextTestClient tclient;


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
    public enum MoveDirections
    {
        E, W, S, N, Se, Sw, Ne, Nw, SyntaxError
    }
    public ProtoFief Move(MoveDirections directions)
    {
        ProtoTravelTo protoTravel = new ProtoTravelTo();
        protoTravel.travelVia = new[] { directions.ToString() };
        protoTravel.characterID = "Char_158";
        tclient.net.Send(protoTravel);
        var reply = GetActionReply(Actions.TravelTo, tclient);
        var travel = (ProtoFief)reply;
        return travel;
    }
    public string[] getFiefID()
    {
        string[] IDs = new string[8];
        IDs[0] = Move(MoveDirections.E).fiefID;
        Move(MoveDirections.W);
        IDs[1] = Move(MoveDirections.W).fiefID;
        Move(MoveDirections.E);
        IDs[2] = Move(MoveDirections.S).fiefID;
        Move(MoveDirections.N);
        IDs[3] = Move(MoveDirections.N).fiefID;
        Move(MoveDirections.S);
        IDs[4] = Move(MoveDirections.Se).fiefID;
        Move(MoveDirections.Nw);
        IDs[5] = Move(MoveDirections.Sw).fiefID;
        Move(MoveDirections.Ne);
        IDs[6] = Move(MoveDirections.Ne).fiefID;
        Move(MoveDirections.Sw);
        IDs[7] = Move(MoveDirections.Nw).fiefID;
        Move(MoveDirections.Se);
        return IDs;
    }
    public void iniFiefSence()
    {
        string[] IDs = getFiefID();
       // mID.text = IDs[].text;
        nID.text = IDs[3];
        wID.text = IDs[1];
        sID.text = IDs[2];
        eID.text = IDs[0];
        nwID.text = IDs[7];
        neID.text = IDs[6];
        swID.text = IDs[5];
        seID.text = IDs[4];
        //mB.onClick.AddListener(Move(MoveDirections.));
        nB.onClick.AddListener(MoveButtonListenerN);
        wB.onClick.AddListener(MoveButtonListenerW);
        sB.onClick.AddListener(MoveButtonListenerS);
        eB.onClick.AddListener(MoveButtonListenerE);
        nwB.onClick.AddListener(MoveButtonListenerNW);
        neB.onClick.AddListener(MoveButtonListenerNE);
        swB.onClick.AddListener(MoveButtonListenerSW);
        seB.onClick.AddListener(MoveButtonListenerSE);
    }
    
    void MoveTo(MoveDirections directions)
    {
        Move(directions);
        getFiefID();
    }
    void MoveButtonListenerE()
    {
        MoveTo(MoveDirections.E);
    }
    void MoveButtonListenerW()
    {
        MoveTo(MoveDirections.W);
    }
    void MoveButtonListenerS()
    {
        MoveTo(MoveDirections.S);
    }
    void MoveButtonListenerN()
    {
        MoveTo(MoveDirections.N);
    }
    void MoveButtonListenerSW()
    {
        MoveTo(MoveDirections.Sw);
    }
    void MoveButtonListenerNE()
    {
        MoveTo(MoveDirections.Ne);
    }
    void MoveButtonListenerNW()
    {
        MoveTo(MoveDirections.Nw);
    }
    void MoveButtonListenerSE()
    {
        MoveTo(MoveDirections.Se);
    }
    void DetailButtonListener()
    {

    }

}
