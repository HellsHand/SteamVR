using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WandController : MonoBehaviour {

    private Valve.VR.EVRButtonId gripButton = Valve.VR.EVRButtonId.k_EButton_Grip;
    //public bool gripButtonDown = false;
    //public bool gripButtonUp = false;
    //public bool gripButtonPressed = false;

    private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;
    //public bool triggerButtonDown = false;
    //public bool triggerButtonUp = false;
    //public bool triggerButtonPressed = false;

    ////private GameObject pickup;

    HashSet<InteractableItem> objectsHoveringOver = new HashSet<InteractableItem>();

    private InteractableItem closestItem;
    private InteractableItem interactingItem;
    WandController test;

    private SteamVR_Controller.Device controller { get { return SteamVR_Controller.Input((int)trackedObj.index); } }
    SteamVR_TrackedObject trackedObj;

	// Use this for initialization
	void Start () {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
        return;
	}
	
    

	// Update is called once per frame
	void Update () {
        //gripButtonDown = controller.GetPressDown(gripButton);
        //gripButtonUp = controller.GetPressUp(gripButton);
        //gripButtonPressed = controller.GetPress(gripButton);
        
        //triggerButtonDown = controller.GetPressDown(triggerButton);
        //triggerButtonUp = controller.GetPressUp(triggerButton);
        //triggerButtonPressed = controller.GetPress(triggerButton);

        /*if(gripButtonDown)
        {
            Debug.Log("Grip Button was just pressed.");
        }
        if(gripButtonUp)
        {
            Debug.Log("Grip button was just released.");
        }*/
        if(controller.GetPressDown(gripButton)/*// && pickup != null*/)
        {
            ////pickup.transform.parent = this.transform;
            ////pickup.GetComponent<Rigidbody>().useGravity = false;
            float minDistance = float.MaxValue;

            float distance;
            foreach(InteractableItem item in objectsHoveringOver)
            {
                distance = (item.transform.position - transform.position).sqrMagnitude;

                if(distance < minDistance)
                {
                    minDistance = distance;
                    closestItem = item;
                }
            }

            interactingItem = closestItem;
            closestItem = null;

            if(interactingItem)
            {
                if(interactingItem.IsInteracting())
                {
                    interactingItem.EndInteraction(this);
                    test = this;
                } 
                interactingItem.BeginInteraction(this);
            }
        }

        /*if(triggerButtonDown)
        {
            Debug.Log("Trigger Button was just pressed.");
        }
        if(triggerButtonUp) {
            Debug.Log("Trigger Button was just released.");
        }*/
        if(controller.GetPressUp(gripButton)/*// && pickup != null*/ && interactingItem != null)
        {
            ////pickup.transform.parent = null;
            ////pickup.GetComponent<Rigidbody>().useGravity = true;
            interactingItem.EndInteraction(this);
        }
    }

    private void OnTriggerEnter(Collider collided)
    {
        Debug.Log("Collided with");
        ////pickup = collided.gameObject;
        InteractableItem collidedItem = collided.GetComponent<InteractableItem>();
        if(collidedItem)
        {
            objectsHoveringOver.Add(collidedItem);
        }
    }

    private void OnTriggerExit(Collider collided)
    {
        Debug.Log("Ended Collision");
        ////pickup = null;
        InteractableItem collidedItem = collided.GetComponent<InteractableItem>();
        if (collidedItem)
        {
            objectsHoveringOver.Remove(collidedItem);
        }
    }
}
