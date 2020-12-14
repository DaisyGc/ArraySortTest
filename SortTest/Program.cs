using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortTest
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 15, 0, 10, 50, 55, 35, 15, 20 }; //待排序数组
            ShowArray(arr);
            BubbleSort(arr);
            //SelectSort(arr);
            //InsertSort(arr);
            //QuickSort(arr,0,arr.Length-1);
            //Shellsort(arr);
           
            Console.ReadKey();
        }
        #region 打印数组
        public static void ShowArray(int[] arr)
        {
            Console.Write("原数组为：\n");
            foreach (int i in arr)
            {
                Console.Write(i + " ");
            }
        }
        #endregion
        #region 使用冒泡排序
        public static void BubbleSort(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length - 1 - i; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int newItem = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = newItem;
                    }
                }

            }
            Console.WriteLine("\n使用冒泡排序：");
            //打印数组
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
        }
        #endregion
        #region 使用选择排序
        //选择排序与冒泡排序比较的次数是一样的
        //选择排序的交换次数要比冒泡排序的交换次数少

        public static void SelectSort(int[] arr)
        {
            Console.WriteLine("\n使用选择排序:");

            int temp = 0;
            for (int i = 0; i < arr.Length - 1; i++)
            {

                int minVal = arr[i]; //假设 i 下标就是最小的数
                int minIndex = i;  //记录我认为最小的数的下标

                for (int j = i + 1; j < arr.Length; j++)   //这里只是找出这一趟最小的数值并记录下它的下标
                {
                    //说明我们认为的最小值，不是最小
                    if (minVal > arr[j])    //这里大于号是升序(大于是找出最小值) 小于是降序(小于是找出最大值)
                    {
                        minVal = arr[j];  //更新这趟最小(或最大)的值 (上面要拿这个数来跟后面的数继续做比较)
                        minIndex = j;    //记下它的下标
                    }
                }
                //最后把最小的数与第一的位置交换
                temp = arr[i];    //把第一个原先认为是最小值的数,临时保存起来
                arr[i] = arr[minIndex];   //把最终我们找到的最小值赋给这一趟的比较的第一个位置
                arr[minIndex] = temp;  //把原先保存好临时数值放回这个数组的空地方，  保证数组的完整性
            }
            //控制台输出
            foreach (int item in arr)
            {
                Console.Write(item + " ");
            }
        }
        #endregion
        #region 使用插入排序
        public static void InsertSort(int[] list)
        {
            Console.WriteLine("\n使用插入排序:");
            for (int i = 1; i < list.Length; i++)
            {
                int T = list[i];
                int j = i - 1;
                while (j >= 0 && list[j] > T)
                {
                    list[j + 1] = list[j];
                    j--;
                }
                list[j + 1] = T;
                //Console.Write("\n"+list[j+1]);
            }
            
            foreach(int indexNum in list)
            {
                Console.Write(indexNum+" ");
            }
        }
        #endregion
        #region 使用快速排序
        public static void QuickSort(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int i = left;
                int j = right;
                int middle = arr[(left + right) / 2];
                while (true)
                {
                    while (i < right && arr[i] < middle) { i++; };
                    while (j > 0 && arr[j] > middle) { j--; };
                    if (i == j) break;
                    int temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                    if (arr[i] == arr[j]) j--;
                }
                //QuickSort(arr, left, i);
                //QuickSort(arr, i + 1, right);
            }
            Console.Write("\n使用快速排序:\n");
            foreach (int i in arr)
            {
                Console.Write(i+" ");
            }
        }
        #endregion
        #region 使用希尔排序
        public static void Shellsort(int[] a)
        {
            int d = a.Length / 2;
            while (d >= 1)
            {
                for (int i = 0; i < d; i++)
                {
                    for (int j = i + d; j < a.Length; j += d)
                    {
                        int temp = a[j];//存储和其比较的上一个a[x];
                        int loc = j;
                        while (loc - d >= i && temp < a[loc - d])//&&j-d>=i
                        {
                            a[loc] = a[loc - d];
                            loc = loc - d;
                        }
                        a[loc] = temp;
                    }
                }
                //一次插入排序结束，缩小d的值
                d = d / 2;
            }
            Console.WriteLine("\n使用希尔排序：");
            foreach(int i in a)
            {
                Console.Write(i + " ");
            }
        }
        #endregion
    }


}



