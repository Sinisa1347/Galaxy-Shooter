using UnityEngine;
using UnityEngine.UI;

public class BackgroundVolumeSlider : MonoBehaviour
{
    private Slider _slider;
    [SerializeField] private AudioManager _audioManager;

    // Start is called before the first frame update
    void Start()
    {
        _slider = GetComponent<Slider>();
        _audioManager = _audioManager.GetComponent<AudioManager>();
        _slider.value = _audioManager._backgroundSoundSource.volume;
    }

    // Update is called once per frame
    void Update()
    {
        _slider.onValueChanged.AddListener((value) =>
        {
            _audioManager.ChangeBackgroundMusicVolume(value);
        });
    }
}
