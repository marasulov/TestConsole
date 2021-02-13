using System;
using System.ComponentModel;
using System.Threading;
using BQCreator.BL;
using BQCreator.BL.Models;

namespace TestConsole
{
    public interface IOrderRepository
    {
        void Save(string strText);
        string Props { get; set; }
    }
    public class OrderRepository : IOrderRepository
    {
        public string Props { get; set; }

        public void Save(string strText)
        {
            Console.WriteLine(strText);
        }
        
        
    }
    public class OrderManager
    {
        private readonly IOrderRepository _orderRepository;

        public OrderManager(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public void Save(string filename)
        {
            _orderRepository.Save(filename);
        }

        public void GetProps()
        {
            
        }
    }
    
    
    // абстрактный класс строительной компании
    abstract class Developer
    {
        public string Name { get; set; }
 
        public Developer (string n)
        { 
            Name = n; 
        }
        // фабричный метод
        abstract public House Create();
    }
// строит панельные дома
    class PanelDeveloper : Developer
    {
        public PanelDeveloper(string n) : base(n)
        { }
 
        public override House Create()
        {
            return new PanelHouse();
        }
    }
// строит деревянные дома
    class WoodDeveloper : Developer
    { 
        public WoodDeveloper(string n) : base(n)
        { }
 
        public override House Create()
        {
            return new WoodHouse();
        }
    }
 
    abstract class House
    { }
 
    class PanelHouse : House 
    { 
        public PanelHouse()
        {
            Console.WriteLine("Панельный дом построен");
        }
    }
    class WoodHouse : House
    { 
        public WoodHouse()
        {
            Console.WriteLine("Деревянный дом построен");
        }
    }
    
    internal class Program
    {
        public static void Main(string[] args)
        {
            FileModel fileModel= new FileModel();
            Developer dev = new PanelDeveloper("ООО КирпичСтрой");
            House house2 = dev.Create();
         
            dev = new WoodDeveloper("Частный застройщик");
            House house = dev.Create();
 
            Console.ReadLine();
           
            //IFileService fileService = new ExcelManager(@"C:\Users\yusufzhon.marasulov\Desktop\АБК_тест_HVA_R1.xlsx");
            IFileService fileService = new ExcelManager(@"D:\docs\Desktop\ВОР\new\PipingMTO_v2.9-1234321-0021.xlsx");
            
            FileManager fm = new FileManager(fileService);
            fm.Open();
            

            IOrderRepository orderRepository = new OrderRepository();
            OrderManager orderManager = new OrderManager(orderRepository);
            orderManager.Save("saving file");

        }
    }

    public enum SkillSets
    {
        silverlight, dotnet, android, windows
    }
    
    
    public interface IDotNetTeamFactory
    {
        string GetTeam();
    }
    
    public class DotNetTeam:IDotNetTeamFactory
    {
        public string GetTeam()
        {
            return "Dot Net Team";
        }
    }
    public class SilverlightTeam:IDotNetTeamFactory
    {
        public string GetTeam()
        {
            return "Silverlight Team";
        }
    }

    public class WindowsTeam:IMobileTeamFactory
    {
        public string GetMobileTeam()
        {
            return "Windows Team";
        }
    }
    
    public class AndroidTeam:IMobileTeamFactory
    {
        public string GetMobileTeam()
        {
            return "Android Team";
        }
    }
    
    
    public interface IMobileTeamFactory
    {
        string GetMobileTeam();
    }
    
    public interface IBaseFactory
    {
        IDotNetTeamFactory GetDotNetTeam();
        IMobileTeamFactory GetMobileTeam();
    }

    public class ProjectOne:IBaseFactory
    {
        private SkillSets _skillTypeMobile;
        private SkillSets _skillTypeDotNet;

        public ProjectOne(SkillSets skillTypeMobile, SkillSets skillTypeDotNet)
        {
            _skillTypeMobile = skillTypeMobile;
            _skillTypeDotNet = skillTypeDotNet;
        }

        public IDotNetTeamFactory GetDotNetTeam()
        {
            switch (_skillTypeDotNet)
            {
                case SkillSets.dotnet:
                    return new DotNetTeam();
                case SkillSets.silverlight:
                    return new SilverlightTeam();
            }

            return null;
        }

        public IMobileTeamFactory GetMobileTeam()
        {
            switch (_skillTypeMobile)
            {
                case SkillSets.windows:
                    return new WindowsTeam();
                case SkillSets.android:
                    return new AndroidTeam();
            }

            return null;
        }
    }
    
    public class ProjectTwo:IBaseFactory
    {
        public IDotNetTeamFactory GetDotNetTeam()
        {
            return new DotNetTeam();
        }

        public IMobileTeamFactory GetMobileTeam()
        {
            return new AndroidTeam();
        }
    }
}