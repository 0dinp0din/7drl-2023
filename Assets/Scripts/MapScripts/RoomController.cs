using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RoomController : MonoBehaviour
{

    private bool hasTriggered = false;

    public void CheckIfTriggered(List<GameObject> enemies, bool triggerStatus)
    {

        hasTriggered = triggerStatus;
    }


}
