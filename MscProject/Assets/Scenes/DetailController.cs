using System;
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
    public Button map;
    public Button army;
    public Button hire;
    public Button siege;
    public Button profile;
    public InputField inputNum;

    void Start () {
        map.onClick.AddListener(mapListener);
        army.onClick.AddListener(armyListener);
        hire.onClick.AddListener(hireListener);
        siege.onClick.AddListener(siegeListener);
        profile.onClick.AddListener(profileListener);
        FiefId.text += mf.fiefID;
        Owner.text += mf.owner;
        OwnerId.text += mf.ownerID;
        IndustryLevel.text += mf.industry;

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void mapListener()
    {
        SceneManager.LoadScene(2);
    }
    void armyListener()
    {
        ma = ArmyStatus(tclient);

        SceneManager.LoadScene(3);

    }
    void hireListener()
    {
        string num = inputNum.text;
        hr = HireTroops(int.Parse(num), tclient);
        SceneManager.LoadScene(5);
    }
    void siegeListener()
    {
        sd = SiegeCurrentFief(tclient);
        SceneManager.LoadScene(6);
    }
    void profileListener()
    {
        c = Profile(tclient);
        SceneManager.LoadScene(4);
    }
}
