using System;
using System.Collections;
using JetBrains.Annotations;
using UnityEngine;

namespace Rich.Base.Runtime.Utility
{
  //public delegate void OnCompleted();

  public class ScreenCapture : MonoBehaviour
  {
    //private OnCompleted _onScreenCaptured;

    [UsedImplicitly]
    private void LateUpdate()
    {
      if (Input.GetKeyDown("f8"))
      {
        //StartCoroutine(CaptureScreen());
      }
    }

    // public void StartCapture(OnCompleted onCaptured)
    // {
    //   _onScreenCaptured = onCaptured;
    //   StartCoroutine(CaptureScreen());
    // }

    public IEnumerator CaptureScreen()
    {
      yield return new WaitForSeconds(.1f);

      yield return new WaitForEndOfFrame();

      var filename = GetFilename(Screen.width, Screen.height);

      UnityEngine.ScreenCapture.CaptureScreenshot(filename);

      Debug.Log(filename);

    // if (_onScreenCaptured != null)
    //     _onScreenCaptured();
    }

    private string GetFilename(int width, int height)
    {
      return Application.dataPath + "/../Screenshots/" + string.Format("screen_{0}x{1}_{2}_{3}.png",
               width, height,
               DateTime.Now.ToString("ss.fff"), "TR");
    }
  }
}