using System;
using System.ComponentModel;
using System.Threading;

namespace TestConsole
{
    public interface IOrderRepository
    {
        void Save(string strText);
    }
    public class OrderRepository : IOrderRepository
    {
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
    }
    
    internal class Program
    {
        public static void Main(string[] args)
        {
            IOrderRepository orderRepository = new OrderRepository();
            OrderManager orderManager = new OrderManager(orderRepository);
            orderManager.Save("saving file");
            
            IBaseFactory baseFactory = new ProjectOne(SkillSets.windows, SkillSets.silverlight);
            Console.WriteLine("Project One" + Environment.NewLine);
            //Console.WriteLine(baseFactory.GetDotNetTeam().GetTeam());
            Console.WriteLine(baseFactory.GetMobileTeam().GetMobileTeam());
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