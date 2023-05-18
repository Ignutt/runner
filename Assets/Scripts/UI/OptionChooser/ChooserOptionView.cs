using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.OptionChooser
{
    public class ChooserOptionView : MonoBehaviour
    {
        [Header("Model")]
        [SerializeField] private ChooserOptionModel chooserOptionModel;

        [Header("Text")] 
        [SerializeField] private TextMeshProUGUI optionText;
        
        [Header("Buttons")] 
        [SerializeField] private Button chooseNextButton;
        [SerializeField] private Button choosePreviousButton;

        private void Start()
        {
            chooseNextButton.onClick.AddListener(() =>
            {
                chooserOptionModel.ChooseNextOption();
            });
            
            choosePreviousButton.onClick.AddListener(() =>
            {
                chooserOptionModel.ChoosePreviousOption();
            });

            chooserOptionModel.OnChooseOption += option =>
            {
                optionText.text = option.name;
            };
            
            optionText.text = chooserOptionModel.CurrentOption.name;
        }
    }
}
