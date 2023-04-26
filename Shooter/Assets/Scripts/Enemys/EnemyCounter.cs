using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCounter : MonoBehaviour
{
    private int quantityEnemys;
    private int killedEnemys;

    public int KilledEnemys { get => killedEnemys; }
    public int QuantityEnemys { get => quantityEnemys; }

    // синглтон
    public static EnemyCounter Instance;
    private void Awake()
    {
        Instance = this;
        killedEnemys = 0;
        quantityEnemys = gameObject.GetComponentsInChildren<Aim>().Length;
    }

    public void CountKill()
    {
        killedEnemys++;
    }
}
