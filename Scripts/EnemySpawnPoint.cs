using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawnPoint : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;

    public void Spawn()
    {
        Instantiate(_enemy, transform.position, Quaternion.identity);
    }
}
