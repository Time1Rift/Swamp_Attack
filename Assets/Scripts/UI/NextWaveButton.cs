using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button), typeof(CanvasGroup))]
public class NextWaveButton : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;

    private Button _nextWaveButton;
    private CanvasGroup _canvasGroup;

    private void Awake()
    {
        _nextWaveButton = GetComponent<Button>();
        _canvasGroup = GetComponent<CanvasGroup>();

        _canvasGroup.alpha = 0;
        _canvasGroup.interactable = false;
    }

    private void OnEnable()
    {
        _spawner.AllEnemySpawned += OnAllEnemySpawned;
        _nextWaveButton.onClick.AddListener(OnNextWaveButtonClick);
    }

    private void OnDisable()
    {
        _spawner.AllEnemySpawned -= OnAllEnemySpawned;
        _nextWaveButton.onClick.RemoveListener(OnNextWaveButtonClick);
    }

    private void OnAllEnemySpawned()
    {
        _canvasGroup.alpha = 1;
        _canvasGroup.interactable = true;
    }

    private void OnNextWaveButtonClick()
    {
        _spawner.NextWave();

        _canvasGroup.alpha = 0;
        _canvasGroup.interactable = false;
    }
}