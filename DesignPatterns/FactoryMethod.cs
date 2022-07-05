using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    public class FactoryMethod
    {
        public FactoryMethod()
        {
            Run();
        }

        private void Run()
        {
            Developer dev = new PanelDeveloper("John");
            var housePanel = dev.Create();
            housePanel.CreateHouse();

            dev = new WoodDeveloper("Yoy");
            var newWoodhouse = dev.Create();
            newWoodhouse.CreateHouse();
        }
    }

    public abstract class Developer
    {
        public Developer(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
        public abstract House Create();
    }
    public class WoodDeveloper : Developer
    {
        public WoodDeveloper(string name) : base(name)
        {

        }
        public override House Create()
        {
            return new WoodHouse();
        }
    }


    public class PanelDeveloper : Developer
    {
        public PanelDeveloper(string name) : base(name)
        {
        }
        public override House Create()
        {
            return new PanelHouse();
        }
    }

    public abstract class House
    {
        public abstract void CreateHouse();
    }
    public class WoodHouse : House
    {
        public override void CreateHouse()
        {
            Console.WriteLine("Wood house ready to use");
        }
    }

    public class PanelHouse : House
    {
        public override void CreateHouse()
        {
            Console.WriteLine("Panel house ready to use");
        }
    }
}
