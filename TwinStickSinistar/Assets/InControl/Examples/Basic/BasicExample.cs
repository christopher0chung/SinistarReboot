namespace BasicExample
{
	using InControl;
	using UnityEngine;
    using UnityEngine.SceneManagement;

	public class BasicExample : MonoBehaviour
	{

        public IControllable myIO;
        private bool notTheFirstTime;

        void Awake()
        {
            DontDestroyOnLoad(this.gameObject);
            SceneManager.sceneLoaded += MyOnLoadLevel;
            GetComponent<MeshRenderer>().enabled = false;
        }

        void Update()
		{
            if (myIO == null)
            {
                // Use last device which provided input.
                var inputDevice = InputManager.ActiveDevice;

                // Rotate target object with left stick.
                transform.Rotate(Vector3.down, 500.0f * Time.deltaTime * inputDevice.LeftStickX, Space.World);
                transform.Rotate(Vector3.right, 500.0f * Time.deltaTime * inputDevice.LeftStickY, Space.World);

                // Get two colors based on two action buttons.
                var color1 = inputDevice.Action1.IsPressed ? Color.red : Color.white;
                var color2 = inputDevice.Action2.IsPressed ? Color.green : Color.white;

                // Blend the two colors together to color the object.
                GetComponent<Renderer>().material.color = Color.Lerp(color1, color2, 0.5f);

                if (inputDevice.CommandIsPressed)
                {
                    SceneManager.LoadScene(1);
                }
            }
            else
            {
                // Use last device which provided input.
                var inputDevice = InputManager.ActiveDevice;

                myIO.LeftStick(inputDevice.LeftStickY, inputDevice.LeftStickX);
                myIO.RightStick(inputDevice.RightStickY, inputDevice.RightStickX);

                //Debug.Log(inputDevice.LeftStickY * 1.0f + " " + inputDevice.LeftStickX * 1.0f);
            }
		}

        void MyOnLoadLevel (Scene scene, LoadSceneMode mode)
        {
            if (scene.buildIndex != 0)
            {
                if (GameObject.Find("Ship") != null)
                {
                    myIO = GameObject.Find("Ship").GetComponent<IControllable>();
                }
            }
            if (scene.buildIndex == 0 && notTheFirstTime)
            {
                Destroy(this.gameObject);
            }
            notTheFirstTime = true;
        }
    }
}

