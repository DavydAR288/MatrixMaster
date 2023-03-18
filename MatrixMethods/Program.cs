using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes;

int Rows = ConsoleMaster.Promt("Введите высоту матрицы: ");
int Columns = ConsoleMaster.Promt("Введите ширину матрицы: ");

int[,] matrixOne = MatrixMaster.CreateSpiral(Rows, Columns);
Console.WriteLine("Матрица, заполненная спирально:");
MatrixMaster.Print(matrixOne);