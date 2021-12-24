
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    CannonBall cannonball;

    public float speed = 5f;

    public GameObject ImpactEffect;

    private Transform target;

    public void FireAtTarget(Transform _target)
    {
        target = _target;
    }

    private void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 direction = target.position - transform.position;
        float speedAtFrame = speed * Time.deltaTime;

        if (direction.magnitude <= speedAtFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(direction.normalized * speedAtFrame, Space.World);
    }

    void HitTarget()
    {
        GameObject effectIns = (GameObject)Instantiate(ImpactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 2);
        Destroy(gameObject);
        
    }
}
