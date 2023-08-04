using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    public static SettingsManager Instance;

    public MouseSettings Mouse_settings { get; private set; }

    public class MouseSettings
    {
        [SerializeField] private float _min_sens = 5;
        [SerializeField] private float _sens_x = 45;
        [SerializeField] private float _sens_y = 45;

        public float Sens_x 
        {
            get
            {
                return _sens_x;
            }
            set
            {
                if (value >= _min_sens)
                    _sens_x = value;
            }
        }
        public float Sens_y
        {
            get
            {
                return _sens_y;
            }
            set
            {
                if (value >= _min_sens)
                    _sens_y = value;
            }
        }
    }


    public void Awake()
    {
        LoadSettings();

        if (!Instance)
            Instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    private void LoadSettings()
    {
        Mouse_settings = new();
    }

}
