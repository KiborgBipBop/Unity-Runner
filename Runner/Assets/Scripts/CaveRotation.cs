using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveRotation : MonoBehaviour
{
    private float sensetivity = 400;

    [SerializeField] private GameObject playerCharacter;
    private Player _player;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _player = playerCharacter.GetComponent<Player>();
        _rigidbody = GetComponent<Rigidbody>();
    }
    
    private void FixedUpdate()
    {
        if (_player.isAlive)
        {
            float rotation = -Input.GetAxis("Horizontal") * sensetivity * Time.fixedDeltaTime;
            _rigidbody.AddTorque(rotation * Vector3.forward);
        }
        else
        {
            _rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
        }
    }
}
