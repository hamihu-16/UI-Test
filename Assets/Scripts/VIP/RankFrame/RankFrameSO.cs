using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankFrameSO : ScriptableObject
{
    [SerializeField] private Image image;
    [SerializeField] private string rank;
    [SerializeField] private Image avatar;
    [SerializeField] private string playerName;
    [SerializeField] private int vipRank;

}
