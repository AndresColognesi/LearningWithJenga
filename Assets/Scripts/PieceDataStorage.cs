using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PieceDataStorage : MonoBehaviour
{
    #region Attributes

    // Data container for current Jenga Piece:
    private JengaBlockData pieceData;

    // Canvas:
    [SerializeField] private GameObject pieceCanvas;
    // Canvas text array:
    [SerializeField] private TextMeshProUGUI[] textArray;

    #endregion


    #region Custom Methods

    public void SetPieceData(JengaBlockData data)
    {
        /***
         * Set pieceData attribute of this object based
         * on the received JengaBlockData.
         ***/

        pieceData = data;
    }

    public void SetDisplayInfo()
    {
        /***
         * Set the desired information in the piece canvas texts.
         ***/

        textArray[0].text = pieceData.grade + ": " + pieceData.domain;
        textArray[1].text = pieceData.cluster;
        textArray[2].text = pieceData.standardid + ": " + pieceData.standarddescription;

    }

    public int GetMasteryValue()
    {
        /***
         * Return the mastery level stored on this current piece
         * object.
         ***/

        return pieceData.mastery;
    }

    public void DisableCanvas()
    {
        /***
         * Disables the piece canvas component.
         ***/
        pieceCanvas.SetActive(false);
    }

    #endregion


    #region Built-in Methods

    void OnMouseDown()
    {
        // Enable piece canvas with desired info:
        pieceCanvas.SetActive(true);
    }

    #endregion
}
