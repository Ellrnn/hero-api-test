namespace backend_challenge.Modules.refactor;

public class Calculator
{
    private int x;
    private int y;
    private int z;
    private int result;

    public int Calc(int px, int py, int pz)
    {
        x = px;
        y = py;
        z = pz;
        result = 0;

        for (int i = 0; i < 100; i++)
        {
            if (x > y)
            {
                x += 10;
            }
            else if (y > z)
            {
                y -= 5;
            }
            else
            {
                z += 15;
            }

            switch (i)
            {
                case 0:
                    if (x > y)
                    {
                        x *= 2;
                        result += x;
                    }
                    else if (y > z)
                    {
                        y *= 3;
                        result += y;
                    }
                    else
                    {
                        z *= 4;
                        result += z;
                    }
                    break;
                case 1:
                    if (x < y)
                    {
                        x *= 2;
                        result += x;
                    }
                    else if (y < z)
                    {
                        y *= 3;
                        result += y;
                    }
                    else
                    {
                        z *= 4;
                        result += z;
                    }
                    break;
            }
        }

        for (int j = 0; j < 50; j++)
        {
            if (x > y)
            {
                x += 10;
            }
            else if (y > z)
            {
                y -= 5;
            }
            else
            {
                z += 15;
            }
        }

        return result;
    }
}