using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace HiddenSity
{
    public class Item : MonoBehaviour
    {
        //visible in Inspector variables
        public string Name;

        //privat variables
        private TextMeshPro TitleName;
        private Renderer _renderer;
        private BoxCollider _boxCollider;

        public static Action<Item> ItemAction;

        void ClickMe(Item i)
        {
            if (ItemAction != null)
            {
                ItemAction(this);
            }
            ShowItem(false);
        }

        public void init()
        {
            _renderer = GetComponent<Renderer>();
            _boxCollider = GetComponent<BoxCollider>();

            if (Name == "")
            {
                Debug.LogError("не назначено имя объекта в скрипте -" + this.Name);
            }


            TitleName = GetComponentInChildren<TextMeshPro>();
            if (TitleName == null)
            {
                Debug.LogError("не найден объект TextMeshPro -" + this.Name);
            }

            SetName();
            ShowName(false);
            ShowItem(true);


            EventTrigger trigger = GetComponent<EventTrigger>();

            EventTrigger.Entry clickEntry = new EventTrigger.Entry();
            clickEntry.eventID = EventTriggerType.PointerClick;
            clickEntry.callback.AddListener(arg0 => { ClickMe(this); });
            trigger.triggers.Add(clickEntry);

            EventTrigger.Entry entryEntry = new EventTrigger.Entry();
            entryEntry.eventID = EventTriggerType.PointerEnter;
            entryEntry.callback.AddListener(arg0 => { ShowName(true); });
            trigger.triggers.Add(entryEntry);

            EventTrigger.Entry entryExit = new EventTrigger.Entry();
            entryExit.eventID = EventTriggerType.PointerExit;
            entryExit.callback.AddListener(arg0 => { ShowName(false); });
            trigger.triggers.Add(entryExit);
        }


        void SetName()
        {
            TitleName.text = Name;
        }

        public void ShowItem(bool isOn)
        {
            _renderer.enabled = isOn;
            _boxCollider.enabled = isOn;
        }

        public void ShowName(bool isOn)
        {
            TitleName.enabled = isOn;
        }
    }
}