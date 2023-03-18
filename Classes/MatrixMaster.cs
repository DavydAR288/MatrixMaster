using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class MatrixMaster
    {
        public static int[,] Create(int rows, int columns, int min, int max)    // генерация случайной матрицы по заданным параметрам
        {
            int[,] matrix = new int[rows, columns];
            Random rnd = new Random();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = rnd.Next(min, max + 1);
                }
            }
        return matrix;
        }
        public static void Print(int[,] matrix) // вывод матрицы в консоль
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j],6} "); // форматирование строки
                }
                Console.WriteLine();
            }
        }

        // Произведение матрицы А порядка PxN и матрицы В порядка NxQ - это такая матрица С порядка PxQ
        // каждый элемент которой равен сумме произведений элементов i-ой строки матрицы А на соответствующие элементы j-ого столбца матрицы В
        public static int[,] Multiplication(int[,] matrixA, int[,] matrixB) // умножение матриц
        {
            int rowsC = matrixA.GetLength(0),
                columnsC = matrixB.GetLength(1);
            int[,] matrixC = new int[rowsC, columnsC];
            for (int i = 0; i < rowsC; i++)
            {
                for (int j = 0; j < columnsC; j++)
                {
                    for (int k = 0; k < matrixA.GetLength(1); k++)
                    {
                        matrixC[i, j] += matrixA[i, k] * matrixB[k, j];
                    }
                }
            }
            return matrixC;
        }
        public static int[,] CreateSpiral(int rows, int columns)    // спиральное заполнение массива
        {
            int[,] matrix = new int[rows, columns];
            int startElement = 1, // стартовый элемент
                count = 0, // счетчик прохода 4-х напрвлений "колец"
                quantitySteps = 0; // счетчик проверки количества элементов массива для запуска циклов направлений
            for (quantitySteps = 0; quantitySteps <= rows * columns; quantitySteps++)
            {
                for (int j = 0 + count; j < columns - 1 - count; j++) // заполнение вправо
                {
                    matrix[0 + count, j] = startElement++;
                    quantitySteps++;
                }
                for (int i = 0; i < rows - 1 - count * 2; i++) // заполнение вниз 
                {
                    matrix[i + count, columns - 1 - count] = startElement++;
                    quantitySteps++;
                }
                for (int j = columns - 1 - count; j > 0 + count; j--) // заполнение влево
                {
                    matrix[rows - 1 - count, j] = startElement++;
                    quantitySteps++;
                }
                for (int i = rows - 1 - count; i > 0 + count; i--) // заполнение вверх
                {
                    matrix[i, 0 + count] = startElement++;
                    quantitySteps++;
                }
                count++;
            }
            return matrix;
        }
        public static int[,,] Create3dDictionary(int rows, int columns, int depth, int min, int max)  // создает 3-х мерный массив из случайных не повторяющихся чисел с заполнением словаря
        {
            int[,,] matrix = new int[rows, columns, depth];
            int sizeDictionary = rows * columns * depth;
            int[] dictionary = new int[sizeDictionary];
            int indexDictionary = 0;
            int randomElement = 0;
            Random rnd = new Random();
            for (int k = 0; k < matrix.GetLength(2); k++)
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        do
                        {
                            randomElement = rnd.Next(min, max + 1);
                        } while (dictionary.Contains(randomElement));
                        matrix[i, j, k] = randomElement;
                        dictionary[indexDictionary] = randomElement;
                        indexDictionary++;
                    }
                }
            }
            Array.Sort(dictionary);                                 // Используется для отображения словаря, оценки его корректности
            Console.Write("Словарь используемых элементов: ");      // 
            for (int n = 0; n < sizeDictionary; n++)                // НЕ ЯВЛЯЕТСЯ ОБЯЗАТЕЛЬНОЙ ЧАСТЬЮ ВЫПОЛНЕНИЯ ПРОГРАММЫ И ЕЁ ЗАДАЧИ ДЛЯ ДЗ
            {                                                       // 
                Console.Write($"{dictionary[n]} ");                 // 
            }                                                       // 
            Console.WriteLine();                                    // 
            return matrix;
        }
        public static void Print3d(int[,,] matrix)  // вывод 3-х мерной матрицы в консоль
        {
            for (int k = 0; k < matrix.GetLength(2); k++)
            {
                Console.WriteLine($"Слой глубины массива: {k}");
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        Console.Write($"{matrix[i, j, k],6} ({i}, {j}, {k})"); // форматирование строки
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}