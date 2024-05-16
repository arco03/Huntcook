using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public GameObject meat;
    private bool condicion = false;

    //// Start is called before the first frame update
    //void Start()
    //{
        
    //}

    //// Update is called once per frame
    void Update()
    {
        if(condicion)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                meat.transform.SetParent(this.transform);

                meat.transform.localPosition = new Vector3(0f, 0f, -0.930999994f);

            }
        }


    }
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("meat"))
        {

            condicion = true;
          

            
        }
           
    }
}
