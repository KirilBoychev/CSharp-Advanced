using NavalVessels.Models.Contracts;
using NavalVessels.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models
{
    public abstract class Vessel : IVessel
    {
        private string name;
        //private ICaptain captain;
        //private double armorThickness;
        //private double mainWeaponCaliber;
        //private double speed;
        //private ICollection<string> targets;
        public Vessel(string name, double mainWeaponCaliber, double speed, double armorThickness)
        {
            this.Name = name;
            this.MainWeaponCaliber = mainWeaponCaliber;
            this.Speed = speed;
            this.ArmorThickness = armorThickness;

            if (this.Captain == null)
            {
                throw new NullReferenceException(ExceptionMessages.InvalidCaptainToVessel);
            }
            this.Targets = new List<string>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidVesselName);
                }

                this.name = value;
            }
        }

        public ICaptain Captain { get; set; }
        public double ArmorThickness { get; set; }

        public double MainWeaponCaliber { get; protected set; }

        public double Speed { get; protected set; }

        public ICollection<string> Targets { get; private set; }

        public void Attack(IVessel target)
        {
            if (this.Targets == null)
            {
                throw new NullReferenceException(ExceptionMessages.InvalidTarget);
            }

            this.ArmorThickness -= target.MainWeaponCaliber;

            if (this.ArmorThickness < 0)
            {
                this.ArmorThickness = 0;
            }

            target.Targets.Add(this.name);
        }

        public abstract void RepairVessel();

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"- {this.Name}")
                .AppendLine($"*Type: {typeof(IVessel).Name}")
                .AppendLine($"*Armor thickness: {this.ArmorThickness}")
                .AppendLine($"*Main weapon caliber: {this.MainWeaponCaliber}")
                .AppendLine($"*Speed: {this.Speed} knots")
                .AppendLine(this.Targets == null ? "None" : string.Join(", ", this.Targets));

            return sb.ToString().Trim();
        }
    }
}
