using System;

namespace Linked_List
{
    class Program
    {
        static void Main(string[] args)
        {
            //Node n1; // this is just a pointer
            //Node n2 = new Node(17);// this is an instance
            Node someNode = new Node(7);
            Node anotherNode = new Node(11);
            anotherNode.Next = someNode;
            singlyLinkedList myList = new singlyLinkedList();
            myList.Print();
            myList.AddFirst(1);
            myList.AddFirst(2);
            myList.AddFirst(3);
            myList.Print();

            myList.Append(4);
            myList.Append(10);
            myList.Append(30);
            myList.Print();
        }
        class Node
        {
            public int Value { get; set; }
            public Node Next { get; set; }
            //custructor
            public Node(int someVal)
            {
                Value = someVal;
            }
         
        }

        class singlyLinkedList
        {
            //data
            Node head;
            // behavior
            //AddFirst
            public void AddFirst(int someValue)
            {
                //create a new node
                Node newNode = new Node(someValue);

                //link in the new node
                newNode.Next = head;

                // move the head to the left
                head = newNode;

            }
            //AddLast /Append
            public void Append(int someValue)
            {
                AddLast(someValue);
            }
            public void AddLast(int someValue)
            {
                if (head == null)
                {
                    AddFirst(someValue);
                    return;
                }
                //creaet new node
                Node newNode = new Node(someValue);

                //traverse the list... to get to the last not-null in the list
                Node finger = head;
                while (finger.Next != null)
                {
                    finger = finger.Next;
                }

                //when you get here finger points to the last not null node
                //link in the new node
                finger.Next = newNode;

            }
            //DeleteFirst
            public void DeleteFirst()
            {   
                if(head==null)//edge case
                {
                    throw new Exception("you can't delet first from an empty list");
                }
                else
                {
                    head = head.Next;
                }
                
            }
            //DeleteLast
            public void DeleteLast()
            {
                if(head==null)//first edge case
                {
                    throw new Exception("you can;t delete last of an emplty list!");
                }
                else if(head.Next==null)//edge case when we have only one node
                {
                    head = null;
                }
               Node finger = head;
                while (finger.Next.Next!=null)
                {
                    finger = finger.Next;// move right
                }
                // now finger points to the node before the last in the list
                //link out the last node
                finger.Next = null;
            }
            // Insert
            public void Insert(int someValue, int index)
            {
                //if list is null and position ==0
                if((index==0)&& (head == null))
                {
                    AddFirst(someValue);
                }
                //create a new node
                Node newNode = new Node(someValue);
                //need to find the position index -1
                Node finger = head;
                for (int pos = 0; pos < index-1; pos++)
                {
                    if (finger == null)
                    {
                        Console.WriteLine("Error");
                        return;
                    }
                    finger = finger.Next;
                }
                //link in 
                newNode.Next = finger.Next;
                finger.Next = newNode;
            }

            //Delete
            public void Delete(int index) 
            {
                if (index < 0)
                {
                    return;
                }
                if (index == 0)
                {
                    DeleteFirst();
                }
                else
                {
                    Node finger = head;
                    for (int pos = 0; pos < index - 1; pos++)
                    {
                        if (finger == null)
                        {
                            Console.WriteLine("Error");
                            return;
                        }
                        finger = finger.Next;
                    }
                    //link
                    finger.Next = finger.Next.Next;
                }
            }
            //Print /traverse
            public void Print()
            {
                if(head== null)//if the list is empty
                    Console.WriteLine("The List is empty");
                else
                {
                    Node finger=head;
                    while (finger != null)
                    {
                        Console.Write(finger.Value+ " ");
                        finger = finger.Next;//move finger to the right
                    }
                }
            }

            //ctor
            public singlyLinkedList()
            {
                //head =null;

            }
        }
    }
}
