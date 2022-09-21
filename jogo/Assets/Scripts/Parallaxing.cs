using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallaxing : MonoBehaviour
{

    // lista para os fundos serem paralelizados 
    public Transform[] background;
    // proporção de movimenttos que a camera fara no fundo
    private float[] parrallaxingxScales;
    // verifica a "suavidade" da paralelização. Certifica-se se está acima de 0 
    public float smoothing = 1f;
    // referencia as traformações que ocorreram na camera main
    private Transform cam;
    // refencia a posição da camera no frame anterior
    private Vector3 previousCampos;
    // será chamado antes do Start(), objetivo é melhorar a performace 
    void Awake()
    {
        // configando a camera 
        cam = Camera.main.transform;
    }
    // usado na inicialização
    void Start()
    {
        //o frame(quadro) anterior se torna o frame(quadro) atual 
        previousCampos = cam.position;
        // atribuido com base no atributo parrallaxingxScales
        parrallaxingxScales = new float[background.Length];
        for (int i = 0; i < background.Length; i++)
        {
            parrallaxingxScales[i] = background[i].position.z * -1;
        }
    }
    void Update()
    {
        // for utilizado para todo backgroud
        for (int i = 0; i < background.Length; i++)
        {
            // paralelismo e o oposto do movimento da camera, pois o frame(quadro) anterior  em mutiplicado pelas escalas 
            float parallax = (previousCampos.x - cam.position.x) * parrallaxingxScales[i];
            // definindo o target de posição x, que é a posição atual mais a parallax
            float backgroundTargetPoax = background[i].position.x + parallax;
            // cria um target de posição, que é a posição atual do background com a posição do target x  
            Vector3 backgroundTargetPoa = new Vector3(backgroundTargetPoax, background[i].position.y, background[i].position.z);
            // trasição entre a posição atual e a posição do target usado usando lerp
            background[i].position = Vector3.Lerp(background[i].position, backgroundTargetPoa, smoothing * Time.deltaTime);
        }
        // definindo previousCampos para posição da camera após terminar o quadro(frame)
        previousCampos = cam.position;
    }
}
