using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIRankFrameGen : MonoBehaviour
{
    [SerializeField] private GameObject rankFramePrefab;
    [SerializeField] private GameObject content;

    [SerializeField] private GameObject profilePopUp;
    [SerializeField] private Image profileAvatar;
    [SerializeField] private TMPro.TextMeshProUGUI profilePlayerName;
    [SerializeField] private Image profileVip;

    [SerializeField] private int loadLimit = 20;

    [SerializeField] private List<Sprite> playerAvatarList;
    // Start is called before the first frame update
    void Start()
    {
        InitRankFrameContent();
    }

    private void InitRankFrameContent()
    {
        int lastVip = 6;
        for (int i = 0; i < loadLimit; i++)
        {
            int randomVip = UnityEngine.Random.Range(1, lastVip);
            GameObject rankFrame = Instantiate(rankFramePrefab, content.transform);
            UIRankFrame uiRankFrame= rankFrame.GetComponent<UIRankFrame>();
            uiRankFrame.InitRankFrame(rankFrame, i + 1, "Player" + i, playerAvatarList[i], randomVip);
            lastVip = randomVip;

            uiRankFrame.OnButtonClick += RankFrame_OpenProfilePopUp;
        }
    }

    private void RankFrame_OpenProfilePopUp(Sprite avatar, string playerName, Sprite vip)
    {
        profilePopUp.SetActive(true);
        profileAvatar.sprite = avatar;
        profilePlayerName.text = playerName;
        profileVip.sprite = vip;
    }

    public void CloseProfilePopUp()
    {
        profilePopUp.SetActive(false);
    }
}
