using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMPlay : MonoBehaviour
{
    public void PlayButton()
    {
        SoundManager.instance.PlayBGM();
    }
}
