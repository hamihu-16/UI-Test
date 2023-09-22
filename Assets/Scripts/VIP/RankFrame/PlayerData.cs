using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [Header("Rank Info")]
     public int rank;
     public new string name;
     public Sprite avatar;
     public int vip;
     public int vipPoint;
     public bool friended;

    [Header("Currency")]
     public int chip;
     public int gCoin;

    [Header("Matches")]
     public int win8Ball;
     public int total8Ball;
     public int rp8Ball;
     public int winSnooker;
     public int totalSnooker;
     public int rpSnooker;
     public int win9Ball;
     public int total9Ball;
     public int rp9Ball;

    public PlayerData()
    {

    }

    
}
