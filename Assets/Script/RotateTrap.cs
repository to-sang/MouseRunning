using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTrap : MonoBehaviour
{
    [SerializeField] private float limit;
    [SerializeField] private float speed;
    private float time = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime * speed;
        transform.Rotate(0, 0, 360 * limit * Time.deltaTime * Mathf.Cos(time));
    }
}
