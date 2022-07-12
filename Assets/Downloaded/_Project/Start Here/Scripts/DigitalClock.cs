using System;
using TMPro;
using UnityEngine;

namespace Com.InfallibleCode.Start_Here
{
    public class DigitalClock : MonoBehaviour
    {
        [SerializeField] private TMP_Text label;
        
        private float _value;
        private bool _isCounting;
        
        public void Play()
        {
            _isCounting = true;
        }

        private void Start()
        {
            _value = 0;
        }

        private void Update()
        {
            if (!_isCounting) return;
            _value += Time.deltaTime;
            var ts = TimeSpan.FromSeconds(_value);
            label.text = $"{ts.Hours:D2}:{ts.Minutes:D2}:{ts.Seconds:D2}:{ts.Milliseconds:D3}";
        }
    }
}