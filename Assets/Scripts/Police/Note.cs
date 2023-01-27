using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    int missingNumber = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PoliceObject")
        {
            Debug.Log("충돌한것" + collision);
            collision.gameObject.SetActive(false);
            missingNumber++;
            if (missingNumber == ReadyManager.Inst.policeCount)
            {
                ReadyManager.Inst.GameStart();
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject.tag == "PoliceObject")
        //{
        //    Debug.Log("충돌한것" + collision);
        //    DictionaryPool.Inst.Destroy(collision.gameObject);
        //}
    }
}
