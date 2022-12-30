using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models
{
    public class Battleship : Vessel, IBattleship
    {
        public Battleship(string name, double mainWeaponCaliber, double speed, double armorThickness) 
            : base(name, mainWeaponCaliber, speed, 300)
        {
            this.SonarMode = false;
        }

        public bool SonarMode { get; private set;}

        public override void RepairVessel()
        {
            this.ArmorThickness = 300;
        }

        public void ToggleSonarMode()
        {
            if (this.SonarMode == false)
            {
                this.SonarMode = true;
                this.MainWeaponCaliber += 40;
                this.Speed -= 5;
            }
            else
            {
                this.SonarMode = false;
                this.MainWeaponCaliber -= 40;
                this.Speed += 5;
            }
        }

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
