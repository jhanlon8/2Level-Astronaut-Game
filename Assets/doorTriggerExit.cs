using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorTriggerExit : MonoBehaviour
{
    public Transform door;

    public Vector3 closedD = new Vector3(-29.1f, 7.5f, -0.1000004f);
    public Vector3 openedD = new Vector3(-29.1f, 17.5f, -0.1000004f);

    public float openSpeed = 5;

    private bool open = false;

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
            //once player gets all 4 collectables then the exit door opens
            if (KeepScoreScene3.items == 4)
            {
                openDoor();
            }
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
