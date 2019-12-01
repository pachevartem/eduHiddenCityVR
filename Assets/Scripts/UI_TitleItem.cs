using System;
using UnityEngine;
using UnityEngine.UI;

namespace HiddenSity
{
    public class UI_TitleItem : MonoBehaviour
    {
        private Text name;
        public string UIName;

        private void OnEnable()
        {
            init();
        }

        void init()
        {
            name = GetComponentInChildren<Text>();
        }

        public void SetName()
        {
            name.text = UIName;
        }
    }
}