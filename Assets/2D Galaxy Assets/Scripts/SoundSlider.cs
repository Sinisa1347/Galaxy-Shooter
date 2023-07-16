using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSlider : MonoBehaviour
{
    private Slider _slider;
    [SerializeField] private GameObject _mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        _slider = GetComponent<Slider>();
        _slider.value = _mainCamera.GetComponent<AudioSource>().volume;
    }

    // Update is called once per frame
    void Update()
    {
        _slider.onValueChanged.AddListener((value) =>
        {
            _mainCamera.GetComponent<AudioSource>().volume = value;
        });
    }
}
