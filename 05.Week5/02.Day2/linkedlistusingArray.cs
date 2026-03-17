using System;

public class Node
{
    public int id;
    public string name;
    public Node next;

    public Node(int id, string name)
    {
        this.id = id;
        this.name = name;
        this.next = null;
    }
}

class EmployeeList
{
    Node head = null;

    // Insert at Beginning
    public void InsertAtBeginning(int id, string name)
    {
        Node newNode = new Node(id, name);
        newNode.next = head;
        head = newNode;
    }

    // Insert at End
    public void InsertAtEnd(int id, string name)
    {
        Node newNode = new Node(id, name);

        if (head == null)
        {
            head = newNode;
            return;
        }

        Node temp = head;
        while (temp.next != null)
        {
            temp = temp.next;
        }

        temp.next = newNode;
    }

    // Delete by ID
    public void Delete(int id)
    {
        if (head == null)
        {
            Console.WriteLine("List is empty.");
            return;
        }

        // If head node is to be deleted
        if (head.id == id)
        {
            head = head.next;
            return;
        }

        Node temp = head;
        while (temp.next != null && temp.next.id != id)
        {
            temp = temp.next;
        }

        if (temp.next == null)
        {
            Console.WriteLine("Employee not found.");
        }
        else
        {
            temp.next = temp.next.next;
        }
    }

    // Traverse and Display
    public void Display()
    {
        if (head == null)
        {
            Console.WriteLine("List is empty.");
            return;
        }

        Node temp = head;
        while (temp != null)
        {
            Console.WriteLine(temp.id + " - " + temp.name);
            temp = temp.next;
        }
    }
}

class Program
{
    static void Main()
    {
        EmployeeList list = new EmployeeList();

        // Sample Input
        list.InsertAtEnd(101, "John");
        list.InsertAtEnd(102, "Sara");
        list.InsertAtEnd(103, "Mike");
        Console.WriteLine("Employee List before Deletion:");
        list.Display();

        // Delete employee with ID 102
        list.Delete(102);

        // Output
        Console.WriteLine("Employee List After Deletion:");
        list.Display();
    }
}