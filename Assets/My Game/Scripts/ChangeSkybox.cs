using UnityEngine;

public class ChangeSkybox : MonoBehaviour
{
    public Material daySkybox;
    public Material nightSkybox;

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (RenderSettings.skybox == daySkybox)
            {
                RenderSettings.skybox = nightSkybox;
            }
            UpdateGI();
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (RenderSettings.skybox == nightSkybox)
            {
                RenderSettings.skybox = daySkybox;

            }
            UpdateGI();
        }
    }

    void UpdateGI()
    {
        DynamicGI.UpdateEnvironment();
    }
}
