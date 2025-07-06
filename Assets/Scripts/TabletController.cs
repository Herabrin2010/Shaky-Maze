using TMPro;
using TMPro.Examples;
using UnityEngine;

public class TabletController : MonoBehaviour
{
    [Header("Input Field")]
    [SerializeField] private TMP_InputField _mouseRotationSpeed;
    [SerializeField] private TMP_InputField _keyboardRotationSpeed;

    [Header("Mouse Rotation Settings")]
    public float mouseRotationSpeed = 5f;
    public bool invertMouseX = false;
    public bool invertMouseY = false;

    [Header("Keyboard Rotation Settings")]
    public float keyboardRotationSpeed = 100f;

    [Header("Rotation Limits")]
    public float minXAngle = -35f;
    public float maxXAngle = 35f;
    public float minZAngle = -35f;
    public float maxZAngle = 35f;

    [Header ("Ссылки")]
    private KeyRebinder keyRebinder;

    private Vector3 currentRotation;

    private void Awake()
    {
        keyRebinder = FindAnyObjectByType<KeyRebinder>();    
    }

    void Start()
    {
        // Инициализируем текущий угол поворота
        currentRotation = transform.eulerAngles;
    }

    void Update()
    {
        //поменять местами
        _mouseRotationSpeed.text = mouseRotationSpeed.ToString();
        _keyboardRotationSpeed.text = keyboardRotationSpeed.ToString();

        // Вращение с помощью мыши (при зажатой левой кнопке)
        if (Input.GetMouseButton(0))
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseRotationSpeed;
            float mouseY = Input.GetAxis("Mouse Y") * mouseRotationSpeed;

            if (invertMouseX) mouseX *= +1;
            if (invertMouseY) mouseY *= +1;

            // Для вращения мышью мы меняем X и Z оси (чтобы было более интуитивно)
            currentRotation.z -= mouseX;
            currentRotation.x += mouseY;
        }

        // Вращение с помощью клавиатуры
        float keyboardX = 0f;
        float keyboardZ = 0f;

        if (keyRebinder.GetAction("Rotation Up Key") || keyRebinder.GetAction("Rotation Up Arrow")) keyboardX += 1f;
        if (keyRebinder.GetAction("Rotation Down Key") || keyRebinder.GetAction("Rotation Down Arrow")) keyboardX -= 1f;
        if (keyRebinder.GetAction("Rotation Right Key") || keyRebinder.GetAction("Rotation Right Arrow")) keyboardZ -= 1f;
        if (keyRebinder.GetAction("Rotation Left Key") || keyRebinder.GetAction("Rotation Left Arrow")) keyboardZ += 1f;

        currentRotation.x += keyboardX * keyboardRotationSpeed * Time.deltaTime;
        currentRotation.z += keyboardZ * keyboardRotationSpeed * Time.deltaTime;

        // Ограничение углов поворота
        currentRotation.x = Mathf.Clamp(currentRotation.x, minXAngle, maxXAngle);

        currentRotation.z = Mathf.Clamp(currentRotation.z, minZAngle, maxZAngle);


        // Применяем поворот
        transform.rotation = Quaternion.Euler(currentRotation);
    }
}