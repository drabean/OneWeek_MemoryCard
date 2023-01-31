using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    int missingNumber = 0;
    int archaeologistNumber = 0;
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

        if (collision.gameObject.CompareTag("Point"))
        {
            collision.gameObject.SetActive(false);
            archaeologistNumber++;
            if (archaeologistNumber == ReadyManager.Inst.ArchaeologistCount)
            {
                ReadyManager.Inst.GameStart();
            }
        }

        if (collision.gameObject.CompareTag("ArchaeologistObject"))
        {
            collision.gameObject.SetActive(false);
            archaeologistNumber++;
            if (archaeologistNumber == ReadyManager.Inst.ArchaeologistCount)
            {
                ReadyManager.Inst.GameStart();
            }
        }
    }
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "PoliceObject")
    //    {
    //        Debug.Log("충돌한것" + collision);
    //        DictionaryPool.Inst.Destroy(collision.gameObject);
    //    }
    //}
}
