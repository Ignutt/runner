using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UI.OptionChooser
{
    [Serializable]
    public struct Option
    {
        public string name;
        public Action onChoose;

        public Option(string name, Action onChoose)
        {
            this.name = name;
            this.onChoose = onChoose;
        }
    }
    
    public class ChooserOptionModel : MonoBehaviour
    {
        [SerializeField] private Option[] defaultOptions;

        private List<Option> _options = new List<Option>();
        private int _currentIndex = 0;
        
        public Option CurrentOption { get; private set; }

        public delegate void ChooseOption(Option option);
        public event ChooseOption OnChooseOption;

        private void Awake()
        {
            if (defaultOptions.Length == 0)
            {
                return;
            }
            
            CurrentOption = defaultOptions[_currentIndex];
            _options = defaultOptions.ToList();
        }

        public void ChooseNextOption()
        {
            _currentIndex++;
            if (_currentIndex >= _options.Count)
            {
                _currentIndex = 0;
            }
            
            SetOption(_options[_currentIndex]);
        }

        public void ChoosePreviousOption()
        {
            _currentIndex--;
            if (_currentIndex < 0)
            {
                _currentIndex = _options.Count - 1;
            }
            
            SetOption(_options[_currentIndex]);
        }

        public void AddOption(Option option)
        {
            _options.Add(option);

            if (CurrentOption.Equals(null)) return;
            
            SetOption(option);
        }

        private void SetOption(Option option)
        {
            CurrentOption = option;
            CurrentOption.onChoose?.Invoke();
            OnChooseOption?.Invoke(option);
        }
    }
}
