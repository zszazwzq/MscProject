using ProtoMessageClient;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class siegeControl : Controller
{

    // Use this for initialization
    public Text title;
    public Text report;

    public Button back;

    void Start()
    {
        back.onClick.AddListener(backListener);

        if (sd.GetType() == typeof(ProtoSiegeDisplay))
        {
            var siegeDisplay = (ProtoSiegeDisplay)sd;
            DisplaySiege(siegeDisplay);

        }
        else
        {
            switch (sd.ResponseType)
            {
                case DisplayMessages.PillageSiegeAlready:
                    report.text += ("Already sieged this turn!");
                    break;
                case DisplayMessages.PillageUnderSiege:
                    report.text += ("Already under siege!");
                    break;
                case DisplayMessages.ArmyNoLeader:
                    report.text += ("Army has no leader!");
                    break;
                default:
                    report.text += (sd.ResponseType);
                    break;
            }
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
    public void DisplaySiege(ProtoSiegeDisplay siegeDisplayProtoBuf)
    {
        report.text += ("-----------------------------\n");
        report.text += ("Siege Report\n");
        report.text += ("-----------------------------\n");
        report.text += ("Besieged Fief: " + siegeDisplayProtoBuf.besiegedFief + "\n");
        report.text += ("Besieged Army: " + siegeDisplayProtoBuf.besiegerArmy + "\n");
        report.text += ("Siege Successful: " + siegeDisplayProtoBuf.besiegerWon + "\n");
        report.text += ("Siege Length: " + siegeDisplayProtoBuf.days + " days\n");
        report.text += ("Loot Lost: " + siegeDisplayProtoBuf.lootLost + "\n");
        report.text += ("-----------------------------\n");
    }
}