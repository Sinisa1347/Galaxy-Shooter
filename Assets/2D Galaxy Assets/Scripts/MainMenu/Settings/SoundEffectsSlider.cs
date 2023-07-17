using UnityEngine;
using UnityEngine.UI;

public class SoundEffectsVolumeSlider : MonoBehaviour
{
    private Slider _slider;
    [SerializeField] private AudioManager _audioManager;
    [SerializeField] private MuteSoundEffect _muteSoundEffect;

    // Start is called before the first frame update
    void Start()
    {
        _slider = GetComponent<Slider>();
        _audioManager = _audioManager.GetComponent<AudioManager>();
        _slider.value = _audioManager._backgroundSoundSource.volume;
        _muteSoundEffect = _muteSoundEffect.GetComponent<MuteSoundEffect>();

        _slider.onValueChanged.AddListener((value) =>
        {
            _muteSoundEffect.CurrentVolume(value);

            if (_muteSoundEffect.IsMuted() == false)
            {
                _audioManager.ChangeSoundEffectsVolume(value);
            }
        });
    }

    // Update is called once per frame
    void Update()
    {
        if (_slider.value == _audioManager.GetDefaultVolume())
        {
            _muteSoundEffect.CurrentVolume(_audioManager.GetDefaultVolume());
        }
    }
}