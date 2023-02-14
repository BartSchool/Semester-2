using CircusTrein.Core.Classes;
using CircusTrein.Core.Interfaces;
using System.Text;
Console.OutputEncoding = Encoding.Unicode;
Train train = new();

Greet();
train.AnimalCollection.AddAnimals(AskAnimals());
ShowSelectedAnimals();
CalculateBestDistribution();

void Greet()
{
    Console.WriteLine("Welcome to the animal distribituter");
    Console.WriteLine("Let's get you to fill in the information of all your animals");
}

List<IAnimal> AskAnimals()
{
    List<IAnimal> animals = new();
    int amount = AskAmountOfAnimals();
    for (int i = 1; i < amount+1; i++)
    {
        Console.Clear();
        Console.WriteLine("Now that we know the amount of animals");
        Console.WriteLine("Iam going to ask you the dieët and size of all these animals");
        Console.WriteLine();

        Console.WriteLine("Animal " + i + ":");
        if (AskIfAnimalIsCarnivore())
            animals.Add(new Carnivore(AskAnimalSize()));
        else
            animals.Add(new Herbivore(AskAnimalSize()));
        Console.WriteLine();
    }

    return animals;
}

int AskAmountOfAnimals()
{
    bool sure = false;
    string? answer = "";
    Console.WriteLine("");
    Console.WriteLine("Let's start with getting these animals away shall we.");
    Console.WriteLine("Frist thing is first, How many animals do you want to move?");
    int amountOfAnimals = 0;
    int tries = 0;
    while (!sure)
    {
        bool succes = false;
        while (!succes)
        {
            if (tries != 0)
            {
                Console.WriteLine("Let's try that again...");
                Console.WriteLine("How many animals are you trying to move");
            }
            answer = Console.ReadLine();
            if (answer != null)
                if (int.TryParse(answer, out int result))
                {
                    amountOfAnimals = result;
                    succes = true;
                }
        }

        int wrongAnswers = 0;

        if (wrongAnswers == 0)
        {
            Console.WriteLine();
            Console.WriteLine("Are you sure you are moving " + amountOfAnimals + " animals?");
            Console.WriteLine("Type [n] to change your amount.");
            Console.WriteLine("Type [y] to continue.");
        }
        else
            Console.WriteLine("Please type [n] to change your amount of animals or [y] to continue with " + amountOfAnimals + " animals.");
        answer = Console.ReadLine();

        if (answer != null)
        {
            if (answer == "y")
                sure = true;
            else if (answer == "n")
            {
                succes = false;
                tries++;
            }
            else
                wrongAnswers++;
        }
    }

    return amountOfAnimals;
}

int AskAnimalSize()
{
    int result = 0;
    bool succes = false;
    while (!succes)
    {
        Console.WriteLine();
        Console.WriteLine("What is the size of this animal?");
        Console.WriteLine("[1] small");
        Console.WriteLine("[2] medium");
        Console.WriteLine("[3] big");
        Console.WriteLine();

        string? answer = Console.ReadLine();
        if (answer != null)
            if (int.TryParse(answer, out result))
                succes = true;
        if (!succes)
        {
            Console.WriteLine("lets try that again");
        }
    }

    return result * 2 - 1;
}

bool AskIfAnimalIsCarnivore()
{
    int answerInt = 0;
    bool succes = false;
    while (!succes)
    {
        Console.WriteLine();
        Console.WriteLine("What is the dieët of this animal?");
        Console.WriteLine("[1] carnivore");
        Console.WriteLine("[2] herbivore");
        Console.WriteLine();

        string? answer = Console.ReadLine();
        if (answer != null)
            if (int.TryParse(answer, out answerInt))
                if (answerInt == 1 || answerInt == 2)
                    succes = true;
        if (!succes)
        {
            Console.WriteLine("lets try that again");
            Console.WriteLine();
        }
    }

    if (answerInt == 1)
        return true;
    else
        return false;
}

void ShowSelectedAnimals()
{
    Console.WriteLine("┏━━━━━━━━━━━┳━━━━━━━━━┓");
    Console.WriteLine("┃   Dieët   ┃   Size  ┃");
    Console.WriteLine("┣━━━━━━━━━━━╋━━━━━━━━━┫");
    foreach (Carnivore c in train.AnimalCollection.AnimalList.OfType<Carnivore>())
        WriteCarnivore(c);
    foreach (Herbivore h in train.AnimalCollection.AnimalList.OfType<Herbivore>())
        WriteHerbivore(h);
    Console.WriteLine("┗━━━━━━━━━━━┻━━━━━━━━━┛");
}

void WriteSize(int size)
{
    if (size == 1)
        Console.Write(" Small  ");
    else if (size == 3)
        Console.Write(" Medium ");
    else if (size == 5)
        Console.Write("  Big   ");
}

void WriteCarnivore(Carnivore c)
{
    Console.Write("┃ Carnivore ┃ ");
    WriteSize(c.size);
    Console.WriteLine("┃");
}

void WriteHerbivore(Herbivore h)
{
    Console.Write("┃ Herbivore ┃ ");
    WriteSize(h.size);
    Console.WriteLine("┃");
}

void CalculateBestDistribution()
{
    int answerInt = 0;
    bool succes = false;
    while (!succes)
    {
        Console.WriteLine();
        Console.WriteLine("Do you want to calculate the best distribution?");
        Console.WriteLine("[1] yes");
        Console.WriteLine("[2] no");
        Console.WriteLine();

        string? answer = Console.ReadLine();
        if (answer != null)
            if (int.TryParse(answer, out answerInt))
                if (answerInt == 1 || answerInt == 2)
                    succes = true;
        if (!succes)
        {
            Console.WriteLine("lets try that again");
            Console.WriteLine();
        }
    }

    if (answerInt == 1) 
    { 
        train.DistributeAnimals();
        ShowTrain();
    }
    else
        Console.WriteLine("Oké, please restart the program if want to distribute animals.");
}

void ShowTrain()
{
    Console.Clear();
    Console.WriteLine("Here are all the carts with the right animals in them");
    Console.WriteLine();
    int i = 1;
    foreach (Cart c in train.cartList)
    {
        WriteCart(c, i);
        i++;
    }
}

void WriteCart(Cart cart, int n)
{
    Console.WriteLine("┏━━━━━━━━━━━━━━━━━━━━━┓");
    Console.WriteLine("┃         Cart " + n + "      ┃");
    Console.WriteLine("┣━━━━━━━━━━━┳━━━━━━━━━┫");
    Console.WriteLine("┃   Dieët   ┃   Size  ┃");
    Console.WriteLine("┣━━━━━━━━━━━╋━━━━━━━━━┫");
    foreach (Carnivore c in cart.AnimalList.OfType<Carnivore>())
        WriteCarnivore(c);
    foreach (Herbivore h in cart.AnimalList.OfType<Herbivore>())
        WriteHerbivore(h);
    Console.WriteLine("┗━━━━━━━━━━━┻━━━━━━━━━┛");
}