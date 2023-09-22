using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Experimental.RestService;
using UnityEngine;
using UnityEngine.UI;

public class UIRankFrame : MonoBehaviour
{
    [Header("Frame Assets")]
    [SerializeField] private Sprite frame1;
    [SerializeField] private Sprite frame2;
    [SerializeField] private Sprite frame3;
    [SerializeField] private Sprite frameOther;

    [Header("Medal Assets")]
    [SerializeField] private Sprite medal1;
    [SerializeField] private Sprite medal2;
    [SerializeField] private Sprite medal3;

    [Header("VIP Assets")]
    [SerializeField] private Sprite vip1;
    [SerializeField] private Sprite vip2;
    [SerializeField] private Sprite vip3;
    [SerializeField] private Sprite vip4;
    [SerializeField] private Sprite vip5;

    /*[Header("Progress Bar Assets")]
    [SerializeField] private Sprite progressBar1;
    [SerializeField] private Sprite progressBar2;
    [SerializeField] private Sprite progressBar3;
    [SerializeField] private Sprite progressBar4;
    [SerializeField] private Sprite progressBar5;*/

    [Header("Settings")]
    [SerializeField] private int loadLimit;

    [Header("Asset Referencing")]
    [SerializeField] private GameObject rankFramePrefab;
    [SerializeField] private Image frame;
    [SerializeField] private Image medal;
    [SerializeField] private TMPro.TextMeshProUGUI rank;
    [SerializeField] private Image avatar;
    [SerializeField] private new TMPro.TextMeshProUGUI name;
    [SerializeField] private Image vip;

    public event Action<Sprite, string, Sprite> OnButtonClick;


    // data: rank, name, avatar, vip, vippoint
    public void InitRankFrame(GameObject rankFrame, int playerRank, string playerName, Sprite playerAvatar, int playerVIP)
    {
        Transform[] children = new Transform[rankFrame.transform.childCount + 1];
        children[0] = rankFrame.transform;
        for (int i = 0; i < rankFrame.transform.childCount; i++)
        {
            children[i + 1] = rankFrame.transform.GetChild(i);
        }

        // frame & medal
        frame = children[0].GetComponent<Image>();
        medal = children[1].GetComponent<Image>();
        rank = children[2].GetComponent<TMPro.TextMeshProUGUI>();

        switch (playerRank)
        {
            case 1:
                rank.gameObject.SetActive(false);
                medal.gameObject.SetActive(true);
                frame.sprite = frame1; 
                medal.sprite = medal1;
                break;
            case 2:
                rank.gameObject.SetActive(false);
                medal.gameObject.SetActive(true);
                frame.sprite = frame2;
                medal.sprite = medal2;
                break;
            case 3:
                rank.gameObject.SetActive(false);
                medal.gameObject.SetActive(true);
                frame.sprite = frame3;
                medal.sprite = medal3;
                break;
            default:
                frame.sprite = frameOther;
                frame.gameObject.SetActive(true);
                medal.gameObject.SetActive(false);
                rank.text = "#" + playerRank;
                break;
        }

        // avatar
        avatar = children[3].GetComponent<Image>();
        avatar.sprite = playerAvatar;

        // name
        name = children[4].GetComponent<TMPro.TextMeshProUGUI>();
        name.text = playerName;

        // vip
        vip = children[5].GetComponent<Image>();
        switch (playerVIP)
        {
            case 1:
                vip.sprite = vip1;
                break;
            case 2:
                vip.sprite = vip2;
                break;
            case 3:
                vip.sprite = vip3;
                break;
            case 4:
                vip.sprite = vip4;
                break;
            case 5: 
                vip.sprite = vip5;
                break;
            default:
                break;
        }

        this.gameObject.GetComponent<Button>().onClick.AddListener(() => OnButtonClick?.Invoke(avatar.sprite, playerName, vip.sprite));
    }
}
