using UnityEngine;
using UnityEngine.UI;

public class BackgroundVolumeSlider : MonoBehaviour
{
    private Slider _slider;
    [SerializeField] private AudioManager _audioManager;
    [SerializeField] private MuteBackgroundMusic _muteBackgroundMusic;

    // Start is called before the first frame update
    void Start()
    {
        _slider = GetComponent<Slider>();
        _audioManager = _audioManager.GetComponent<AudioManager>();
        _slider.value = _audioManager._backgroundSoundSource.volume;
        _muteBackgroundMusic = _muteBackgroundMusic.GetComponent<MuteBackgroundMusic>();

        _slider.onValueChanged.AddListener((value) =>
        {
            _muteBackgroundMusic.CurrentVolume(value);

            if (_muteBackgroundMusic.IsMuted() == false)
            {
                _audioManager.ChangeBackgroundMusicVolume(value);
            }
        });
    }

    // Update is called once per frame
    void Update()
    {
        if(_slider.value == _audioManager.GetDefaultVolume())
        {
            _muteBackgroundMusic.CurrentVolume(_audioManager.GetDefaultVolume());
        }
    }
}
