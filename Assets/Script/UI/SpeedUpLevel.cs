using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpLevel : MonoBehaviour
{
    public void SpeedUP(int timeSpeed)
    {
        Time.timeScale = timeSpeed;
    }
}
