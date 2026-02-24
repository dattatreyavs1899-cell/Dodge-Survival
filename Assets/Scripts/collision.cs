using System.Collections;
using UnityEngine;

public class collision : MonoBehaviour
{
    public int waitTime = 3;
    private void OnCollisionEnter(Collision collision)
    {
     
        
        //GetComponent<MeshRenderer>().material.color = Color.olive;
        Debug.Log("hit: ");
        StartCoroutine(waitforChange(waitTime));

    }

    IEnumerator waitforChange (float time)
    {
        Debug.Log("Couroutine started");

        yield return new WaitForSeconds(time);
        GetComponent<MeshRenderer>().material.color = Color.red;

        Debug.Log("Couroutine ended");

    }
}
