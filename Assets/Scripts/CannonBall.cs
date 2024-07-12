using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    [SerializeField] Vector3 targetPos;
    [SerializeField] float time;
    [SerializeField] int damage;
    [SerializeField] float range;
    [SerializeField] LayerMask mask;

    public void SetTargetPos(Vector3 targetPos)
    {
        this.targetPos = targetPos;
        StartCoroutine(CannonRoutine(transform.position, targetPos));
    }

    public void SetDamage(int damage)
    {
        this.damage = damage;
    }

    private void Explosion()
    {
        Collider[] collider = Physics.OverlapSphere(transform.position, range, mask);

        for(int i = 0; i < collider.Length; i++)
        {
			Monster monster = collider[i].gameObject.GetComponent<Monster>();
			monster.TakeDamage(damage);
		}

        Destroy(gameObject);
    }

    IEnumerator CannonRoutine(Vector3 startPos, Vector3 targetPos)
    {
        float rate = 0f;
        float ySpeed = -1 * (0.5f * Physics.gravity.y * time * time + startPos.y) / time;

        while(rate < 1f)
        {
            rate += Time.deltaTime / time;

            if(rate > 1f)
            {
                rate = 1f;
            }

            Vector3 vec3 = Vector3.Lerp(startPos, targetPos, rate);
            transform.position = new Vector3(vec3.x, transform.position.y, vec3.z);

            ySpeed += Physics.gravity.y * Time.deltaTime;
            transform.Translate(Vector3.up * ySpeed * Time.deltaTime);

            yield return null; 
        }

        Explosion();

	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
	}
}
