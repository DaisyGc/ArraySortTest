# 1. 冒泡排序

## 基本思想

排序过程像气泡一样上升，假设单向冒泡排序由小到大：对给定的n个数据，从第一个数据开始，依次对相邻的两个记录进行比较，若当前的记录大于后面的记录，交换位置，进行一遍比较和换位后，N个记录的最大记录在最后一位，然后对前(n-1)个数据进行比较，重复该过程，直到记录剩下一个为止

![](https://img04.sogoucdn.com/app/a/200698/310_163_20200904170618-1676843515.png)

```c#
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
```

设置flag，若所有数据已经排序，无需再次进行比较

# 2.选择排序

## 基本思想

未排序序列中找到最小（大）元素，存放到排序序列的起始位置，然后，再从剩余未排序元素中继续寻找最小（大）元素，然后放到已排序序列的末尾。以此类推，直到所有元素均排序完毕。

```c#
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
```



# 3.插入排序

## 基本思想

在要排序的一组数中，假定前n-1个数已经排好序，现在将第n个数插到前面的有序数列中，使得这n个数也是排好顺序的。如此反复循环，直到全部排好顺序。

* 从第一个元素开始，该元素可以认为已经被排序；

* 取出下一个元素，在已经排序的元素序列中从后向前扫描；

* 如果该元素（已排序）大于新元素，将该元素移到下一位置；

* 重复步骤3，直到找到已排序的元素小于或者等于新元素的位置；

* 将新元素插入到该位置后；

* 重复步骤2~5。

```c#
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
```

# 4.快速排序

## 基本思想

通过一趟排序将待排记录分隔成独立的两部分，其中一部分记录的关键字均比另一部分的关键字小，则可分别对这两部分记录继续进行排序，以达到整个序列有序。

快速排序使用分治法来把一个串（list）分为两个子串（sub-lists）。具体算法描述如下：

从数列中挑出一个元素，称为 “基准”（pivot）；

重新排序数列，所有元素比基准值小的摆放在基准前面，所有元素比基准值大的摆在基准的后面（相同的数可以到任一边）。在这个分区退出之后，该基准就处于数列的中间位置。这个称为分区（partition）操作；

递归地（recursive）把小于基准值元素的子数列和大于基准值元素的子数列排序。

```c#
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
```

# 5.希尔排序

# 基本思想

希尔排序也是一种插入排序，它是简单插入排序经过改进之后的一个更高效的版本，也称为缩小增量排序，同时该算法是冲破O(n*n）的第一批算法之一。它与插入排序的不同之处在于，它会优先比较距离较远的元素。

选择一个增量序列t1，t2，…，tk，其中ti>tj，tk=1；

按增量序列个数k，对序列进行k 趟排序；

每趟排序，根据对应的增量ti，将待排序列分割成若干长度为m 的子序列，分别对各子表进行直接插入排序。仅增量因子为1 时，整个序列作为一个表来处理，表长度即为整个序列的长度。

```c#
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
```





