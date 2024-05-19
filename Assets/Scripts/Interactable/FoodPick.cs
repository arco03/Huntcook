using Interactable;
using Playable;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FoodPick : MonoBehaviour, IDetector
{
    public GameObject _player;
    private Rigidbody _rb;

    private bool isPicked;
    
    private void Start()
    {
        
        _rb = GetComponent<Rigidbody>();
    }
    
    public void Interaction()
    {
        isPicked = !isPicked;
        if (isPicked)
        {
            transform.SetParent(_player.transform);
            transform.localPosition = new Vector3(0f, 0.161f, 1f);
            _rb.constraints = RigidbodyConstraints.FreezeAll;
        }
        else
        {
            transform.SetParent(null);
            _rb.constraints = RigidbodyConstraints.None;
        }
            
    }
}
