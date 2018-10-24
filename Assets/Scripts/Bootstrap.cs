using UnityEngine;

public class Bootstrap : MonoBehaviour
{

    private static Bootstrap BootstrapScript = null;

    public static Bootstrap Script
    {
        get
        {
            return BootstrapScript;
        }
        private set
        {
            BootstrapScript = value;
        }
    }

    void Awake()
    {
        Screen.sleepTimeout = SleepTimeout.SystemSetting;
        Script = BaseConfiguration.Script.orthographicCamera.GetComponent<Bootstrap>();

		Navigation.initializeNavigationStack (1);
		Debug.Log("BOOT");

		var page = MyGameObject.Instantiate<MainMenu> ();
		page.create ();
		Navigation.initializeStack (0, page);
		Navigation.navigateToStack (0);
    }
}