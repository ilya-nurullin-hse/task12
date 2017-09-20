using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task12
{
    class Program
    {
        static Tracker heapTracker = new Tracker();
        static Tracker bucketSortTracker = new Tracker();

        static void Main(string[] args)
        {
            int[] unsorted = {3, 2, 6, 1, 4, 7, 5};
            var a1 = Heapsort(unsorted);
            var b1 = BucketSort(unsorted);
            heapTracker.Clear();
            bucketSortTracker.Clear();

            int[] sorted = { 1, 2, 3, 4, 5, 6, 7 };
            var a2 = Heapsort(sorted);
            var b2 = BucketSort(sorted);
            heapTracker.Clear();
            bucketSortTracker.Clear();

            int[] reverseSorted = { 7, 6, 5, 4, 3, 2, 1 };
            var a3 = Heapsort(reverseSorted);
            var b3 = BucketSort(reverseSorted);
        }
    
        static int[] Heapsort(int[] a)
        {
            int N = a.Length;
            int[] aCopy = new int[N];
            a.CopyTo(aCopy, 0);

            //Создаём из массива сортирующее дерево
            //Максимальный элемент окажется в корне.
            for (int k = N / 2; k > 0; k--) downheap(aCopy, k, N);

            //Избавляемся от максимума
            //и перестраиваем сортирующее дерево
            do
            {

                //Меняем максимум с последним элементом
                int T = aCopy[0];
                aCopy[0] = aCopy[N - 1];
                aCopy[N - 1] = T;

                // перестравиваем сортирующее дерево
                // для неотсортированной части массива			
                N = N - 1;
                downheap(aCopy, 1, N);

            } while (N > 1); // До последнего элемента

            return aCopy;

        }

        static void downheap(int[] a, int k, int N)
        {
            //В корне поддерева
            //запоминаем родителя
            int T = a[k - 1];

            //Смотрим потомков в пределах ветки
            while (k <= N / 2)
            {
                int j = k + k; //Левый потомок

                //Если есть правый потомок, 
                //то сравниваем его с левым
                //и из них выбираем наибольший
                if (j < N && heapTracker.Compare(a[j - 1] < a[j])) j++;

                //Если родитель больше (или равен) наибольшего потомка
                if (heapTracker.Compare(T >= a[j - 1]))
                {
                    // то значит всё в порядке в этой ветке		
                    break;
                }
                else
                {
                    //Если родитель меньше наибольшего потомка

                    // то потомок становится на место родителя
                    a[k - 1] = a[j - 1];
                    k = j;
                }
            }

            //Родитель в итоге меняется местами с наибольшим из потомков
            //(или остаётся на своём месте, если все потомки меньше его)
            a[k - 1] = T;
        }

        static int[] BucketSort(int[] a)
        {
            var array = new int[a.Length];

            a.CopyTo(array, 0);

            if (array == null || array.Length < 2)
                return array;

            int maxValue = array[0];
            int minValue = array[0];

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > maxValue)
                    maxValue = array[i];

                if (array[i] < minValue)
                    minValue = array[i];
            }

            List<int>[] bucket = new List<int>[maxValue - minValue + 1];

            for (int i = 0; i < bucket.Length; i++)
            {
                bucket[i] = new List<int>();
            }

            for (int i = 0; i < array.Length; i++)
            {
                bucket[array[i] - minValue].Add(array[i]);
            }

            int position = 0;
            for (int i = 0; i < bucket.Length; i++)
            {
                if (bucket[i].Count > 0)
                {
                    for (int j = 0; j < bucket[i].Count; j++)
                    {
                        bucketSortTracker.Move();
                        array[position] = bucket[i][j];
                        position++;
                    }
                }
            }

            return array;
        }
    }
}