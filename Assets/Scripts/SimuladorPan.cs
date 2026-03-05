using TMPro;
using UnityEngine;
using UnityEngine.UI;



public class SimuladorPan : MonoBehaviour
{
    public RecetaPan[] recetas;
    public RecetaPan recetaActual;

    [Header("UI")]
    public TMP_Dropdown dropdownReceta;

    public TMP_InputField inputHarina;
    public TMP_InputField inputAgua;

    public Slider sliderAmasado;
    public Slider sliderFermentacion;
    public Slider sliderTemperatura;
    public Slider sliderCoccion;

    public TMP_Text textoCalidad;
    public TMP_Text textoResultado;

    public TextMeshProUGUI hidratacionIdealText;
    public TextMeshProUGUI amasadoIdealText;
    public TextMeshProUGUI fermentacionIdealText;
    public TextMeshProUGUI temperaturaIdealText;
    public TextMeshProUGUI coccionIdealText;

    void Start()
    {
        recetaActual = recetas[0];
        MostrarRecetaIdeal(recetaActual);
    }

    public void CambiarReceta(int index)
    {
        Debug.Log("Cambio de receta: " + index);
        recetaActual = recetas[index];

        MostrarRecetaIdeal(recetaActual);
    }

    void MostrarRecetaIdeal(RecetaPan receta)
    {
        hidratacionIdealText.text = "Hidratación: " + receta.hidratacionIdeal + "%";
        amasadoIdealText.text = "Amasado: " + receta.amasadoIdeal + " min";
        fermentacionIdealText.text = "Fermentación: " + receta.fermentacionIdeal + " min";
        temperaturaIdealText.text = "Temperatura: " + receta.temperaturaIdeal + " °C";
        coccionIdealText.text = "Cocción: " + receta.coccionIdeal + " min";
    }
    public void CalcularResultado()
    {
        float harina = float.Parse(inputHarina.text);
        float agua = float.Parse(inputAgua.text);

        float amasado = sliderAmasado.value;
        float fermentacion = sliderFermentacion.value;
        float temperatura = sliderTemperatura.value;
        float coccion = sliderCoccion.value;

        float hidratacion = (agua / harina) * 100f;

        float errorHidratacion = Mathf.Abs(hidratacion - recetaActual.hidratacionIdeal);
        float errorAmasado = Mathf.Abs(amasado - recetaActual.amasadoIdeal);
        float errorFermentacion = Mathf.Abs(fermentacion - recetaActual.fermentacionIdeal);
        float errorTemperatura = Mathf.Abs(temperatura - recetaActual.temperaturaIdeal);
        float errorCoccion = Mathf.Abs(coccion - recetaActual.coccionIdeal);

        float errorTotal = errorHidratacion + errorAmasado + errorFermentacion + errorTemperatura + errorCoccion;

        float calidad = Mathf.Clamp(100 - errorTotal, 0, 100);

        string resultado;

        if (calidad > 90)
            resultado = "Pan perfecto";
        else if (calidad > 70)
            resultado = "Buen pan";
        else if (calidad > 50)
            resultado = "Pan aceptable";
        else if (calidad > 30)
            resultado = "Pan mediocre";
        else
            resultado = "Pan fallido";

        textoCalidad.text = "Calidad: " + calidad.ToString("F0");
        textoResultado.text = resultado;
    }
}
