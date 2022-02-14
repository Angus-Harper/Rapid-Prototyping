using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class JMC : MonoBehaviour
{
    /// <summary>
    /// Shuffles a list using Unity's Random
    /// </summary>
    /// <typepram name="T">The data type</typepram>
    /// <param name="_list">The list to shuffle</param>
    /// <returns></returns>
    public static List<T> ShuffleList<T>(List<T> _list)
    {
        for (int i = 0; i < _list.Count; i++)
        {
            T temp = _list[i];
            int randomIndex = UnityEngine.Random.Range(i, _list.Count);
            _list[i] = _list[randomIndex];
            _list[randomIndex] = temp;
        }
        return _list;
    }
    /// <summary>
    /// Gets a random colour
    /// </summary>
    /// <returns></returns>

    public Color GetRandomColour()
    {
        return new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
    }

    /// <summary>
    /// fades in a canvas group
    /// </summary>
    /// <returns></returns>
    public void FadeInCanvas(CanvasGroup _cvg)
    {
        _cvg.DOFade(1, 1);
        _cvg.interactable = true;
        _cvg.blocksRaycasts = true;
    }
    /// <summary>
    /// fades out a canvas group
    /// </summary>
    /// <returns></returns>
    public void FadeOutCanvas(CanvasGroup _cvg)
    {
        _cvg.DOFade(0, 1);
        _cvg.interactable = false;
        _cvg.blocksRaycasts = false;
    }
}
