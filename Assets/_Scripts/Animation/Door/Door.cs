using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
   [SerializeField] private Animator anim;
   [SerializeField] private String detected;

   

   private void Start()
   {
       anim.enabled = false;
   }

   private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag(detected))
        {
            anim.enabled = true;
        }
    }
    private void OnCollisionExit(Collision other)
    {

            // anim.enabled = false;
        
    }
}
