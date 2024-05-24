//Создайте структкруру Rectangle представляющую прямоугольник со свойствами длины и ширины
//напишите метод для вычисления его прощади и периметра. Напиште метод для сравнения (и вывода результатов сравнения)
// двух прямоугольников : какой из них длиннее, какой шире , какой больше по площади.
// В основной программе введите 3 прямоугольника и попарно сравните их. Результат выведите в виде таблицы

struct Rectangle
{
    public double Length { get; set; }
    public double Width { get; set; }

    public double Area()
    {
        return Length * Width;
    }

    public double Perimeter()
    {
        return 2 * (Length + Width);
    }

    public bool IsLongerThan(Rectangle other)
    {
        return Length > other.Length;
    }

    public bool IsWiderThan(Rectangle other)
    {
        return Width > other.Width;
    }

    public bool HasLargerAreaThan(Rectangle other)
    {
        return Area() > other.Area();
    }
}

class Program
{
    static void Main()
    {
        Rectangle[] rectangles = new Rectangle[3];

        for (int i = 0; i < rectangles.Length; i++)
        {
            Console.Write($"Введите длину прямоугольника {i + 1}: ");
            rectangles[i].Length = double.Parse(Console.ReadLine());

            Console.Write($"Введите ширину прямоугольника {i + 1}: ");
            rectangles[i].Width = double.Parse(Console.ReadLine());
        }

        Console.WriteLine();
        Console.WriteLine("Сравнение прямоугольников:");
        Console.WriteLine("");
        Console.WriteLine("{0,-10} | {1,-25} | {2,-25}", "Прямоугольник", "Сравнение", "Результат");
        Console.WriteLine("");

        for (int i = 0; i < rectangles.Length; i++)
        {
            for (int j = i + 1; j < rectangles.Length; j++)
            {
                Rectangle rectangle1 = rectangles[i];
                Rectangle rectangle2 = rectangles[j];

                Console.WriteLine("{0,-10} | {1,-25} | {2,-25}", $"R{i + 1} vs R{j + 1}", "R1 длиннее, чем R2?", rectangle1.IsLongerThan(rectangle2) ? "Да" : "Нет");
                Console.WriteLine("{0,-10} | {1,-25} | {2,-25}", $"R{i + 1} vs R{j + 1}", "R1 шире, чем R2??", rectangle1.IsWiderThan(rectangle2) ? "Да" : "Нет");
                Console.WriteLine("{0,-10} | {1,-25} | {2,-25}", $"R{i + 1} vs R{j + 1}", "Имеет ли R1 большую площадь, чем R2?", rectangle1.HasLargerAreaThan(rectangle2) ? "Да" : "Нет");
            }

            Console.WriteLine();
        }
    }
}

















