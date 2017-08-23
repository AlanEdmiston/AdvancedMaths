using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AE.AdvancedMaths
{
    public class SquareMatrices
    {
        int size;
        double[,] matrix;

        void main()
        {
            matrix = new double[size, size];
        }

        public double Det(SquareMatrices tempMet)
        {
            double det = 0;
            if(tempMet.size < 2)
            {
                return det;
            }
            if(tempMet.size == 2)
            {
                det = tempMet.matrix[0, 0] * tempMet.matrix[1, 1] - tempMet.matrix[1, 0] * tempMet.matrix[0, 1];
            }
            else
            {
                for (int i = 0; i < tempMet.size; i++)
                {
                    SquareMatrices recursMet = new SquareMatrices();
                    recursMet.size = tempMet.size - 1;
                    int passRow = 0;
                    for (int j = 0; j < recursMet.size; j++)
                    {
                        for (int k = 0; k < recursMet.size; k++)
                        {
                            if (k == i)
                            {
                                passRow = 1;
                            }
                            recursMet.matrix[j, k] = tempMet.matrix[j + 1, k + passRow];
                        }
                    }
                    det += tempMet.matrix[0, i] * Det(recursMet) * Math.Pow(-1, i * size + i);
                }
            }
            return det;
        }

        public SquareMatrices Inverse(SquareMatrices tempMat)
        {
            SquareMatrices inverseMat = new SquareMatrices();
            inverseMat.size = tempMat.size;
            double det = Det(inverseMat);
            for(int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    int passRow = 0;
                    int passColumn = 0;
                    SquareMatrices smallMat = new SquareMatrices();
                    smallMat.size = inverseMat.size - 1;
                    for(int k = 0; k < smallMat.size; k++)
                    {
                        for(int l = 0; l < smallMat.size; l++)
                        {
                            if(k == i)
                            {
                                passRow = 1;
                            }
                            if (l == j)
                            {
                                passColumn = 1;
                            }
                            smallMat.matrix[k, l] = matrix[k + passRow, l + passColumn];
                        }
                    }
                    inverseMat.matrix[i, j] = Det(smallMat) * det;
                }
            }
            return tempMat;
        }
        //elementary row operations
        //reduced row echalon form
        //Eigen decomposition



        //vector matrix multiplication
        //tosting override
    }
}
