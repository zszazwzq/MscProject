
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
    public Text m_MyText;

    public void Start()
    {
        tclient = new TextTestClient();
        loginButton.onClick.AddListener(LoginButton);
    }

    void LoginButton()
    {
      
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
            SceneManager.LoadScene(1);
           // FiefControl f = new FiefControl(tclient);
        }       
    }



}
