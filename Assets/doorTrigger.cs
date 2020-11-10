using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorTrigger : MonoBehaviour
{
    public Transform door;

    public Vector3 closedD = new Vector3(29.2f, 7.514194f, -0.5f);
    public Vector3 openedD = new Vector3(29.2f, 17.514194f, -0.5f);

    public float openSpeed = 5;

    public bool open = false;

    public UnityEngine.Events.UnityEvent doorTriggers;

    void Update()
    {
        if (open)
        {
            
            door.position = Vector3.Lerp(door.position, openedD, Time.deltaTime * openSpeed);
        }
        else
        {
            door.position = Vector3.Lerp(door.position, closedD, Time.deltaTime * openSpeed);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            doorTriggers.Invoke();
            openDoor();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            closeDoor();
        }
    }
    public void closeDoor()
    {
        open = false;
    }
    public void openDoor()
    {
        open = true;
    }

    
}
