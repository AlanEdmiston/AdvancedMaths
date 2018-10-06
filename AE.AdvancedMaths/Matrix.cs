using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AE.AdvancedMaths
{
    public class Matrix
    {
        int width, height;
        double[,] elements;
        public Matrix(int width, int height)
        {
            this.width = width;
            this.height = height;
            this.elements = new double[width, height];
        }
        public Matrix(double[,] elements)
        {
            this.elements = elements;
            this.width = elements.GetLength(0);
            this.height = elements.GetLength(1);
        }
        public static Matrix operator +(Matrix m1, Matrix m2)
        {
            double[,] elements = new double[m1.width, m1.height];
            for(int i = 0; i < m1.width; i++)
            {
                for(int j = 0; j < m1.width; j++)
                {
                    elements[i, j] = m1.elements[i, j] + m2.elements[i, j];
                }
            }
            return new Matrix(elements);
        }
        public static Matrix operator -(Matrix m1, Matrix m2)
        {
            double[,] elements = new double[m1.width, m1.height];
            for (int i = 0; i < m1.elements.GetLength(0); i++)
            {
                for (int j = 0; j < m1.width; j++)
                {
                    elements[i, j] = m1.elements[i, j] - m2.elements[i, j];
                }
            }
            return new Matrix(elements);
        }
        public static Matrix operator -(Matrix m)
        {
            double[,] elements = new double[m.width, m.height];
            for (int i = 0; i < m.elements.GetLength(0); i++)
            {
                for (int j = 0; j < m.width; j++)
                {
                    elements[i, j] = -m.elements[i, j];
                }
            }
            return new Matrix(elements);
        }
        public static Matrix operator *(Matrix m1, Matrix m2)
        {
            if(m1.width != m2.width)
            {
                throw new InvalidOperationException("matrix dimensions do not match for multiplication");
            }
            double[,] elements = new double[m1.height, m1.height];
            //horizontal
            for (int i = 0; i < m1.width; i++)
            {
                //verticle
                for (int j = 0; j < m1.width; j++)
                {
                    elements[i, j] = 0;
                    for (int k = 0; k < m1.width; k++)
                    {
                        elements[i, j] += m1.elements[k, i] * m2.elements[j, k];
                    }
                }
            }
            return new Matrix(elements);
        }
        public static Vector operator *(Matrix m, Vector v)
        {
            if (m.width != v.size)
            {
                throw new InvalidOperationException("matrix width does not match vector height");
            }
            double[] elements = new double[v.size];
            //horizontal
            for (int i = 0; i < m.width; i++)
            {
                elements[i] = 0;
                //verticle
                for (int j = 0; j < m.width; j++)
                {
                    elements[i] += m.elements[i, j] * v.elements[j];
                }
            }
            return new Vector(elements);
        }
        public static Matrix operator *(Matrix m, double scalar)
        {
            double[,] elements = new double[m.width, m.height];
            for (int i = 0; i < m.elements.GetLength(0); i++)
            {
                for (int j = 0; j < m.width; j++)
                {
                    elements[i, j] = m.elements[i, j] * scalar;
                }
            }
            return new Matrix(elements);
        }
        public static Matrix operator /(Matrix m, double scalar)
        {
            double[,] elements = new double[m.width, m.height];
            for (int i = 0; i < m.elements.GetLength(0); i++)
            {
                for (int j = 0; j < m.width; j++)
                {
                    elements[i, j] = m.elements[i, j] / scalar;
                }
            }
            return new Matrix(elements);
        }

        public static Matrix Transpose(Matrix m)
        {
            double[,] elements = new double[m.height, m.width];
            for(int i = 0; i < m.width; i++)
            {
                for(int j = 0; j < m.height; j++)
                {
                    elements[j, i] = m.elements[i, j];
                }
            }
            return new Matrix(elements);
        }

        //square matrix operations

        public static Matrix Identity(int dimensions)
        {
            double[,] elements = new double[dimensions, dimensions];
            for(int i = 0; i < dimensions; i++)
            {
                elements[i, i] = 1;
            }
            return new Matrix(elements);
        }

        public static double Det(Matrix tempMet)
        {
            if(tempMet.width != tempMet.height)
            {
                throw new InvalidOperationException("matrix is not square");
            }
            double det = 0;
            if (tempMet.width < 2)
            {
                return det;
            }
            if (tempMet.width == 2)
            {
                det = tempMet.elements[0, 0] * tempMet.elements[1, 1] - tempMet.elements[1, 0] * tempMet.elements[0, 1];
            }
            else
            {
                for (int i = 0; i < tempMet.width; i++)
                {
                    Matrix recursMet = new Matrix(tempMet.width - 1, tempMet.width - 1);
                    int passRow = 0;
                    for (int j = 0; j < recursMet.width; j++)
                    {
                        for (int k = 0; k < recursMet.width; k++)
                        {
                            if (k == i)
                            {
                                passRow = 1;
                            }
                            recursMet.elements[j, k] = tempMet.elements[j + 1, k + passRow];
                        }
                    }
                    det += tempMet.elements[0, i] * Det(recursMet) * Math.Pow(-1, i * tempMet.width + i);
                }
            }
            return det;
        }

        public static Matrix Inverse(Matrix tempMat)
        {
            if(tempMat.width != tempMat.height)
            {
                throw new InvalidOperationException("matrix is not square");
            }
            Matrix inverseMat = new Matrix(tempMat.width, tempMat.width);
            double det = Det(inverseMat);
            for (int i = 0; i < tempMat.width; i++)
            {
                for (int j = 0; j < tempMat.width; j++)
                {
                    int passRow = 0;
                    int passColumn = 0;
                    Matrix smallMat = new Matrix(inverseMat.width - 1, inverseMat.width - 1);
                    for (int k = 0; k < smallMat.width; k++)
                    {
                        for (int l = 0; l < smallMat.width; l++)
                        {
                            if (k == i)
                            {
                                passRow = 1;
                            }
                            if (l == j)
                            {
                                passColumn = 1;
                            }
                            smallMat.elements[k, l] = tempMat.elements[k + passRow, l + passColumn];
                        }
                    }
                    inverseMat.elements[i, j] = Det(smallMat) * det;
                }
            }
            return tempMat;
        }

        public static Matrix operator /(Matrix m1, Matrix m2)
        {
            if (m1.width != m1.height || m2.width != m2.height || m1.width != m2.height)
            {
                throw new InvalidOperationException("matrix is not square or dimensions are not compatible");
            }

            Matrix invMat = Matrix.Inverse(m2);
            return m1 * invMat;
        }
        public static Matrix operator ^(Matrix m1, int power)
        {
            if (power == 0)
            {
                return Matrix.Identity(m1.width);
            }
            if(power == 1)
            {
                return m1;
            }
            if(power > 1)
            {
                Matrix m1Squared = m1 * m1;
                double mult = m1Squared.elements[0, 0] / m1.elements[0, 0];
                return m1 * Math.Pow(mult, power - 1);
            }
            return (Matrix.Inverse(m1) ^ -power);
        }
        private static double[] DetEigen(Matrix tempMet, Matrix lambdaMatrix)
        {
            //determinant is a polynomial with integer powers
            double[] det;
            if (tempMet.width == 2)
            {
                det = new double[3];
                det[0] = tempMet.elements[0, 0] * tempMet.elements[1, 1] - tempMet.elements[1, 0] * tempMet.elements[0, 1];
                det[1] = lambdaMatrix.elements[0, 0] * tempMet.elements[1, 1] + tempMet.elements[0, 0] * lambdaMatrix.elements[1, 1] - lambdaMatrix.elements[1, 0] * tempMet.elements[0, 1] - tempMet.elements[1, 0] * lambdaMatrix.elements[0, 1];
                det[2] = lambdaMatrix.elements[0, 0] * lambdaMatrix.elements[1, 1] - lambdaMatrix.elements[1, 0] * lambdaMatrix.elements[0, 1];
            }
            else
            {
                det = new double[tempMet.width + 1];
                for (int i = 0; i < tempMet.width; i++)
                {
                    Matrix recursMet = new Matrix(tempMet.width - 1, tempMet.width - 1);
                    Matrix recursLambdaMatrix = new Matrix(tempMet.width - 1, tempMet.width - 1);
                    int passRow = 0;
                    for (int j = 0; j < recursMet.width; j++)
                    {
                        for (int k = 0; k < recursMet.width; k++)
                        {
                            if (k == i)
                            {
                                passRow = 1;
                            }
                            recursMet.elements[j, k] = tempMet.elements[j + 1, k + passRow];
                            recursLambdaMatrix.elements[j, k] = recursLambdaMatrix.elements[j + 1, k + passRow];
                        }
                    }
                    double[] recursDet = DetEigen(recursMet, recursLambdaMatrix);
                    for(int j = 0; j < recursDet.Length; j++)
                    {
                        det[j] = tempMet.elements[0, i] * recursDet[j] * Math.Pow(-1, i * tempMet.width + i);
                        det[j + 1] += recursLambdaMatrix.elements[0, i] * recursDet[j] * Math.Pow(-1, i * tempMet.width + i);
                    }
                }
            }
            return det;
        }
        public static Dictionary<double, Vector> EigenDecomposition(Matrix m)
        {
            if(m.width != m.height)
            {
                throw new InvalidOperationException("matrix must b square to possess eigenVectors");
            }
            else
            {
                double[] polynomialExpressions = DetEigen(m, -Matrix.Identity(m.width));
                Func<double, double> polynomial = x =>
                {
                    double y = 0;
                    for(int i = 0; i < polynomialExpressions.Length; i++)
                    {
                        y += polynomialExpressions[i] * Math.Pow(x, i);
                    }
                    return y;
                };
            }
        }
        //cast to complex matrix
        //eigen decomposition
    }
}
