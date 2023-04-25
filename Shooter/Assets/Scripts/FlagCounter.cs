using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagCounter : MonoBehaviour
{
    private int quantityFlags;
    private int reachedFlags;

    public int ReachedFlags { get => reachedFlags; }

    // синглтон
    public static FlagCounter Instance;
    private void Awake()
    {
        Instance = this;
        reachedFlags = 0;
        quantityFlags = gameObject.GetComponentsInChildren<Flag>().Length;
    }
    
    public void MarkFlag()
    {
        reachedFlags++;
    }
}
