using System;
using UnityEngine;

public class OpenURL : MonoBehaviour
{
    public void Open(string uri)
    {
#if WINDOWS_UWP
            UnityEngine.WSA.Application.InvokeOnUIThread(async () =>
            {
                bool result = await global::Windows.System.Launcher.LaunchUriAsync(new System.Uri(uri));
                if (!result)
                {
                    Debug.LogError("Launching URI failed to launch.");
                }
            }, false);
#else
        Application.OpenURL(uri);
#endif
    }
}
