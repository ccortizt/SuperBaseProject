using UnityEngine;

public class ObjectToggle : MonoBehaviour
{
    [SerializeField] GameObject toToogle;
    [SerializeField] Color toogleIndicatorColor;
    [SerializeField] GameObject toogleIndicator;

    private void Start()
    {
        toogleIndicator.GetComponent<Renderer>().material.color = toogleIndicatorColor;

        if (toToogle.GetComponent<Renderer>() != null)
        {
            toToogle.GetComponent<Renderer>().material.color = toogleIndicatorColor;
        }

    }

    private void OnDisable()
    {
        //print(toToogle.activeSelf);
        toToogle.SetActive(!toToogle.activeSelf);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameObject.SetActive(false);
        }
    }


}
