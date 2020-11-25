using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack1 : MonoBehaviour
{
    [SerializeField]
    private float shootTime = 0f;
    [SerializeField]
    private float launchForce = 0f;
    [SerializeField]
    private List<Vector3> launchDirections = null;

    [SerializeField]
    private GameObject spellPrefab = null;

    private void Awake()
    {
        StartCoroutine(OnShooting());
    }

    private void OnDrawGizmos()
    {
        foreach (var direction in launchDirections)
            Gizmos.DrawLine(transform.position, direction);
    }

    private IEnumerator OnShooting()
    {
        while (true)
        {
            yield return new WaitForSeconds(shootTime);
            Shoot();
        }
    }

    private void Shoot()
    {
        foreach (var direction in launchDirections)
        {
            GameObject spell = Instantiate(spellPrefab, transform.position, Quaternion.identity);
            spell.GetComponent<Rigidbody2D>().velocity = Vector3.Normalize(direction - transform.position) * launchForce;
        }
    }
}
