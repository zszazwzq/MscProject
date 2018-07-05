
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
    public Button Login_Button;
    //Fief Map sence
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
    //Fief detail sence
    public Text FiefID;
    public Text ownerID;
    public Button back;
    public Button Siege;
    //Other value
    private TextTestClient tclient;
    private ProtoFief mf;
    public Text m_MyText;

    public void Start()
    {
        tclient = new TextTestClient();
        Login_Button.onClick.AddListener(LoginButton);

        //tclient.LogInAndConnect("helen", "potato", "localhost");
        //  
       // m_MyText.text = "This is my text";
        // midFief.text = mf.fiefID;

    }
    void Update()
    {
        //m_MyText.text = "This is my text";
        //Press the space key to change the Text message
        if (Input.GetKey(KeyCode.Space))
        {
            m_MyText.text = "Text has changed.";
        }
    }

    void LoginButton()
    {
       // m_MyText.text = "Text has changed.";
        //string username = inputUsername.text;
        //string password = inputPassword.text;
        
        tclient.LogInAndConnect("helen", "potato", "localhost");
        while (!tclient.IsConnectedAndLoggedIn())
        {
            Thread.Sleep(0);
        }
        if (tclient.IsConnectedAndLoggedIn())
        {
            SceneManager.LoadScene(1);
            mf = FiefDetails(tclient);
            string[] IDs = getFiefID();
            initFiefSence();
        }       
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
        E, W, S, N, Se, Sw, Ne, Nw
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
    public void initFiefSence()
    {
        mID.text = "wocaonima";
        Application.Quit();
        
        
        mB.onClick.AddListener(DetailButtonListener);
        nB.onClick.AddListener(MoveButtonListenerN);
        wB.onClick.AddListener(MoveButtonListenerW);
        sB.onClick.AddListener(MoveButtonListenerS);
        eB.onClick.AddListener(MoveButtonListenerE);
        nwB.onClick.AddListener(MoveButtonListenerNW);
        neB.onClick.AddListener(MoveButtonListenerNE);
        swB.onClick.AddListener(MoveButtonListenerSW);
        seB.onClick.AddListener(MoveButtonListenerSE);
        
        mID.text = mf.fiefID;
        string[] IDs = getFiefID();
       /* 
        nID.text = IDs[3];
        wID.text = IDs[1];
        sID.text = IDs[2];
        eID.text = IDs[0];
        nwID.text = IDs[7];
        neID.text = IDs[6];
        swID.text = IDs[5];
        seID.text = IDs[4];
        */
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
        SceneManager.LoadScene(2);
    }
    void backlistner()
    {
        SceneManager.LoadScene(1);
    }
}
