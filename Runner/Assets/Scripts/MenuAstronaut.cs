using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAstronaut : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnMouseEnter()
    {
        if (!_animator.GetCurrentAnimatorStateInfo(0).IsName("Flip"))
        {
            _animator.SetTrigger("flip");
        }
    }
}
