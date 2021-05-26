using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfLabBat.Model

{
        public class LocalDataProvider : IDataProvider
        {
         public IEnumerable<Car> GetCars()
            {
        return new Car[]
                {
            new Car{Name="Лада Гранта",Speed=90, LiftingCapacity=500, Cena=405, Legko="Легковая"},
            new Car{Name="Газель",Speed=60, LiftingCapacity=1500, Cena=250, Legko="Грузовая"},
            new Car{Name="Волга",Speed=90, LiftingCapacity=500, Cena=400, Legko="Легковая"},
            new Car{Name="КамАЗ",Speed=90, LiftingCapacity=3500, Cena=5000, Legko="Грузовая"},
                };
            }
        }
}

