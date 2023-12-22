using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteSounds : MonoBehaviour
{
    [SerializeField] private List<AudioSource> _audioSources = new();
    [SerializeField] private Button _muteSoundsButton;

    private bool _isMuteSounds = true;

    private void OnEnable()
    {
        _muteSoundsButton.onClick.AddListener(OnMuteSoundsButtonClick);
    }

    private void OnDisable()
    {
        _muteSoundsButton.onClick.RemoveListener(OnMuteSoundsButtonClick);
    }

    private void OnMuteSoundsButtonClick()
    {
        if (_isMuteSounds)
        {
            for (int i = 0; i < _audioSources.Count; i++)
                _audioSources[i].mute = false;

            _isMuteSounds = false;
        }
        else
        {
            for (int i = 0; i < _audioSources.Count; i++)
                _audioSources[i].mute = true;

            _isMuteSounds = true;
        }
    }
}