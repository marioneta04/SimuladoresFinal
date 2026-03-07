using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MostrarResultado : MonoBehaviour
{
    public TMP_Text textoCalidad;
    public TMP_Text textoResultado;

    public Image imagenPan;

    public Sprite panPerfecto;
    public Sprite panBueno;
    public Sprite panAceptable;
    public Sprite panMalo;

    void Start()
    {
        float calidad = PlayerPrefs.GetFloat("CalidadPan");
        string resultado = PlayerPrefs.GetString("ResultadoPan");

        textoCalidad.text = "Calidad: " + calidad.ToString("F0");
        textoResultado.text = resultado;

        
        if (calidad > 90)
            imagenPan.sprite = panPerfecto;
        else if (calidad > 70)
            imagenPan.sprite = panBueno;
        else if (calidad > 50)
            imagenPan.sprite = panAceptable;
        else
            imagenPan.sprite = panMalo;
    }
}
