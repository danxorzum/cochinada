using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class Granade : MonoBehaviour
{
    Rigidbody _rb;
    public float power = 200;
    public float divisionPower = 100;
    public float divisionTime=3.0f;
    public int divisions = 5;

    // Start is called before the first frame update
    void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody>();
        _rb.AddRelativeForce(Vector3.forward * power);
    }
    public void Divide()
    {
        StartCoroutine(Division());
    }
    IEnumerator Division()
    {
        yield return new WaitForSeconds(divisionTime);
        for(int i=0; i < divisions; i++)
        {
            Quaternion rotation = Quaternion.AngleAxis(i * 360/divisions, Vector3.up);
             Instantiate(gameObject, transform.position, rotation);
        }
            Destroy(gameObject);

    }
}
