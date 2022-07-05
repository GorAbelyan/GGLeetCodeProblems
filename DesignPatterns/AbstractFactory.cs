using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    public class AbstractFactory
    {
        public AbstractFactory()
        {
            Run();
        }
        public void Run()
        {
            Console.WriteLine("Who are you? (A)dult or (C)hild?");
            char input = Console.ReadKey().KeyChar;
            RecipeFactory factory;
            switch (input)
            {
                case 'A':
                    factory = new AdultCuisineFactory();
                    break;

                case 'C':
                    factory = new KidCuisineFactory();
                    break;

                default:
                    throw new NotImplementedException();

            }

            var sandwich = factory.CreateSandwich();
            var dessert = factory.CreateDessert();

            Console.WriteLine("\nSandwich: " + sandwich.GetType().Name);
            Console.WriteLine("Dessert: " + dessert.GetType().Name);

            Console.ReadKey();
        }
    }
    public interface RecipeFactory
    {
        Sandwich CreateSandwich();
        Dessert CreateDessert();
    }

    public abstract class Sandwich
    {
    }
    public abstract class Dessert
    {

    }


    //for child
    class GrilledCheese : Sandwich
    {
    }

    class IceCreamSundae : Dessert
    {
    }


    //or Adult
    public class BLT : Sandwich
    {
    }

    public class CremeBrulee : Dessert
    {
    }


    class AdultCuisineFactory : RecipeFactory
    {
        public Sandwich CreateSandwich()
        {
            return new BLT();
        }

        public Dessert CreateDessert()
        {
            return new CremeBrulee();
        }
    }


    class KidCuisineFactory : RecipeFactory
    {
        public Sandwich CreateSandwich()
        {
            return new GrilledCheese();
        }

        public Dessert CreateDessert()
        {
            return new IceCreamSundae();
        }
    }

   

}
