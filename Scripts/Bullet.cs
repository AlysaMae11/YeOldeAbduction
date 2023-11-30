
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private Transform target;
    public float speed = 70f;

    public int damage = 50;

    public float ExplosionRadius = 0f;
    public GameObject impactEffect;
    
    public void Seek(Transform _target)
    {
        target = _target;
    }
  
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisframe = speed * Time.deltaTime;

        if(dir.magnitude <= distanceThisframe)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisframe, Space.World);
        transform.LookAt(target);

    }

    void HitTarget()
    {
        GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 5f);

        if (ExplosionRadius > 0f)
        {
            Explode();
        }else
        {
           Damage(target);
        }

        Destroy(gameObject);
    }

    void Explode()
    {
        Collider []  colliders = Physics.OverlapSphere(transform.position, ExplosionRadius);

       // print (colliders);

        foreach (Collider collider in colliders)
        {
            //print(collider.tag);
            if (collider.CompareTag("Enemy"))
            {
                Damage(collider.transform);            
            }

        }
    }

    void Damage (Transform enemy)
    {

        Enemy e = enemy.GetComponent<Enemy>();

        if (e != null)
        {
            e.TakeDamage(damage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, ExplosionRadius);
        Gizmos.color = Color.red;
    }
}
