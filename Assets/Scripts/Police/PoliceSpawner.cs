using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceSpawner : MonoBehaviour
{
    [SerializeField] GameObject button;
    [SerializeField] GameObject fingerPrint;
    [SerializeField] GameObject handCuffs;
    [SerializeField] GameObject magnifyingGlasses;
    [SerializeField] GameObject closet;
    [SerializeField] GameObject earRing;
    
    void Start()
    {
        DictionaryInstant(button);
        DictionaryInstant(fingerPrint);
        DictionaryInstant(handCuffs);
        DictionaryInstant(magnifyingGlasses);
        DictionaryInstant(closet);
        DictionaryInstant(earRing);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// obj를 해당 위치에 생성하는 함수
    /// </summary>
    /// <param name="obj"></param>
    void DictionaryInstant(GameObject obj)
    {
        DictionaryPool.Inst.Instantiate(obj, obj.transform.position, Quaternion.identity, DictionaryPool.Inst.transform);
        ReadyManager.Inst.countObject++;
    }
}
