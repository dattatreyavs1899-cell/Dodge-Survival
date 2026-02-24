using System.Collections;
using UnityEngine;

public class moveToward : MonoBehaviour
{
    //public float speed = 1f;
    public float lifeTime = 10f;
    // [SerializeField] 
    Transform player;
    Vector3 playerPosition;
    float randomSpeed;

    public float destroyDelay = 1f;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        randomSpeed = Random.Range(12, 17);
        Debug.Log("randomSpeed" +  randomSpeed);
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {

       // if (player != null) return ;

        playerPosition = player.transform.position;
        transform .position = Vector3.MoveTowards(transform.position, playerPosition, randomSpeed * Time.deltaTime);
        
        

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GetComponent<MeshRenderer>().material.color = Color.red;
            //yield return new WaitForSeconds(lifeTime);

            Destroy(gameObject, destroyDelay);

        }
        
    }


}
