using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderValorUI : MonoBehaviour
{
    public Slider slider;
    public TMP_Text textoValor;
    public string sufijo = "";

    void Start()
    {
        ActualizarTexto(slider.value);
        slider.onValueChanged.AddListener(ActualizarTexto);
    }

    void ActualizarTexto(float valor)
    {
        textoValor.text = valor.ToString("F0") + sufijo;
    }
}
