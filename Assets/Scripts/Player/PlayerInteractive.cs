using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractive : MonoBehaviour
{
    private Reactions m_reactions;

    public List<GameObject> Interactables;

    private int AppToItem(string thingname)
    {
        switch (thingname)
        {
            case "BeachClick":
                return 0;
            case "CommercialAlleyClick":
                return 1;
            case "TraderJanesDoor":
                return 2;
            case "HomeOfBluesDoor":
                return 3;
            case "ResidentialAlleyClick":
                return 4;
            case "BeachAlleyClick":
                return 5;
            case "TacoVendorClick":
                return 6;
            case "ChowsChowDoor":
                return 7;
            case "LatinMusicDoor":
                return 8;
            case "StadiumClick":
                return 9;
            case "WheelClick":
                return 11;
        }
        return 0;
    }

    public string GetInteractableQuip(GameObject worldObject, string clickedApp)
    {
        foreach (var thing in Interactables)
        {
            if (thing == worldObject)
            {
                switch (clickedApp)
                {
                    case "CameraClickArea":
                        return m_reactions.GetQuip(Reactions.Verb.Photograph, (Reactions.Item)AppToItem(thing.name));
                    case "RecorderClickArea":
                        return m_reactions.GetQuip(Reactions.Verb.Record, (Reactions.Item)AppToItem(thing.name));
                    case "LightClickedArea":
                        return m_reactions.GetQuip(Reactions.Verb.Photograph, (Reactions.Item)AppToItem(thing.name));
                    case "PayClickedArea":
                        return m_reactions.GetQuip(Reactions.Verb.Photograph, (Reactions.Item)AppToItem(thing.name));
                }
            }
        }
        return null;
    }

    // Use this for initialization
    void Start()
    {
        Interactables.Add(GameObject.Find("TacoVendorClick"));
        Interactables.Add(GameObject.Find("ResidentialAlleyClick"));

        Interactables.Add(GameObject.Find("LatinMusicDoor"));
        Interactables.Add(GameObject.Find("HouseOfBluesDoor"));
        Interactables.Add(GameObject.Find("TraderJanesDoor"));
        Interactables.Add(GameObject.Find("ChowsChowDoor"));
        Interactables.Add(GameObject.Find("CommercialAlleyClick"));

        Interactables.Add(GameObject.Find("StadiumClick"));
        Interactables.Add(GameObject.Find("WheelClick"));
        Interactables.Add(GameObject.Find("BeachClick"));
    }

    // Update is called once per frame
    void Update ()
    {
		
	}
}
