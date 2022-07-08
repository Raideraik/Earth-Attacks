using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Money;
    public static int Lives;

    [SerializeField] private int _startMoney = 400;
    [SerializeField] private int _startLives = 20;
    [SerializeField] private int _income = 10;
    [SerializeField] private float _timeOfIncome = 5;


    private void Start()
    {
        Money = _startMoney;
        Lives = _startLives;

        InvokeRepeating("AddMoney", 5f, _timeOfIncome);
    }

    private void AddMoney() 
    {
        Money += _income;
    }

}
