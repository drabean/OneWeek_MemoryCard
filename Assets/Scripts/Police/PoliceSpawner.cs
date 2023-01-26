using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] obj;
    
    
    void Start()
    {
        for (int i = 0; i < obj.Length; i++)
        {
            DictionaryInstant(obj[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// obj�� �ش� ��ġ�� �����ϴ� �Լ�
    /// </summary>
    /// <param name="obj"></param>
    void DictionaryInstant(GameObject obj)
    {
        DictionaryPool.Inst.Instantiate(obj, obj.transform.position, Quaternion.identity, DictionaryPool.Inst.transform);
    }
}
