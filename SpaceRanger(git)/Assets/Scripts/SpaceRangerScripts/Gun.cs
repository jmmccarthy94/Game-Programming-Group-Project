using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;

    public GameObject GunObject;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
        Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * range, Color.green);
        Debug.DrawRay(GunObject.transform.position, GunObject.transform.forward * range, Color.red);
    }

    void Shoot()
    {
        RaycastHit hit;
        if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            EnemyCombat enemyCombat = hit.transform.GetComponent<EnemyCombat>();
            if(enemyCombat != null)
            {
                Debug.Log("Its  here");
                enemyCombat.TakeDamage(damage);
            }
            
        }
    }
}
