using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise__3
{
    class Node
    {
        /*creates Nodes for the circular nexted list*/
        public int rollNumber;
        public string name;
        public Node next;
    }

    class CircularList
    {
        Node LAST;
        public CircularList()
        {
            LAST = null;
        }
        public bool Search(int rollNo, ref Node previous, ref Node current)
        /*Searches for the specified node*/
        {
            for (previous = current = LAST.next; current != LAST; previous =
                current, current = current.next)
            {
                if (rollNo == current.rollNumber)
                    return (true); /*returns true if the node is found*/
            }
            if (rollNo == LAST.rollNumber)/*If the node is present at the end*/
                return true;
            else
                return (false);/*returns false if the node is not found*/
        }
        public bool listEmpty()
        {
            if (LAST == null)
                return true;
            else
                return false;
        }
        public void traverse()/*Traverses all the nodes of the list*/
        {
            if (listEmpty())
                Console.WriteLine("\nList is empty");
            else
            {
                Console.WriteLine("\nRecords in the list are:\n");
                Node currentNode;
                currentNode = LAST.next;
                while (currentNode != LAST)
                {
                    Console.Write(currentNode.rollNumber + "     " + currentNode.name + "\n");
                    currentNode = currentNode.next;
                }
                Console.Write(LAST.rollNumber + "    " + LAST.name + "\n");
            }
        }
        public void firstNode()
        {
            if (listEmpty())
                Console.WriteLine("\nList is empty");
            else
                Console.WriteLine("\nThe first record in the list is:\n\n " + LAST.next.rollNumber + "   " + LAST.next.name);
        }
        class program
        {
            static void Main(string[] args)
            {
                CircularList obj = new CircularList();
                while (true)
                {
                    try
                    {
                        Console.WriteLine("\nMenu");
                        Console.WriteLine("1. View all the records in the list");
                        Console.WriteLine("2. Search for a record in the list");
                        Console.WriteLine("3. Display the first record int the list");
                        Console.WriteLine("4. Add a record to the list");
                        Console.WriteLine("5. Delete a record from the list");
                        Console.WriteLine("6. Exit");
                        Console.Write("\nEnter your choice (1-6): ");
                        char ch = Convert.ToChar(Console.ReadLine());
                        switch (ch)
                        {
                            case '1':
                                {
                                    obj.traverse();
                                }
                                break;
                            case '2':
                                {
                                    if (obj.listEmpty() == true)
                                    {
                                        Console.WriteLine("\nList is empty");
                                        break;
                                    }
                                    Node prev, curr;
                                    prev = curr = null;
                                    Console.Write("\nEnter the roll number of the student whose record is to be searched: ");
                                    int num = Convert.ToInt32(Console.ReadLine());
                                    if (obj.Search(num, ref prev, ref curr) == false)
                                        Console.WriteLine("\nRecord not found");
                                    else
                                    {
                                        Console.WriteLine("\nRecord found");
                                        Console.WriteLine("\nRoll number: " + curr.rollNumber);
                                        Console.WriteLine("\nName: " + curr.name);
                                    }
                                }
                                break;
                            case '3':
                                {
                                    obj.firstNode;
                                }
                                break;
                            case '4':
                                {
                                    obj.addNote();
                                }
                                break;
                            case '5':
                                {
                                    if (obj.listEmpty())
                                    {
                                        Console.WriteLine("\nList is empty");
                                        break;
                                    }
                                    Console.WriteLine("Enter the roll number of" + " The student whose record is to be deleted: ");
                                    int rollNo = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine();
                                    if (obj.delNode(rollNo) == false)
                                        Console.WriteLine("\n Record not found.");
                                    else
                                        Console.WriteLine("\n Record with roll number " + +rollNo + " Deleted");
                                }
                                break;
                            case '6':
                                return;
                            default:
                                {
                                    Console.WriteLine("Invalid option");
                                    break;
                                }

                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.ToString());
                    }
                }
            }
        }
    }
}
