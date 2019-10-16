using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeQuiz
{
    public class Node<T>
    {
        public T data { get; set; }
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }
        public Node(T data)
        {
            this.data = data;
        }
        public Node(T data, Node<T> left, Node<T> right)
        {
            this.data = data;
            this.Left = left;
            this.Right = right;
        }
    }
    class Program
    {

        static void Main(string[] args)
        {
            Node<int> root = new Node<int>(11);
            addToTree(root, 3);
            addToTree(root, 0);
            addToTree(root, 4);
            addToTree(root, 4);


            Console.WriteLine(AddUpTree(root));
            Console.WriteLine(IsCalculationTree(root));
            Console.WriteLine(IsBalanced(root));
            printFromQueue(root);
            Console.ReadLine();
        }
        static Node<int> addToTree(Node<int> root, int newData)
        {
            if (root == null)
            {
                Node<int> newNode = new Node<int>(newData);
                return newNode;
            }
            else if (newData < root.data)
            {
                root.Left = addToTree(root.Left, newData);
            }
            else
            {
                root.Right = addToTree(root.Right, newData);
            }
            return root;
        }
        public static int AddUpTree(Node<int> root)
        {
            if (root != null)
            {
                return root.data + AddUpTree(root.Left) + AddUpTree(root.Right);
            }
            else
            {
                return 0;
            }
        }

        public static bool IsCalculationTree(Node<int> root)
        {
            if (root == null)
            {
                return false;
            }
            int sumOfLeft = AddUpTree(root.Left);
            int sumOfRight = AddUpTree(root.Right);
            if (root.data == sumOfLeft + sumOfRight)
            {
                return true;
            }
            return false;
        }
        static bool IsBalanced(Node<int> root)
        {
            if (root == null)
                return true;
            int differenceInHieght = Math.Abs(GetHeight(root.Right) - GetHeight(root.Left));
            if (differenceInHieght > 1)
            {
                return false;
            }
            return IsBalanced(root.Left) && IsBalanced(root.Right);
        }
        static int GetHeight(Node<int> root)
        {
            if (root == null)
            {
                return 0;
            }
            else
            {
                return 1 + Math.Max(GetHeight(root.Left), GetHeight(root.Right));
            }
        }

        static void printFromQueue(Node<int> root)
        {
            if(root == null)
            {
                return;
            }

            var queue = new Queue<Node<int>>();
            queue.Enqueue(root);
            Console.WriteLine(root.data);
            while(queue.Count != 0)
            {
                var queueCount = queue.Count();
                var lastNode = new Node<int>(-1);

                for(int x = 0; x <= queueCount; x++)
                {
                    var temp = queue.Dequeue();

                    if(x == queueCount - 1)
                    {
                        lastNode = temp;
                    }
                    if(temp.Left != null)
                    {
                        Console.WriteLine(temp.Left.data);
                        queue.Enqueue(temp.Left);
                    }
                    if(temp.Right != null)
                    {
                        Console.WriteLine(temp.Right.data);
                        queue.Enqueue(temp.Right);
                    }
                }
            }
        }
    }
}
