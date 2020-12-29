using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Animator _animator;
    public float speed = 0.35f;
    public bool isAlive { get; private set; } = true;

    private FlashlightController _flashlight;

    private void Start()
    {
        RenderSettings.skybox.SetFloat("_Exposure", 0);
        _animator = GetComponent<Animator>();
        _flashlight = GetComponentInChildren<FlashlightController>();
    }

    private void FixedUpdate()
    {
        if (!isAlive) return;

        speed += 0.0004f;
        transform.Translate(0, 0, speed);
        if (transform.position.z >= 600)
        {
            float skyboxExposure = RenderSettings.skybox.GetFloat("_Exposure");
            RenderSettings.skybox.SetFloat("_Exposure", skyboxExposure += 0.004f);
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Obstacle"))
        {
            StartCoroutine(Die());
        }
        else if (other.CompareTag("Firefly"))
        {
            _flashlight.CollectLight(other);
        }
        else if (other.CompareTag("FinishBar"))
        {
            Loader.LoadOnAction("LevelComplete");
        }
    }

    private IEnumerator Die()
    {
        isAlive = false;
        _animator.SetBool("fallDown", true);
        yield return new WaitForSeconds(_animator.GetCurrentAnimatorStateInfo(0).length + 0.5f);
        Loader.LoadOnAction("Failed");
    }
}
