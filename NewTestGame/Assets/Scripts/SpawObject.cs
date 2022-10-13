using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpawObject : MonoBehaviour
{
    public static System.Action<float> onSpeed;
    public static System.Action<float> onDistance;
    [Range(0.5f, 10f)]
    [SerializeField] private float timeSpaw = 3;
    [SerializeField] private GameObject obj;
    [SerializeField] private TMP_InputField inputDistance;
    [SerializeField] private TMP_InputField inputTime;
    [SerializeField] private TMP_InputField inputSpeed;

    private float curentSpeed = 10, distance, randX;
    private Vector3 positionSpawObj;


    private void Start()
    {
        StartCoroutine(Spaw());

    }

    public void EditDistance() 
    {
        float maxDist = 124f;
        float inputNum = int.Parse(inputDistance.text);
        if (inputNum > 100)
            inputNum = 100;
        else if (inputNum < -1)
            inputNum *= -1;

        maxDist /= 100;
        maxDist *= inputNum;        
        distance = maxDist;
        onDistance?.Invoke(distance);

        
        
    }
    public void EditTimeSpaw() 
    {        
        timeSpaw = float.Parse(inputTime.text);        
    }

    public void EditSpeed()
    {
        float speed = 100;
        float inputNum = int.Parse(inputSpeed.text);

        if (inputNum > 100)
            inputNum = 100;
        else if (inputNum < -1)         
            inputNum *= (-1);


        speed /= 100;
        speed *= inputNum;
        curentSpeed = speed;

        onSpeed?.Invoke(speed);
    }

    IEnumerator Spaw() 
    {
        while (true)
        {
            randX = Random.Range(0f,60f);
            positionSpawObj = new Vector3(randX, transform.position.y, transform.position.z);
            yield return new WaitForSeconds(timeSpaw);
            Instantiate(obj, positionSpawObj, Quaternion.identity);
            onSpeed?.Invoke(curentSpeed);
            onDistance?.Invoke(distance);
        }
    }
}
