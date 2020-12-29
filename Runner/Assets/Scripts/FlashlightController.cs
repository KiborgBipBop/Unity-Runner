using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightController : MonoBehaviour
{
    private Light _light;
    public float minLightIntensity = 0.0005f;
    public float minLightRange = 15f;
    private float _currIntensity;
    private float _currRange;
    public float maxLightIntensity = 1.5f;
    public float maxLightRange = 100f;

    private Player _player;

    private void Start()
    {
        _light = GetComponent<Light>();
        _player = transform.parent.gameObject.GetComponent<Player>();
        _currIntensity = 1.2f;
        _currRange = maxLightRange;
    }
    
    private void Update()
    {
        if (_player.isAlive)
        {
            _currIntensity -= 0.0005f;
            _currRange -= 0.05f;
            _light.intensity = Mathf.Clamp(_currIntensity, minLightIntensity, maxLightIntensity);
            _light.range = Mathf.Clamp(_currRange, minLightRange, maxLightRange);
        }
    }

    public void CollectLight(Collider firefly)
    {
        _currIntensity += 0.3f;
        _currRange += 80f;
        Destroy(firefly.gameObject);
    }
}
