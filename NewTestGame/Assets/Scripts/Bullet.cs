using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    [SerializeField] private float speed;
    [SerializeField] private Vector3 direction;
    [Range(0f, 100f)]
    [SerializeField] private float endDistance = 10;
    private Vector3 nachPos;
    private void Start()
    {
        nachPos = this.transform.position;
    }
    private void OnEnable()
    {
        SpawObject.onSpeed += EditSpeed;
        SpawObject.onDistance += EditDistance;

    }
    private void OnDisable()
    {
        SpawObject.onSpeed -= EditSpeed;
        SpawObject.onDistance -= EditDistance;
    }

    private void EditSpeed(float editSpeed) 
    {
        speed = editSpeed;
    }

    private void EditDistance(float editDistance) 
    {
        endDistance = editDistance;
    }

    void FixedUpdate()
    {
        transform.Translate(speed*direction*Time.deltaTime, Space.World);

        float curentDist = Vector3.Distance(nachPos, this.transform.position);

        if (curentDist > endDistance)
        {
            Destroy(this.gameObject);
        }

    }
}
