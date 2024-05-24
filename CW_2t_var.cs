

//Создайте абстрактный класс Embrasure, который представляет собой проем с названием, шириной, длиной и толщиной , и методом для расчета стоимости установки 
// От него сделайте наследников: Window и Door. У окон добавьте поле рассчета слоев. У двери добавьте логические войства: узор и стекло.
//Преопределите метод рассчета цены в зависимости от различных свойств дверей и окон. В основной программе сделать массивы окон и дверей 
//из 5 экземпляров каждый. отсортировать по возрастанию цены и вывести в виде двух таблиц (название, ширина, длина , толщина и цена).
//Соединить в один массив проемов, отсортировать по возрастанию цены и вывести информацию обо всех окнах и дверях
abstract class Embrasure
{
    public string Name { get; set; }
    public double Width { get; set; }
    public double Length { get; set; }
    public double Thickness { get; set; }

    public abstract double CalculatePrice();
}

class Window : Embrasure
{
    public int NumberOfLayers { get; set; }

    public override double CalculatePrice()
    {
        return 100 * Width * Length + 50 * NumberOfLayers;
    }
}

class Door : Embrasure
{
    public bool HasPattern { get; set; }
    public bool HasGlass { get; set; }

    public override double CalculatePrice()
    {
        double price = 150 * Width * Length;
        if (HasPattern)
        {
            price += 50;
        }
        if (HasGlass)
        {
            price += 100;
        }
        return price;
    }
}

class Program
{
    static void Main()
    {
        Embrasure[] windows = new Embrasure[5];
        Embrasure[] doors = new Embrasure[5];

        // Заполнение массивов окнами и дверями с различными свойствами
        for (int i = 0; i < 5; i++)
        {
            windows[i] = new Window
            {
                Name = $"Window {i + 1}",
                Width = 2 + i,
                Length = 3 + i,
                Thickness = 0.5 + i,
                NumberOfLayers = 1 + i
            };

            doors[i] = new Door
            {
                Name = $"Door {i + 1}",
                Width = 1 + i,
                Length = 2 + i,
                Thickness = 0.75 + i,
                HasPattern = i % 2 == 0,
                HasGlass = i % 3 == 0
            };
        }
        // Сортировк окон и дверей
        SortBubble(windows);
        SortBubble(doors);

        // Вывод отсортированных массивов окон и дверей
        Console.WriteLine("Sorted Windows:");
        Console.WriteLine(" ");
        Console.WriteLine("{0,-15} | {1,-10} | {2,-10} | {3,-10} | {4,-10}", "Name", "Width", "Length", "Thickness", "Price");
        Console.WriteLine(" ");
        foreach (var window in windows)
        {
            Console.WriteLine("{0,-15} | {1,-10} | {2,-10} | {3,-10} | {4,-10}", window.Name, window.Width, window.Length, window.Thickness, window.CalculatePrice());
        }
        Console.WriteLine();

        Console.WriteLine("Sorted Doors:");
        Console.WriteLine(" ");
        Console.WriteLine("{0,-15} | {1,-10} | {2,-10} | {3,-10} | {4,-10} | {5,-10} | {6,-10}", "Name", "Width", "Length", "Thickness", "Has Pattern?", "Has Glass?", "Price");
        Console.WriteLine(" ");
        foreach (var door in doors)
        {
            Console.WriteLine("{0,-15} | {1,-10} | {2,-10} | {3,-10} | {4,-10} | {5,-10} | {6,-10}", door.Name, door.Width, door.Length, door.Thickness, door.HasPattern, door.HasGlass, door.CalculatePrice());
        }
        Console.WriteLine();

        // Соединение массивов окон и дверей в один массив проемов
        Embrasure[] embrasures = new Embrasure[windows.Length + doors.Length];
        Array.Copy(windows, embrasures, windows.Length);
        Array.Copy(doors, 0, embrasures, windows.Length, doors.Length);

        // Сортировка массива проемов пузырьковым методом
        SortBubble(embrasures);

        // Вывод информации обо всех окнах и дверях
        Console.WriteLine("Sorted Embrasures:");
        Console.WriteLine(" ");
        Console.WriteLine("{0,-15} | {1,-10} | {2,-10} | {3,-10} | {4,-10}", "Name", "Width", "Length", "Thickness", "Price");
        Console.WriteLine(" ");
        foreach (var embrasure in embrasures)
        {
            Console.WriteLine("{0,-15} | {1,-10} | {2,-10} | {3,-10} | {4,-10}", embrasure.Name, embrasure.Width, embrasure.Length, embrasure.Thickness, embrasure.CalculatePrice());
        }
    }

    static void SortBubble(Embrasure[] array)
    {
        bool swapped;

        do
        {
            swapped = false;
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i].CalculatePrice() > array[i + 1].CalculatePrice())
                {
                    Embrasure temp = array[i];
                    array[i] = array[i + 1];
                    array[i + 1] = temp;
                    swapped = true;
                }
            }
        } while (swapped);
    }
}
