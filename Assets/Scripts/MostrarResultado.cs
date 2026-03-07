using TMPro;
using UnityEngine;

public class MostrarResultado : MonoBehaviour
{
    public TMP_Text textoCalidad;
    public TMP_Text textoResultado;

    void Start()
    {
        float calidad = PlayerPrefs.GetFloat("CalidadPan");
        string resultado = PlayerPrefs.GetString("ResultadoPan");

        textoCalidad.text = "Calidad: " + calidad.ToString("F0");
        textoResultado.text = resultado;
    }
}
