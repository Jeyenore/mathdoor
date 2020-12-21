using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace weall
{
    public class DIEIF : MonoBehaviour
    {
        public Transform player;
        public GameObject dieinstructions;
        [HideInInspector] public bool dieplayer = false;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                Debug.Log("Die Player");
                StartCoroutine(Die());

            }

        }
        IEnumerator Die()
        {
            dieplayer = true;
            dieinstructions.SetActive(true);
            Time.timeScale = 0;
            yield return new WaitForSecondsRealtime(5);
            dieplayer = false;
            dieinstructions.SetActive(false);
            Time.timeScale = 1;

        }

    }
}
