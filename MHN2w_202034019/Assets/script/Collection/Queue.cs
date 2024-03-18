using UnityEngine;

public class Queue : MonoBehaviour
{
    public GameObject bulletPerfab;
    public Transform spawnPoint;
    public Transform target;

    public int count;

    public Queue<GameObject> bulletQueue;

    void Start()
    {
        bulletQueue = new Queue<GameObject>(10);

        count = 0;

        for (int i = 0; i < 10; i++)
        {
            GameObject bullet = Instantiate(bulletPerfab, spawnPoint.position, Quaternion.identity);
            bulletQueue.Enqueue(bullet);
            bullet.SetActive(false);

            count++;
        }
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            GameObject bullet = bulletQueue.Dequeue();

            count--; 

            Debug.Log("Bullet Count: " + count);

            bullet.transform.position = spawnPoint.position;
            bullet.SetActive(true);

            bullet.GetComponent<Rigidbody>().velocity = (target.position - spawnPoint.position).normalized * 10f;

            if (count == 0)
            {
                for (int i = 0; i < 10; i++)
                {
                    GameObject newBullet = Instantiate(bulletPerfab, spawnPoint.position, Quaternion.identity);
                    bulletQueue.Enqueue(newBullet);
                    newBullet.SetActive(false);
                    count++;
                }
            }
        }
    }
}

public class Node<T>
{
    public T data;
    public Node<T> next;

    public Node(T data)
    {
        this.data = data;
        this.next = null;
    }
}

public class Queue<T>
{
    private Node<T> head;

    public Queue(int maxSize)
    {
        head = null;
    }

    public void Enqueue(T data)
    {
        Node<T> newNode = new Node<T>(data);
        Node<T> Empty = head;

        if(head == null)
        {
            head = newNode;
        }
        else
        {
            while(Empty.next != null)
            { 
                Empty = Empty.next;
            }
            if (Empty.next == null)
            {
                Empty.next = newNode;
            }
        }

    }

    public T Dequeue()
    {
        T data = head.data;
        head = head.next;

        return data;
    }
}