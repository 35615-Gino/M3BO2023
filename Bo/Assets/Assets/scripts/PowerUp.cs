using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public AudioSource power;
    public float Mulitply =3f;
    public float duration = 5f;

    //rotation
    float rot;

    // Start is called before the first frame update
    private void Update()
    {
        rot += Time.deltaTime * 100;
        transform.rotation = Quaternion.Euler(rot, rot, rot);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(pickup(other));
        }
        power.Play();
    }
    
    IEnumerator pickup(Collider player)
    {
        Player speed = player.GetComponent<Player>();
        player.transform.localScale *= Mulitply;
        speed.max_speed *= Mulitply;

        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>();
        
        yield return new WaitForSeconds(duration);

        player.transform.localScale /= Mulitply;
        speed.max_speed /= Mulitply;
        Destroy(gameObject);
    }
}
