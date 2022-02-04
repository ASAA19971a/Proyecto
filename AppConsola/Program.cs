﻿using Microsoft.EntityFrameworkCore;
using Procesos;
using System;
using System.Linq;

namespace AppConsola
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Grabar grabar = new Grabar();
            grabar.DatosIni();

            using (var db = PeriodoPruebaDBBuilder.Crear())
            {

                //Guardar datos y mostrar lista para definir que se ha grabado correctamente
                #region 
                /*
                
                var listaEmpleados = db.Empleados
                    .Include(empleado => empleado.Evaluacion)
                    .Include(empleado => empleado.Implemento);


                Console.WriteLine("Listado de Empleados");
                foreach (var empleado in listaEmpleados)
                {
                    Console.WriteLine(
                        empleado.Nombre + " " +
                        empleado.Cedula + " " +
                        empleado.Correo + " " +
                        "Evaluacion: "+empleado.Evaluacion.Calificacion + " " +
                        "Estado Implemento: "+ empleado.Implemento.Estado 

                    );
                }

                var listaCapacitaciones = db.Capacitaciones;

                Console.WriteLine("Listado de Capacitaciones");
                foreach (var capacitacion in listaCapacitaciones)
                {
                    Console.WriteLine(
                        capacitacion.Tema + " " +
                        capacitacion.Fecha.ToShortDateString() 
                    );
                }

                var listaCapacitacionesAsitencia = db.CapacitacionAsistencias
                    .Include(capacitacionAsistencia => capacitacionAsistencia.Capacitacion)
                    .Include(capacitacionAsistencia => capacitacionAsistencia.Empleado);

                Console.WriteLine("Listado de Asistencia de Capacitaciones");
                foreach (var capacitacionAsistencia in listaCapacitacionesAsitencia)
                {
                    Console.WriteLine(
                        capacitacionAsistencia.Capacitacion.Tema + " " +
                        capacitacionAsistencia.Empleado.Nombre + " " +
                        capacitacionAsistencia.Capacitacion.Fecha
                    );
                }

                //Operacion Proyeccion
                var listaEmpleadosP = db.Empleados
                    .Select(empleado=> new
                    {
                        empleado.EmpleadoId,
                        empleado.Nombre
                    
                    });


                foreach (var empleado in listaEmpleados)
                   
                {
                    Console.Write(empleado.EmpleadoId+ " "+empleado.Nombre);
                }

                */
                #endregion

                //verificar horas totales

                #region 
                var tmpEmpleado = db.Empleados.Single(emp => emp.EmpleadoId == 4);
                ProTotalHoras prohora = new ProTotalHoras(db);

                if (prohora.ApruebaHoras(tmpEmpleado))
                {
                    Console.WriteLine("El empleado " + tmpEmpleado.Nombre + " aprobo las horas necesarias");

                }
                else
                {
                    Console.WriteLine("El empleado " + tmpEmpleado.Nombre + " no aprobó las horas necesarias");

                }

                #endregion
            }
        }
    }
}
