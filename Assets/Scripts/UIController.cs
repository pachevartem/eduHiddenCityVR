using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace HiddenSity
{
    public class UIController : MonoBehaviour
    {
        public GameObject TVContainer;
        public Text ScoreText;
        public GameObject prefabTitle;

        private Dictionary<Item, UI_TitleItem> ItemsUI = new Dictionary<Item, UI_TitleItem>();


        public void SetScore(int score)
        {
            ScoreText.text = score.ToString();
        }

        public void init()
        {
            Item.ItemAction += DeleteTitleName;
        }

        public void AddTitleName(Item item)
        {
            GameObject title = Instantiate(prefabTitle, TVContainer.transform);
            UI_TitleItem UIItem = title.GetComponent<UI_TitleItem>();
            UIItem.UIName = item.Name;
            UIItem.SetName();
            ItemsUI.Add(item, UIItem);
        }

        public void DeleteTitleName(Item item)
        {
            if (ItemsUI.ContainsKey(item))
            {
                ItemsUI[item].gameObject.SetActive(false);
            }
        }

        private void OnDestroy()
        {
            Item.ItemAction -= DeleteTitleName;
        }
    }
}