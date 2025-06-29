using UnityEngine;
using UnityEngine.UI;

public class MuteBackgroundMusic : MonoBehaviour
{
    [SerializeField] private AudioManager _AudioManager;
    [SerializeField] private BackgroundVolumeSlider _backgroundVolumeSlider;
    private Toggle _toggle;
    private float volume;
    // Start is called before the first frame update
    void Start()
    {
        _AudioManager = _AudioManager.GetComponent<AudioManager>();
        _toggle = GetComponent<Toggle>();
        _toggle.isOn = false;

        _backgroundVolumeSlider = _backgroundVolumeSlider.GetComponent<BackgroundVolumeSlider>();

        _toggle.onValueChanged.AddListener(delegate
        {
            if (_toggle.isOn == true)
            {
                _AudioManager.MuteBackgroundMusic();
            }
            else if (_toggle.isOn == false)
            {
                _AudioManager.UnmuteBackgroundMusic();
                _AudioManager.ChangeBackgroundMusicVolume(volume);

            }
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CurrentVolume(float value)
    {
        volume = value;
    }

    public bool IsMuted()
    {
        return _toggle.isOn;
    }
}
