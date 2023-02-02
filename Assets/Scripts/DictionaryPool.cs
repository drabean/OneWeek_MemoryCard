using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DictionaryPool : Singleton<DictionaryPool>
{
    private Dictionary<string, List<GameObject>> instList = new Dictionary<string, List<GameObject>>();
    //Call instantiate

    /// <summary>
    /// prefab 이라는 Pool에서 가져오고 Pool이 비어있다면 오브젝트를 생성
    /// </summary>
    /// <param name="prefab"></param>
    /// <param name="position"></param>
    /// <param name="rotation"></param>
    /// <param name="parent"></param>
    /// <returns></returns>
    public GameObject Instantiate(GameObject prefab, Vector3 position, Quaternion rotation, Transform parent)
    {
        List<GameObject> list = null;
        GameObject instance = null;

        bool listCheck = instList.TryGetValue(prefab.name, out list);
        if (listCheck == false)
        {
            list = new List<GameObject>();
            instList.Add(prefab.name, list);
        }
        if (list.Count == 0)
        {
            instance = GameObject.Instantiate(prefab, position, rotation, parent);
        }
        else if (list.Count > 0)
        {
            instance = list[0];
            instance.transform.position = position + new Vector3(0, 0.3f, 0);
            instance.transform.rotation = rotation;
            list.RemoveAt(0);
        }
        if (instance != null)
        {
            instance.gameObject.SetActive(true);
            return instance;
        }
        else
        {
            return null;
        }
    }
    /// <summary>
    /// Prefab을 제거하고 해당하는 이름의 Pool에 추가
    /// </summary>
    /// <param name="Prefab"></param>
    public void Destroy(GameObject Prefab)
    {
        List<GameObject> list = null;
        string prefabId = Prefab.name.Replace("(Clone)", "");
        bool listCached = instList.TryGetValue(prefabId, out list);
        if (listCached == false)
        {
            Debug.LogError("Not Found " + Prefab.name);
            return;
        }

        Prefab.SetActive(false);
        list.Add(Prefab);

    }

    public void DestroyMySelp()
    {
        Destroy(this.gameObject);
    }
}
