using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace HiddenSity
{
    public class ItemController
    {
        public ItemController()
        {
            init();
        }

        public List<Item> Items = new List<Item>();

        public void init()
        {
            Items = MonoBehaviour.FindObjectsOfType<Item>().ToList();
            foreach (var item in Items)
            {
                item.init();
            }
            Debug.Log("Найдено объектов в сцене - " + Items.Count);
        }

        public void ShowAllItem(bool isOn)
        {
            foreach (var item in Items)
            {
                item.ShowItem(isOn);
            }
        }
    }
}