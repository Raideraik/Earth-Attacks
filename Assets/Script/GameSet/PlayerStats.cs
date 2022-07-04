using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Money;
    public static int Lives;

    [SerializeField] private int _startMoney = 400;
    [SerializeField] private int _startLives = 20;


    private void Start()
    {
        Money = _startMoney;
        Lives = _startLives;
    }

}
