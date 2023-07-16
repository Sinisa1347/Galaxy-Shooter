using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] public AudioSource _backgroundSoundSource;
    [SerializeField] public AudioSource _explosionSoundSource;
    [SerializeField] public AudioSource _laserShotSoundSource;
    [SerializeField] public AudioSource _powerUpSoundSource;

    // Start is called before the first frame update
    void Start()
    {
        _backgroundSoundSource = _backgroundSoundSource.GetComponent<AudioSource>();
        _explosionSoundSource = _explosionSoundSource.GetComponent<AudioSource>();
        _laserShotSoundSource = _laserShotSoundSource.GetComponent<AudioSource>();
        _powerUpSoundSource = _powerUpSoundSource.GetComponent<AudioSource>();
    }

    public void ChangeSoundEffectsVolume(float value)
    {
        _explosionSoundSource.volume = value;
        _laserShotSoundSource.volume = value;
        _powerUpSoundSource.volume = value;
    }

    public void ChangeBackgroundMusicVolume(float value)
    {
        _backgroundSoundSource.volume = value;
    }
}
