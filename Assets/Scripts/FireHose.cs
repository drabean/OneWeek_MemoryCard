using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireHose : MonoBehaviour
{
    public GameObject Sprite_Water;


    public void shootWater()
    {
        Vector2 rotVec = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(-rotVec.x, rotVec.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        StartCoroutine(CO_ShootWater());
    }

    IEnumerator CO_ShootWater()
    {
        SoundManager.Inst.PlaySFX("WaterEffectSound");
        Sprite_Water.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        Sprite_Water.SetActive(false);
    }
}
