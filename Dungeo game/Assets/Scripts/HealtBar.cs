using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealtBar : MonoBehaviour
{
    [SerializeField]
    private Sprite HealthFull;
    [SerializeField]
    private Sprite HealthEmpty;
    [SerializeField]
    private GameObject Health;
    private List<GameObject> Hearts = new List<GameObject>();
    public void UpdateHealtPlayer(int CurrentLife, int MaxLife)
    {
        RestartList();
        for (int i = 0; i < MaxLife; i++)
        {
            if(CurrentLife <= i)
            {
                Health.GetComponent<Image>().sprite =  HealthEmpty;
            }
            else
            {
                Health.GetComponent<Image>().sprite =  HealthFull;
            }
            var posX = transform.position.x + (i * 55);
            var go = Instantiate(Health, new Vector3(posX, transform.position.y, 0), Quaternion.identity, this.transform);
            Hearts.Add(go);
        }
    }
    private void RestartList()
    {
        foreach (var Heart in Hearts)
        {
            Destroy(Heart);
        }
    }
}
