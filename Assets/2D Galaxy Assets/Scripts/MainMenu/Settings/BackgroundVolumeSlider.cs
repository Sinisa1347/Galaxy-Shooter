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
    }

    // Update is called once per frame
    void Update()
    {
        _slider.onValueChanged.AddListener((value) =>
        {
            if (_muteBackgroundMusic.IsMuted() == true)
            {
                _muteBackgroundMusic.CurrentVolume(value);
            }
            else if(_muteBackgroundMusic.IsMuted() == false)
            {
                _muteBackgroundMusic.CurrentVolume(value);
                _audioManager.ChangeBackgroundMusicVolume(value);
            }
        });
    }
}
