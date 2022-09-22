using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atirar : MonoBehaviour {
    [SerializeField] private Transform _posiçãoTiro;
    [SerializeField] private GameObject _tiroPrefab;

    private void Atira(){
        Instantiate(_tiroPrefab, _posiçãoTiro.position, _posiçãoTiro.rotation);
    }
    void Update() {
        if(Input.GetButtonDown("Fire2")){
            Atira();
        }
    }
}
