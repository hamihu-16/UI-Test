using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInfoHeaderHandler : MonoBehaviour
{
    [SerializeField] private List<GameObject> unselectedButtonList;
    [SerializeField] private List<GameObject> selectedButtonList;
    [SerializeField] private List<GameObject> panelList;

    //[SerializeField] private string isActive;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < unselectedButtonList.Count; i++)
        {
            //Debug.Log(unselectedButtonList[i].name);
            int index = i;
            Button button = unselectedButtonList[i].GetComponent<Button>();
            button.onClick.AddListener(() => OnSidebarButtonClicked(index));
        }
    }

    private void OnSidebarButtonClicked(int index)
    {
        for (int i = 0; i < unselectedButtonList.Count; i++)
        {
            if (index == i)
            {
                unselectedButtonList[i].gameObject.SetActive(false);
                selectedButtonList[i].gameObject.SetActive(true);
                panelList[i].gameObject.SetActive(true);
            }
            else
            {
                unselectedButtonList[i].gameObject.SetActive(true);
                selectedButtonList[i].gameObject.SetActive(false);
                panelList[i].gameObject.SetActive(false);
            }
        }

    }
}
