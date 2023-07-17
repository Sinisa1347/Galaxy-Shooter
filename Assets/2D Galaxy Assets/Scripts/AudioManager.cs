using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] public AudioSource _backgroundSoundSource;
    [SerializeField] public AudioSource _explosionSoundSource;
    [SerializeField] public AudioSource _laserShotSoundSource;
    [SerializeField] public AudioSource _powerUpSoundSource;

    private float defaultVolume = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        _backgroundSoundSource = _backgroundSoundSource.GetComponent<AudioSource>();
        _backgroundSoundSource.volume = defaultVolume;

        _explosionSoundSource = _explosionSoundSource.GetComponent<AudioSource>();
        _explosionSoundSource.volume = defaultVolume;

        _laserShotSoundSource = _laserShotSoundSource.GetComponent<AudioSource>();
        _laserShotSoundSource.volume = defaultVolume;

        _powerUpSoundSource = _powerUpSoundSource.GetComponent<AudioSource>();
        _powerUpSoundSource.volume = defaultVolume;
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

    public float GetDefaultVolume()
    {
        return defaultVolume;
    }

    public void MuteBackgroundMusic()
    {
        _backgroundSoundSource.mute = true;
    }

    public void UnmuteBackgroundMusic()
    {
        _backgroundSoundSource.mute = false;
    }

    public void MuteSoundEffects()
    {
        _explosionSoundSource.mute = true;
        _laserShotSoundSource.mute = true;
        _powerUpSoundSource.mute = true;
    }

    public void UnmuteSoundEffects()
    {
        _explosionSoundSource.mute = false;
        _laserShotSoundSource.mute = false;
        _powerUpSoundSource.mute = false;
    }
}
