using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    private Slider _slider;
    [SerializeField] private GameObject player;

    private void Start()
    {
        _slider = GetComponent<Slider>();
        _slider.value = 0;
        _slider.maxValue = 750;
    }

    private void Update()
    {
        _slider.value = player.transform.position.z;
    }
}
