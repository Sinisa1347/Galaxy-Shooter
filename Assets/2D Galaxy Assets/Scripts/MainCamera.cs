using UnityEngine;

public class MainCamera : MonoBehaviour
{
    private AudioSource _backgroundMusic;

    // Start is called before the first frame update
    void Start()
    {
        _backgroundMusic = GameObject.FindWithTag("AudioManager").GetComponent<AudioManager>()._backgroundSoundSource;
        _backgroundMusic.Play();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
