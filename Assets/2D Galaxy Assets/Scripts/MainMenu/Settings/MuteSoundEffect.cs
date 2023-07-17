using UnityEngine;
using UnityEngine.UI;

public class MuteSoundEffect : MonoBehaviour
{
    [SerializeField] private AudioManager _AudioManager;
    private Toggle _toggle;
    private float volume;
    // Start is called before the first frame update
    void Start()
    {
        _AudioManager = _AudioManager.GetComponent<AudioManager>();
        _toggle = GetComponent<Toggle>();
        _toggle.isOn = false;

        _toggle.onValueChanged.AddListener(delegate
        {
            if(_toggle.isOn==true)
            {
                _AudioManager.MuteSoundEffects();
            }
            else if (_toggle.isOn == false)
            {
                _AudioManager.UnmuteSoundEffects();
                _AudioManager.ChangeSoundEffectsVolume(volume);
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
