using System.Collections;
using System.Collections.Generic;
using UnityEngine;

     [RequireComponent(typeof(Rigidbody2D))]
public class ProjetioBala : MonoBehaviour
{
    [SerializeField] private float _velocidade; 
    void Start()
    {
        var rb = GetComponent<Rigidbody2D>();
        rb.velocity = rb.transform.right * _velocidade;
    }
    
    private void OnTriggerEnter2D(ColliderDistance2D collison)
    {
        Destroy(gameObject);
    }

}
