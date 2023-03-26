using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManagerTests
{
    [Test]
    public void UpdatePuttsText_UpdatesTextCorrectly()
    {
        // Arrange
        var uiManagerObject = new GameObject();
        var uiManager = uiManagerObject.AddComponent<UIManager>();
        var puttsTextObject = new GameObject();
        var puttsText = puttsTextObject.AddComponent<TMP_Text>();
        puttsTextObject.transform.SetParent(uiManagerObject.transform);
        uiManager.NumberOfPuttsDisplay = puttsText;

        int putts = 5;
        string expectedText = $"Putts: {putts}";

        // Act
        uiManager.UpdatePuttsText(putts);

        // Assert
        Assert.AreEqual(expectedText, puttsText.text);
    }
}