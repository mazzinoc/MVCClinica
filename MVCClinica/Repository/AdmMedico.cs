using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using MVCClinica.Data;


namespace MVCClinica.Repository
{
    public class AdmMedico
    {
        private static ClinicaContext context = new ClinicaContext();
        public static List<Medico> Listar()
        {
            return context.Medicos.ToList();
        }
        public static Medico Listar(int id)
        {
            return context.Medicos.Find(id);
        }
        public static void Cargar(Medico medico)
        {
            context.Medicos.Add(medico);
            context.SaveChanges();            
        }
        public static Medico Buscar(int id)
        {
            Medico medico = context.Medicos.Find(id);
            context.Entry(medico).State = EntityState.Detached;
            return medico;
        }
        public static void Modificar(Medico medico)
        {
            context.Medicos.Attach(medico);
            context.SaveChanges();
        }
        public static void Borrar(Medico medico)
        {
            context.Medicos.Remove(medico);
        }
        public static List<Medico> BuscarEspecialidad(int especialidad)
        {
            var listaEspecialidad = (from o in context.Medicos
                                     where o.EspecialidadId == especialidad
                                     select o).ToList();
            return listaEspecialidad;
        }
    }
}