using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BQCreator.BL.Models
{
    public class FileModel
    {
        private string fileName;
        private string fileType;

        public List<Pipe> Pipes { get; set; }
        public List<Valve> Valves { get; set; }

        public string FileName
        {
            get { return fileName; }
            set{
                fileName = value;
            }
        }

        public string FileType
        {
            get => fileType;
            set => fileType = value;
        }
        
    }


    public abstract class EquipmentCreator
    {
        public string Name { get; set; }
        public double Diam { get; set; } 
        public int Quantity { get; set; }
        public double Weight { get; set; }
        public string WeightType { get; set; }

        protected EquipmentCreator(string name, double diam, int quantity, double weight)
        {
            Name = name;
            Diam = diam;
            Quantity = quantity;
            Weight = weight;
        }

        abstract public Equipment Create();
    }

    public class Equipment
    {
        
    }

    public class Pipe:EquipmentCreator
    {
        public override Equipment Create()
        {
            return new Equipment();
        }

        public Pipe(string name, double diam, int quantity, double weight) : base(name, diam, quantity, weight)
        {
            
        }
    }
    
    public class Valve:EquipmentCreator
    {
        public override Equipment Create()
        {
            return new Equipment();
        }

        public Valve(string name, double diam, int quantity, double weight) : base(name, diam, quantity, weight)
        {
            
        }
    }

    

    /*
    enum EquipmentType
    {
        Valves,
        Pipes,
        Fittings
    }

    interface IEquipment
    {
        void Create();
        void Write();
    }

    class Valves : IEquipment
    {
        public void Create()
        {
            throw new NotImplementedException();
        }

        public void Write()
        {
            throw new NotImplementedException();
        }
    }

    interface IEquipmentFactory
    {
        IEquipment CreateFan(EquipmentType type);
    }

    class EquipmentFactory : IEquipmentFactory
    {
        public IEquipment CreateFan(EquipmentType type)
        {
            switch (type)
            {
                case EquipmentType.Valves:
                    return new Valves();
                case EquipmentType.Pipes:
                    return new Pipe();
                case EquipmentType.Fittings:
                    return new ExhaustFan();
                default:
                    return new TableFan();
            }
        }
    }*/
    
}

