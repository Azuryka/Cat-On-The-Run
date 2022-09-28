using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    [SerializeField]
    private AudioManager audioManager;

    [SerializeField]
    private GameObject volume;

    [SerializeField]
    private Slider sliderVolume;

    [SerializeField]
    private bool visible;

    [SerializeField]
    private Sprite[] images;

    [SerializeField]
    private Image renderer;

    private void Awake()
    {
        visible = false;

        if (PlayerPrefs.HasKey("volume"))
        {
            sliderVolume.value = PlayerPrefs.GetFloat("volume");
        }

        ChangeSprite();
    }

    public void VolumeButton()
    {
        if (!visible)
        {
            volume.SetActive(true);
            visible = true;
        }
        else
        {
            volume.SetActive(false);
            visible = false;
        }

        audioManager.SEClick();

        PlayerPrefs.SetFloat("volume", sliderVolume.normalizedValue);
        audioManager.ChangeVolume();
    }

    private void Update()
    {
        ChangeSprite();

        /*if (sliderVolume.normalizedValue >= 0.8)
        {
            renderer.sprite = images[0];
        }
        else if (sliderVolume.normalizedValue < 0.8 && sliderVolume.normalizedValue > 0.3)
        {
            renderer.sprite = images[1];
        }
        else if (sliderVolume.normalizedValue <= 0.3 && sliderVolume.normalizedValue > 0.1)
        {
            renderer.sprite = images[2];
        }
        else if (sliderVolume.normalizedValue < 0.1)
        {
            renderer.sprite = images[3];
        }*/
    }

    private void ChangeSprite()
    {
        if (PlayerPrefs.HasKey("volume"))
        {
            if (PlayerPrefs.GetFloat("volume") >= 0.8)
            {
                renderer.sprite = images[0];
            }
            else if (PlayerPrefs.GetFloat("volume") < 0.8 && PlayerPrefs.GetFloat("volume") > 0.3)
            {
                renderer.sprite = images[1];
            }
            else if (PlayerPrefs.GetFloat("volume") <= 0.3 && PlayerPrefs.GetFloat("volume") > 0.1)
            {
                renderer.sprite = images[2];
            }
            else if (PlayerPrefs.GetFloat("volume") < 0.1)
            {
                renderer.sprite = images[3];
            }
        }
    }
}
