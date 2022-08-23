using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    GameObject _player;
    private void Awake()
    {
       _player = GameObject.Find("Player");
    }

    private void Update()
    {
        if (_player != null)
        transform.position = new Vector3(_player.transform.position.x, transform.position.y, transform.position.z);
    }
}
