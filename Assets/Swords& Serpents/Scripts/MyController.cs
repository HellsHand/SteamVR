using UnityEngine;
using System.Collections;

public class MyController : MonoBehaviour {

    private Valve.VR.EVRButtonId gripButton = Valve.VR.EVRButtonId.k_EButton_Grip;
    private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;
    private Valve.VR.EVRButtonId touchAxis = Valve.VR.EVRButtonId.k_EButton_Axis0;
    private Valve.VR.EVRButtonId touchpadButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad;
    private bool northPressed, eastPressed, westPressed, southPressed;

    [HideInInspector]
    public Valve.VR.EVRButtonId menuButton = Valve.VR.EVRButtonId.k_EButton_ApplicationMenu;
    public SteamVR_Controller.Device controller { get { return SteamVR_Controller.Input((int)trackedObj.index); } }

    SteamVR_TrackedObject trackedObj;

    void Start()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
        return;
    }

    void Update()
    {
        Vector2 touching = controller.GetAxis(touchAxis);
        if (controller.GetPressDown(touchpadButton))
        {
            if(touching.y > .5 && touching.x > -.5 && touching.x < .5)
            {
                northPressed = true;
            }
            else if (touching.x > .5 && touching.y > -.5 && touching.y < .5)
            {
                eastPressed = true;
            }
            else if (touching.x < -.5 && touching.y > -.5 && touching.y < .5)
            {
                westPressed = true;
            }
            else if (touching.y < -.5 && touching.x > -.5 && touching.x < .5)
            {
                southPressed = true;
            }
        }

        if(controller.GetPressUp(touchpadButton))
        {
            northPressed = false;
            eastPressed = false;
            westPressed = false;
            southPressed = false;
        }
    }

    public bool GetNorthPressed()
    {
        bool north = northPressed;
        northPressed = false;
        return north;
    }
    public bool GetEastPressed()
    {
        bool east = eastPressed;
        eastPressed = false;
        return east;
    }
    public bool GetWestPressed()
    {
        bool west = westPressed;
        westPressed = false;
        return west;
    }
    public bool GetSouthPressed()
    {
        bool south = southPressed;
        southPressed = false;
        return south;
    }
}

