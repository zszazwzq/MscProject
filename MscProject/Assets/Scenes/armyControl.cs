using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class armyControl : Controller
{

    // Use this for initialization
    public Text title;
    public Text report;
    
    public Button back;

    void Start()
    {
        back.onClick.AddListener(backListener);
        report.text += mf.fiefID+"\n";
        var counter = 0;
        foreach (var army in ma.fields)
        {
            counter++;
            //Console.WriteLine("Army " + counter);
            report.text += ("Army ID: " + army.armyID +"\n");
            report.text += ("Owner: " + army.ownerName + "\n");
            report.text += ("Size: " + army.armySize + "\n");
            report.text += ("Location : " + army.locationID + "\n");
            report.text += ("-----------------------------" + "\n");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    void backListener()
    {
        SceneManager.LoadScene(1);
    }
}