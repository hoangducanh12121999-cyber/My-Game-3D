using UnityEngine;
using UnityEngine.AI;

public class AISimple : MonoBehaviour
{
    public Transform target; // Mục tiêu mà AI sẽ theo dõi
    private NavMeshAgent agent; // Thành phần NavMeshAgent để di chuyển AI

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>(); // Lấy thành phần NavMeshAgent từ GameObject
        target = GameObject.FindGameObjectWithTag("Player").transform; // Tìm mục tiêu có tag "Player" và lấy Transform của nó
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToTarget = Vector3.Distance(transform.position, target.position); // Tính khoảng cách từ AI đến mục tiêu
        if (distanceToTarget < 5f) // Nếu khoảng cách nhỏ hơn 5 đơn vị
        {
            if (!agent.hasPath || agent.destination != target.position) // Nếu AI chưa có đường đi hoặc đường đi hiện tại không phải là vị trí mục tiêu
            {
                agent.SetDestination(target.position); // Đặt đích đến là vị trí của mục tiêu
            }
        }

    }
}
