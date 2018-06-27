using Assets.Scenes;
using ProtoMessageClient;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class FiefControl : MonoBehaviour {
    public Text text;
    public Image midImage;
    private static TextTestClient _testClient;
    private GameOptions go;
	// Use this for initialization
	void Start () {
        go = new GameOptions();
        go.Connect("helen","potato");
        text.text = go.FiefDetails(_testClient).fiefID;
        //midImage.


    }
	
	// Update is called once per frame
	void Update () {

    }

}
