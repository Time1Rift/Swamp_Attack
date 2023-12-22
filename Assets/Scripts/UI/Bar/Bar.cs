using UnityEngine;
using UnityEngine.UI;

public abstract class Bar : MonoBehaviour
{
    [SerializeField] protected Slider Slider;

    private void Start()
    {
        Slider.interactable = false;
        Slider.value = 1;
    }

    protected void OnValueChanged(int value, int maxValue)
    {
        Slider.value = (float)value / maxValue;
    }
}