﻿using Modelo.Entidades;
using Modelo.Operaciones;
using ModeloDB;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Procesos
{
    public class ProTotalHoras
    {
        readonly PeriodoPruebaDB db;

        public ProTotalHoras(PeriodoPruebaDB db)
        {
            this.db = db;
        }

        public bool ApruebaHoras(Empleado empleadoP)
        {
            CalcHoras calcular = new CalcHoras();

            var tmpEmpleado = db.Empleados
                .Include(emp => emp.Biometricos)
                .Include(emp => emp.Permisos)
                .Single(emp => emp.EmpleadoId == empleadoP.EmpleadoId);

            var horaF = 0;

            foreach (var bio in tmpEmpleado.Biometricos)
            {              
                horaF = horaF + calcular.HoraTotal(bio);
            }

            if (horaF == 360)
            {
                return true;
            }
            else
            {
                return false;
            }





        }
    }
}
