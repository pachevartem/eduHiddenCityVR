using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace HiddenSity
{
    public class GameManager : MonoBehaviour
    {
        public ItemController ItemController;
        public UIController UiController;

        private int _countItems;

        private void Awake()
        {
            ItemController = new ItemController();
            UiController.init();
        }

        private void Start()
        {
            for (int i = 0; i < ItemController.Items.Count; i++)
            {
                UiController.AddTitleName(ItemController.Items[i]);
            }
            ItemController.ShowAllItem(true);
            Debug.Log("Все объекты включены");
            Item.ItemAction += item => { FindObject(); };
            SetCountItems(ItemController.Items.Count);
        }

        void SetCountItems(int count)
        {
            _countItems = count;
            UiController.SetScore(count);
        }

        void FindObject()
        {
            _countItems--;
            UiController.SetScore(_countItems);
            if (_countItems == 0)
            {
                SceneManager.LoadScene(0);
            }
        }

        private void OnDisable()
        {
            Item.ItemAction = null;
        }
    }
}