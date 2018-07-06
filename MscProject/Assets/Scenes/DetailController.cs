using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DetailController : Controller
{

    // Use this for initialization
    public Text FiefId;
    public Text Owner;
    public Text OwnerId;
    public Text IndustryLevel;
    public Button back;

    void Start () {
        back.onClick.AddListener(backListener);
        FiefId.text += mf.fiefID;
        Owner.text += mf.owner;
        OwnerId.text += mf.ownerID;
        IndustryLevel.text += mf.industry;

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void backListener()
    {
        SceneManager.LoadScene(1);
    }
}
