using UnityEngine;
using UnityEngine.UI;

public class Thirst : MonoBehaviour
{
    [SerializeField] float currentThirst;
    [SerializeField] float thirstLimit;
    [SerializeField] float width, height;
    [SerializeField] RectTransform thirstBar;

    void Start()
    {
        currentThirst = 0f;
    }

    void Update()
    {
        currentThirst += Time.deltaTime;
        if (currentThirst >= thirstLimit)
        {
            Debug.Log("You died, lmao");
        }

    }
}
