using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private float minRotateSpeed, maxRotateSpeed;
    private float currentRotateSpeed;

    [SerializeField] private float minRotateTime, maxRotateTime;
    private float rotateTime;
    private float currentRotateTime;



    private void Awake()
    {
        currentRotateTime = 0f;
        currentRotateSpeed = minRotateSpeed + (maxRotateSpeed - minRotateSpeed) * 0.1f * Random.Range(0, 11);
        rotateTime = minRotateTime + (maxRotateTime - minRotateTime) * 0.1f * Random.Range(0, 11);
        currentRotateSpeed *= Random.Range(0, 2) == 0 ? 1f : -1f;
    }
    private void Update()
    {
        currentRotateTime += Time.deltaTime;

        if(currentRotateTime>rotateTime)
        {
            currentRotateTime = 0f;
            currentRotateSpeed = minRotateSpeed + (maxRotateSpeed - minRotateSpeed) * 0.1f * Random.Range(0, 11);
            rotateTime = minRotateTime + (maxRotateTime - minRotateTime) * 0.1f * Random.Range(0, 11);
            currentRotateSpeed *= Random.Range(0, 2) == 0 ? 1f : -1f;

        }
    }
    private void FixedUpdate()
    {
        transform.Rotate(0, 0, currentRotateSpeed * Time.fixedDeltaTime);
    }
}
